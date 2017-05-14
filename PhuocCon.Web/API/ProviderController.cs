using AutoMapper;
using PhuocCon.Model.Models;
using PhuocCon.Service;
using PhuocCon.Web.Infrastructure.Core;
using PhuocCon.Web.Infrastructure.Extensions;
using PhuocCon.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace PhuocCon.Web.API
{
    [RoutePrefix("api/provider")]
    [Authorize]
    public class ProviderController : ApiControllerBase
    {
        private IProviderService _providerService;
        public ProviderController(IProviderService providerService, IErrorService errorService) : base(errorService)
        {
            this._providerService = providerService;
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _providerService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Provider>,IEnumerable<ProviderViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
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
                 var model = _providerService.GetAll(keyword);
                 totalRow = model.Count();
                 var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
                 var responseData = Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderViewModel>>(query);
                 var paginationSet = new PaginationSet<ProviderViewModel>()
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
                var model = _providerService.GetById(id);
                var responData = Mapper.Map<Provider, ProviderViewModel>(model);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProviderViewModel providerViewModel)
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
                     var NewProvider = new Provider();
                     NewProvider.UpdateProvider(providerViewModel);
                     _providerService.Add(NewProvider);
                     _providerService.Save();
                     var responseData = Mapper.Map<Provider, ProviderViewModel>(NewProvider);
                     response = request.CreateResponse(HttpStatusCode.OK, responseData);
                 }
                 return response;
             });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProviderViewModel providerViewModel)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var NewProvider = new Provider();
                    NewProvider.UpdateProvider(providerViewModel);
                    _providerService.Update(NewProvider);
                    _providerService.Save();
                    var responseData = Mapper.Map<Provider, ProviderViewModel>(NewProvider);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
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
                    var oldProvider = _providerService.Delete(id);
                    _providerService.Save();
                    var responData = Mapper.Map<Provider, ProviderViewModel>(oldProvider);
                    response = request.CreateResponse(HttpStatusCode.OK, responData);
                }
                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProvider)
        {
            return CreateHttpReponse(request, () => {
                HttpResponseMessage respon = null;
                if (!ModelState.IsValid)
                {
                    respon = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProvider = new JavaScriptSerializer().Deserialize<List<int>>(checkedProvider);
                    foreach (var item in listProvider)
                    {
                        _providerService.Delete(item);
                    }
                    _providerService.Save();
                    respon = request.CreateResponse(HttpStatusCode.OK, listProvider.Count);
                }
                return respon;
            });
        }
    }
}
