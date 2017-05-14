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
    [RoutePrefix("api/country")]
    public class CountryController : ApiControllerBase
    {
        ICountryService _countryService;
        public CountryController(IErrorService errorService, ICountryService countryService):base(errorService)
        {
            _countryService = countryService;
        }
        [Route("getallparents")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
             {
                 var model = _countryService.GetAll();
                 var responseData = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(model);
                 var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                 return response;
             };
            return CreateHttpReponse(request, func);
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;
                var model = _countryService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(query);

                var paginationSet = new PaginationSet<CountryViewModel>()
                {
                    Items = responseData,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("delete")]
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
                     var model = _countryService.Delete(id);
                     _countryService.SaveChange();
                     var responseData = Mapper.Map<Country, CountryViewModel>(model);
                     response = request.CreateResponse(HttpStatusCode.OK, responseData);
                 }
                 return response;
             });
        }
        [Route("create")]
        public HttpResponseMessage Create(HttpRequestMessage request,CountryViewModel countryViewModel)
        {
            Func<HttpResponseMessage> func = () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var NewCountry = new Country();
                    NewCountry.UpdateCountry(countryViewModel);
                    _countryService.Add(NewCountry);
                    _countryService.SaveChange();
                    var responseData = Mapper.Map<Country, CountryViewModel>(NewCountry);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            };
            return CreateHttpReponse(request, func);
        }
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, CountryViewModel countryViewModel)
        {
            Func<HttpResponseMessage> func = () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var NewCountry = new Country();
                    NewCountry.UpdateCountry(countryViewModel);
                    _countryService.Update(NewCountry);
                    _countryService.SaveChange();
                    var responseData = Mapper.Map<Country, CountryViewModel>(NewCountry);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            };
            return CreateHttpReponse(request, func);
        }
    }
}
