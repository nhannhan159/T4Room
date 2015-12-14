using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.ODataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // OData builder
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Asset>("Assets");
            builder.EntitySet<AssetDetail>("AssetDetails");
            builder.EntitySet<AssetHistory>("AssetHistories");
            builder.EntitySet<Room>("Rooms");
            builder.EntitySet<RoomReg>("RoomRegs");
            builder.EntitySet<RoomType>("RoomTypes"); 
            builder.EntitySet<User>("Users");
            builder.EntitySet<UserClaim>("UserClaims");
            builder.EntitySet<UserLogin>("UserLogins");
            builder.EntitySet<Role>("Roles");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
