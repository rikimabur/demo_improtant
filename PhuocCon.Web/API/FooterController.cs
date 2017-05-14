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
    [RoutePrefix("api/footer")]
    public class FooterController : ApiControllerBase
    {
        IFooterService _footerService;

        public FooterController(IErrorService errorService, IFooterService footerService) : base(errorService)
        {
            _footerService = footerService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpReponse(request ,() =>{
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var model = _footerService.GetAll();
                    var responseData = Mapper.Map<IEnumerable<Footer>, IEnumerable<FooterViewModel>>(model);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
        //[Route("getbyid")]
        //public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        //{
        //    Func<HttpResponseMessage> func = () =>
        //    {
        //        var model = _footerService.GetById(id);
        //        var responseData = Mapper.Map<IEnumerable<Footer>, IEnumerable<FooterViewModel>>(model);
        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    };
        //    return CreateHttpReponse(request, func);
        //}
        //[Route("create")]
        //public HttpResponseMessage Create(HttpRequestMessage request, FooterViewModel footerViewModel)
        //{
        //    return CreateHttpReponse(request, () =>
        //     {
        //         HttpResponseMessage response = null;
        //         if (!ModelState.IsValid)
        //         {
        //             response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //         }
        //         else
        //         {
        //             var NewFooter = new Footer();
        //             NewFooter.UpdateFooter(footerViewModel);
        //             _footerService.Add(NewFooter);
        //             _footerService.Save();
        //             var responseData = Mapper.Map<Footer, FooterViewModel>(NewFooter);
        //             response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //         }
        //         return response;
        //     });
        //}
        //[Route("update")]
        //public HttpResponseMessage Update(HttpRequestMessage request, FooterViewModel footerViewModel)
        //{
        //    return CreateHttpReponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var dbFooter = _footerService.GetById(footerViewModel.ID);
        //            dbFooter.UpdateFooter(footerViewModel);
        //            _footerService.Update(dbFooter);
        //            _footerService.Save();
        //            var responseData = Mapper.Map<Footer, FooterViewModel>(dbFooter);
        //            response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        }
        //        return response;
        //    });
        //}

    }
}
