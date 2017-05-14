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
namespace PhuocCon.Web.API
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService, IErrorService errorService) : base(errorService)
        {
            this._orderService = orderService;
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            Func<HttpResponseMessage> func = () =>
            {
                var model = _orderService.GetAll();
                var responData = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responData);
                return response;
            };
            return CreateHttpReponse(request, func);
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
             {
                 var model = _orderService.GetById(id);
                 var responseData = Mapper.Map<Order, OrderViewModel>(model);
                 HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responseData);
                 return response;
             });
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;
                var model = _orderService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CustomerID).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(query);
                var paginationSet = new PaginationSet<OrderViewModel>
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

        [Route("delete/{id:int}")]
        [HttpDelete]
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
                    var oldOrder = _orderService.Delete(id);
                    _orderService.Save();
                    var responseData = Mapper.Map<Order, OrderViewModel>(oldOrder);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedOrder)
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
                     var listOrder = new JavaScriptSerializer().Deserialize<List<int>>(checkedOrder);
                     foreach (var item in listOrder)
                     {
                         _orderService.Delete(item);
                     }
                     _orderService.Save();
                     response = request.CreateResponse(HttpStatusCode.OK, listOrder.Count());
                 }
                 return response;
             });
        }


    }
}