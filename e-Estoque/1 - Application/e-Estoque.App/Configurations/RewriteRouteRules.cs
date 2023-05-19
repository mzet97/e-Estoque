using Microsoft.AspNetCore.Rewrite;

namespace e_Estoque.App.Configurations
{
    public class RewriteRouteRules
    {
        public static void ReWriteRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Path.Value.Contains("%2F", StringComparison.OrdinalIgnoreCase))
            {
                context.HttpContext.Request.Path = context.HttpContext.Request.Path.Value.Replace("%2F", "/");
            }

        }
    }
}
