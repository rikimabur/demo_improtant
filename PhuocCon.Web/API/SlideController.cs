using AutoMapper;
using PhuocCon.Model.Models;
using PhuocCon.Service;
using PhuocCon.Web.Infrastructure.Core;
using PhuocCon.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhuocCon.Web.API
{
    [RoutePrefix("api/slide")]
    public class SlideController : ApiControllerBase
    {
        ISlideService _slideService;
        public SlideController(IErrorService errorService, ISlideService slideService) : base(errorService)
        {
            this._slideService = slideService;
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _slideService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(model);
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
                var model = _slideService.GetAll();
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize);
                var respondeData = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(query);
                var paginationSet = new PaginationSet<SlideViewModel>
                {
                    Items = respondeData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}
