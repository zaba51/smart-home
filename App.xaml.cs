using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SmartHome
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //IContainer container = builder.Build();
            //DISource.Resolver = (type) => {
            //    return container.Resolve(type);
            //};
        }
    }

}
