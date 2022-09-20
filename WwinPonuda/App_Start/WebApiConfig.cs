using System.Web.Http;

namespace WwinPonuda.App_Start
{
    public class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
            {
            config.EnableCors();
            config.MapHttpAttributeRoutes();

            _ = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{TurnirID}",
                defaults: new { TurnirID = RouteParameter.Optional }
                );
        }
    }
}
                                               