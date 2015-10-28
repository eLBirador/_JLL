using MvcCms.App_Start;
using MvcCms.Data;
using MvcCms.Models;
using MvcCms.Models.ModelBinders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCms
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();

            AuthDbConfig.RegisterAdmin();

            ModelBinders.Binders.Add(typeof(Post), new PostModelBinder());

            //Database.SetInitializer<CmsContext>(new DropCreateDatabaseIfModelChanges<CmsContext>());
        }
    }
}
