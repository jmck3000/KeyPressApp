using Autofac;
using KeyPressApp.Engine;
using KeyPressApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressApp
{
    public static class ContainerConfig
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Manager>().As<IManager>();
            builder.RegisterType<KeyPress>().As<IKeyPress>();
            builder.RegisterType<Logger>().As<ILogger>();

            return builder.Build();
        }
    }
}
