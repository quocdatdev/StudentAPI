using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Net;

namespace APIDemo.Filter
{
    public class GlobalException : ExceptionFilterAttribute , IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //HttpStatusCode stt = HttpStatusCode.InternalServerError;
            //string msg;
            //base.OnException(actionExecutedContext);
            //var exType = context.Exception.GetType();

            if (context.Exception is MyException)
            {
                HttpResponseMessage responseMessage = null;
                var rs = context.Exception.Message;
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(rs),
                    ReasonPhrase = rs
                };
                context.Response = responseMessage;
            }
        }
    }
}