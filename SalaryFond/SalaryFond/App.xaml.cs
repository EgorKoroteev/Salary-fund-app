using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalaryFond.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace SalaryFond
{
    public partial class App : Application
    {
        public static bool IsDesignMode { get; set; } = true;

        private static IHost _Host;

        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            base.OnStartup(e);
            var host = Host;
            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.RegisterServices();
        }

        public static string CurrentDirectory => IsDesignMode ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string Path = null) => Path;
    }
}
