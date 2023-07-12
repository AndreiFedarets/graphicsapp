using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using Unity;
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

        static IUnityContainer BuildContainer()
        {
            IConfiguration configuration = BuildConfiguration();
            IUnityContainer container = new UnityContainer()
                .RegisterInstance(configuration)
                .AddExtension(new OptionsExtension())
                .RegisterFactory<IShapeIntersectionCalculator>(container =>
                {
                    return new ShapeIntersectionCalculatorBuilder()
                                .Add<TriangleIntersectionCalculator>()
                                .Build();
                }, FactoryLifetime.Singleton)
                .RegisterFactory<AreaBuilder>(container =>
                {
                    var providerConfig = new FileShapeProviderConfig();
                    configuration.GetSection(nameof(TextFileTriangleProvider)).Bind(providerConfig);
                    return new AreaBuilder()
                            .WithTrianglesFromTextFile(providerConfig)
                            .WithAreaSorter(System.ComponentModel.ListSortDirection.Descending)
                            .WithColorGenerator(Color.Green);
                            //.WithShapeIntersectionValidator(container.Resolve<IShapeIntersectionCalculator>());
                });


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