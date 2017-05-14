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

namespace PhuocCon.Web.API
{
    [RoutePrefix("api/province")]
    public class ProvinceController : ApiControllerBase
    {
        IProvinceService _provinceService;
        public ProvinceController(IErrorService errorService, IProvinceService provinceService) : base(errorService)
        {
            _provinceService = provinceService;
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpReponse(request, () =>
            {
                var model = _provinceService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            Func<HttpResponseMessage> func = () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _provinceService.Delete(id);
                    var responseData = Mapper.Map<Province, ProvinceViewModel>(model);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            };
            return CreateHttpReponse(request, func);
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProvinceViewModel provinceViewModel)
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
                     var ProvinceNew = new Province();
                     ProvinceNew.UpdateProvince(provinceViewModel);
                     _provinceService.Add(ProvinceNew);
                     _provinceService.SaveChange();
                     var responseData = Mapper.Map<Province, ProvinceViewModel>(ProvinceNew);
                     response = request.CreateResponse(HttpStatusCode.OK, responseData);
                 }
                 return response;
             });
        }
    }
}
