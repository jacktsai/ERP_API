using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ErpApi
{
    /// <summary>
    /// ModelStateActionFilter 的摘要描述
    /// </summary>
    public class ModelStateActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var errorList = new Dictionary<string, IEnumerable<string>>();
                foreach (var pair in actionContext.ModelState)
                {
                    var errors = pair.Value.Errors;
                    if (errors.Count > 0)
                    {
                        errorList[pair.Key] = errors.Select(e =>
                        {
                            if (string.IsNullOrEmpty(e.ErrorMessage))
                            {
                                return e.Exception.Message;
                            }

                            return e.ErrorMessage;
                        });
                    }
                }

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
            }
        }
    }
}