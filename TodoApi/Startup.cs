using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;
using TodoApi.App_Start;

namespace TodoApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorInitializer.Initialize();
            WebApiConfig.Configure(app);
        }
    }
}