using System.Web.Http;
using PhuocCon.Web.Infrastructure.Core;
using PhuocCon.Service;

namespace PhuocCon.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }
        
        [Route("TestMethod")]
        [HttpGet]
        public string TestMethod()
        {
            return "Hello , PhuocCon Member";
        }
    }
}
