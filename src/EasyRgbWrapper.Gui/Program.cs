using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using EasyRgbWrapper.Gui.Controls;
using EasyRgbWrapper.Lib;

namespace EasyRgbWrapper.Gui
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            BuildContainer().Resolve<IApp>().Start(args);
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