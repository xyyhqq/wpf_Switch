using FullApp.ThermometerDemo.Modules.ModuleName;
using FullApp.ThermometerDemo.Services;
using FullApp.ThermometerDemo.Services.Interfaces;
using FullApp.ThermometerDemo.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace FullApp.ThermometerDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
