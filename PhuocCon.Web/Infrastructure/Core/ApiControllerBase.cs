using PhuocCon.Model.Models;
using PhuocCon.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhuocCon.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }
        protected HttpResponseMessage CreateHttpReponse(HttpRequestMessage requesrMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage reponse = null;
            try
            {
                reponse = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var even in ex.EntityValidationErrors)
                {
                    Trace.WriteLine("Entity of type \" {even.Entry.Entity.GetType().Name} \" in state\"{even.Entry.State}\" has the flowing validation errors");
                    foreach (var ve in even.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{ve.PropertyName}\",Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                reponse = requesrMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);

            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                reponse = requesrMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                reponse = requesrMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return reponse;
        }
        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.CreatedDate =DateTime.Now;
                error.Message =ex.Message;
                error.StackTrace = ex.StackTrace;
                _errorService.Create(error);
                _errorService.Save();
            }
            catch
            {

            }
        }
    }
}
