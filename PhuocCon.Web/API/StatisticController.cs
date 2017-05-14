using PhuocCon.Service;
using PhuocCon.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PhuocCon.Web.API
{
    [Authorize]
    [RoutePrefix("api/statistic")]
    public class StatisticController : ApiControllerBase
    {
        IStatisticService _statisticService;
        public StatisticController(IErrorService errorService,IStatisticService statisticService) :base(errorService)
        {
            this._statisticService = statisticService;
        }
        [Route("getrevenue")]
        [HttpGet]
        public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request, string fromDate, string toDate)
        {
            return CreateHttpReponse(request, () =>
             {
                 var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
                 HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                 return response;
             });
        }

    }
}