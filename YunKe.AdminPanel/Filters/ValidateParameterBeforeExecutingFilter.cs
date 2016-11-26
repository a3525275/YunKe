using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunKe.Infrastructure.Validation;

namespace YunKe.AdminPanel.Filters
{
    public class ValidateParameterBeforeExecutingFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = ValidateProperties(filterContext);
            if (result.Count > 0)
            {
                throw new Exception(string.Join("\r\n", result.Select(x => x.Value).ToArray()));
            }
        }

        internal static IDictionary<string, string> ValidateProperties(ActionExecutingContext filterContext)
        {
            string key = filterContext.ActionDescriptor.ActionName + "_Attributes";

            // get from application storage
            IDictionary<string, string> defaults = filterContext.HttpContext.Application[key] as IDictionary<string, string>;

            if (defaults == null)
            {
                defaults = new Dictionary<string, string>(filterContext.ActionParameters.Count);
                foreach (var parameter in filterContext.ActionParameters)
                {
                    var type = parameter.Value.GetType();
                    if (type.IsDefined(typeof(HasIdPropertyAttribute), false))
                    {
                        var attr = type.GetCustomAttributes(typeof(HasIdPropertyAttribute), false)[0] as HasIdPropertyAttribute;
                        string parameterName = parameter.Key;
                        string actionName = filterContext.ActionDescriptor.ActionName;

                        try
                        {
                            var validated = attr.Validate(parameterName, type);
                        }
                        catch (ActionParameterValidationException exc)
                        {
                            defaults.Add(parameterName, exc.Message);
                        }
                    }
                }

                // add to application storage
                filterContext.HttpContext.Application[key] = defaults;
            }

            return defaults;
        }
    }
}