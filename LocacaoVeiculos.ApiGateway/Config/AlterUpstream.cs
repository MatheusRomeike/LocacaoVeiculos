using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LocacaoVeiculos.ApiGateway.Config
{
    /// <summary>
    /// Alter upstream json
    /// </summary>
    public class AlterUpstream
    {
        /// <summary>
        /// Alter upstream swagger json
        /// </summary>
        /// <param name="context"></param>
        /// <param name="swaggerJson"></param>
        /// <returns></returns>
        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
        {
            var swagger = JObject.Parse(swaggerJson);
            // ... alter upstream json
            return swagger.ToString(Formatting.Indented);
        }
    }
}