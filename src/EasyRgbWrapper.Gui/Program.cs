using System;
using System.Windows.Forms;
using Autofac;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            using var container = BuildContainer();
            container.Resolve<IApp>().Start(args);
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RgbEasyContext>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .SingleInstance();

            return builder.Build();
        }
    }
}