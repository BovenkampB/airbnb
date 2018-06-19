using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Rewrite;

namespace InsideAirBNB.App.Services
{
    public enum HttpsPolicy { Required, Optional };

    public class RewriteHttpsOnAppEngine : IRule
    {
        readonly HttpsPolicy _httpsPolicy;
        public RewriteHttpsOnAppEngine(HttpsPolicy httpsPolicy)
        {
            _httpsPolicy = httpsPolicy;
        }

        static PathString s_healthCheckPathString = new PathString("/_ah/health");

        public static bool Rewrite(HttpRequest request)
        {
            if (request.Scheme == "https")
            {
                return true;  // Already https.
            }

            string proto = request.Headers["X-Forwarded-Proto"].FirstOrDefault();

            if (proto == "https")
            {
                request.IsHttps = true;
                request.Scheme = "https";
                return true;
            }

            if (request.Path.StartsWithSegments(s_healthCheckPathString))
            {
                return true;
            }

            return false;
        }

        void IRule.ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            bool wasSecure = Rewrite(request);

            if (!wasSecure && _httpsPolicy == HttpsPolicy.Required)
            {
                var newUrl = string.Concat(
                        "https://",
                        request.Host.ToUriComponent(),
                        request.PathBase.ToUriComponent(),
                        request.Path.ToUriComponent(),
                        request.QueryString.ToUriComponent());

                var action = new RedirectResult(newUrl);

                ActionContext actionContext = new ActionContext()
                {
                    HttpContext = context.HttpContext
                };

                action.ExecuteResult(actionContext);
                context.Result = RuleResult.EndResponse;
            }
        }

    }
}
