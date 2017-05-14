using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhuocCon.Model.Models;
using PhuocCon.Service;
using PhuocCon.Web.Infrastructure.Core;
using PhuocCon.Web.Models;
using PhuocCon.Web.Infrastructure.Extensions;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using PhuocCon.Common;
using System.Web;

namespace PhuocCon.Web.API
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController :ApiControllerBase
    {
        #region initialize
        IProductService _productService;
        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }
        #endregion
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _productService.GetAll();
                var responData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            };
            return CreateHttpReponse(request, func);
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;
                var model = _productService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetID(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                var model = _productService.GetById(id);
                var responData = Mapper.Map<Product, ProductViewModel>(model);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var NewProduct = new Product();
                    NewProduct.UpdateProduct(productViewModel);
                    NewProduct.CreatedDate = DateTime.Now;
                    NewProduct.CreatedBy = User.Identity.Name;
                    _productService.Add(NewProduct);
                    _productService.Save();
                    var responData = Mapper.Map<Product, ProductViewModel>(NewProduct);
                    response = request.CreateResponse(HttpStatusCode.OK, responData);
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
        {
            return CreateHttpReponse(request, () => {
                HttpResponseMessage respon = null;
                if (!ModelState.IsValid)
                {
                    respon = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProduct = _productService.GetById(productViewModel.ID);
                    dbProduct.UpdateProduct(productViewModel);
                    dbProduct.UpdateDate = DateTime.Now;
                    dbProduct.UpdateBy = User.Identity.Name;
                    _productService.Update(dbProduct);
                    _productService.Save();
                    var responData = Mapper.Map<Product, ProductViewModel>(dbProduct);
                    respon = request.CreateResponse(HttpStatusCode.Created, responData);
                }
                return respon;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProduct = _productService.Delete(id);
                    _productService.Save();
                    var responData = Mapper.Map<Product, ProductViewModel>(oldProduct);
                    response = request.CreateResponse(HttpStatusCode.OK, responData);
                }
                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProduct)
        {
            return CreateHttpReponse(request, () => {
                HttpResponseMessage respon = null;
                if (!ModelState.IsValid)
                {
                    respon = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProduct);
                    foreach (var item in listProductCategory)
                    {
                        _productService.Delete(item);
                    }
                    _productService.Save();
                    respon = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }
                return respon;
            });
        }
        [Route("import")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> ImportExcel()
        {
            //check file support ex: .xlsx
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Định dạng server không được hổ trợ");
            }
            var root = HttpContext.Current.Server.MapPath("~/UploadedFiles/Excels"); 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var provider = new MultipartFormDataStreamProvider(root);
            // read request 
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            // do stuff with files if you wish
            if (result.FormData["categoryId"] == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bạn chưa chọn danh mục");
            }
            if (result.FormData["providerId"] == null)
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bạn chưa chọn nhà sản xuất");
            }

            //Upload files
            int addedCount = 0;
            int categoryId = 0;
            int providerId = 0;
            int.TryParse(result.FormData["categoryId"], out categoryId);
            int.TryParse(result.FormData["providerId"], out providerId);
            foreach (MultipartFileData fileData in result.FileData)
            {
                if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "yêu cầu không đúng định dạng");
                }
                string fileName = fileData.Headers.ContentDisposition.FileName;
                if(fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if(fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = Path.GetFileName(fileName);
                }

                var fullPath = Path.Combine(root, fileName);
                File.Copy(fileData.LocalFileName, fullPath, true);

                // insert to DB
                var listProduct = this.ReadProductFromExcel(fullPath, categoryId, providerId);
                if (listProduct.Count > 0)
                {
                    foreach (var product in listProduct)
                    {
                        _productService.Add(product);
                        addedCount++;
                    }
                    _productService.Save();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Đã nhập thành công" + addedCount + "sản phẩm");
        }
        private List<Product> ReadProductFromExcel(string fullPath,int categoryId,int providerId)
        {
            using (var package = new ExcelPackage(new FileInfo(fullPath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                List<Product> listProduct = new List<Product>();
                ProductViewModel productViewModel;
                Product product;

                decimal originalPrice = 0;
                decimal price = 0;
                decimal promotionPrice;

                bool status = false;
                bool showHome = false;
                bool isHot = false;
                int warranty;

                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    productViewModel = new ProductViewModel();
                    product = new Product();

                    productViewModel.Name = workSheet.Cells[i, 1].Value.ToString();
                    productViewModel.Alias = StringHelper.ToUnsignString(productViewModel.Name);
                    productViewModel.Description = workSheet.Cells[i, 2].Value.ToString();

                    if (!int.TryParse(workSheet.Cells[i, 3].Value.ToString(), out warranty))
                    {
                        break;
                    }
                    productViewModel.Warranty = warranty;

                    decimal.TryParse(workSheet.Cells[i, 4].Value.ToString().Replace(",","").Replace(".", ""), out originalPrice);
                    productViewModel.OriginalPrice = originalPrice;

                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString().Replace(",", "").Replace(".",""), out price);
                    productViewModel.Price = price;

                    if (!decimal.TryParse(workSheet.Cells[i, 6].Value.ToString().Replace(",", "").Replace(".", ""), out promotionPrice))
                    {
                        break;
                    }
                    productViewModel.PromotionPrice = promotionPrice;

                    productViewModel.Content = workSheet.Cells[i, 7].Value.ToString();
                    productViewModel.Metakeyword = workSheet.Cells[i, 8].Value.ToString();
                    productViewModel.MetaDescription = workSheet.Cells[i, 9].Value.ToString();

                    productViewModel.CategoryID = categoryId;
                    productViewModel.ProviderID = providerId;
         
                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out status);
                    productViewModel.Status = status;
                    bool.TryParse(workSheet.Cells[i, 11].Value.ToString(), out showHome);
                    productViewModel.HomeFlag = showHome;
                    bool.TryParse(workSheet.Cells[i, 12].Value.ToString(), out isHot);
                    productViewModel.HotFlag = isHot;

                    product.UpdateProduct(productViewModel);
                    listProduct.Add(product);
                }
                return listProduct;
            }
                
        }
        [HttpGet]
        [Route("ExportXls")]
        public async Task<HttpResponseMessage> ExportXls(HttpRequestMessage request, string filter = null)
        {
            string fileName = string.Concat("Product_" + DateTime.Now.ToString("yyyyMMddhhmmsss") + ".xlsx");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var data = _productService.GetListProduct(filter).ToList();
                await ReportHelper.GenerateXls(data, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("ExportPdf")]
        public async Task<HttpResponseMessage> ExportPdf(HttpRequestMessage request, int id)
        {
            string fileName = string.Concat("Product" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".pdf");
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fullPath = Path.Combine(filePath, fileName);
            try
            {
                var template = File.ReadAllText(HttpContext.Current.Server.MapPath("/Assets/admin/templates/product_detail.html"));
                var replaces = new Dictionary<string, string>();
                var product = _productService.GetById(id);

                replaces.Add("{{ProductName}}", product.Name);
                replaces.Add("{{Price}}", product.Price.ToString("N0"));
                replaces.Add("{{Description}}", product.Description);
                replaces.Add("{{Warranty}}", product.Warranty + " tháng");

                template = template.Parse(replaces);

                await ReportHelper.GeneratePdf(template, fullPath);
                return request.CreateErrorResponse(HttpStatusCode.OK, Path.Combine(folderReport, fileName));
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
