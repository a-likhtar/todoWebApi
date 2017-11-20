using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using TodoApi.Models;
using TodoApi.Repository;
using TodoApi.Service;

namespace TodoApi.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static Container Container { get; set; }

        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            InitializeContainer(container);
            container.Verify();
            Container = container;
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<TodoApiContext>(Lifestyle.Scoped);
            container.Register<ITodoRepository, TodoRepository>(Lifestyle.Scoped);
            container.Register<ITodoService, TodoService>(Lifestyle.Scoped);
        }
    }
}