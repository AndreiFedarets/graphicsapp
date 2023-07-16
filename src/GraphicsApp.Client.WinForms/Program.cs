using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Unity;
using Unity.Microsoft.Logging;
using Unity.Microsoft.Options;

namespace GraphicsApp.Client.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IUnityContainer container = BuildContainer();
            Application.Run(container.Resolve<MainForm>());
        }

        public static IUnityContainer BuildContainer()
        {
            IConfiguration configuration = BuildConfiguration();
            ILoggerFactory loggerFactory = new LoggerFactory().AddFile(configuration.GetSection(nameof(Serilog)));
            IUnityContainer container = new UnityContainer()
                .RegisterInstance(configuration)
                .AddExtension(new LoggingExtension(loggerFactory))
                .AddExtension(new OptionsExtension())
                .RegisterFactory<IBaseColorProvider>(container =>
                {
                    var provider = new BaseColorProvider(Color.LightGreen);
                    provider.BaseColorChanged += (sender, args) =>
                    {
                        var areaBuilder = container.Resolve<AreaBuilder>();
                        areaBuilder.HasChanges = true;
                    };

                    return provider;
                }, FactoryLifetime.Singleton)
                .RegisterFactory<IShapeIntersectionCalculator>(container =>
                {
                    return new CommonShapeIntersectionCalculator(new[]
                    {
                        container.Resolve<TriangleIntersectionCalculator>()
                    });
                }, FactoryLifetime.Singleton)
                .RegisterFactory<AreaBuilder>(container =>
                {
                    var providerConfig = new FileShapeProviderConfig();
                    configuration.GetSection(nameof(TextFileTriangleProvider)).Bind(providerConfig);
                    return new AreaBuilder(container.Resolve<ILogger<AreaBuilder>>())
                            .TakeTrianglesFromTextFile(providerConfig)
                            .BuildShapeTree(container.Resolve<IShapeIntersectionCalculator>())
                            .AssignColorsByLevels(container.Resolve<IBaseColorProvider>())
                            .AppendShadeCountStatus()
                            .WithErrorOnFailure(container.Resolve<IBaseColorProvider>());
                }, FactoryLifetime.Singleton);


            return container;
        }

        static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}