using System.Windows;
using MES_2.Utils;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           this.InitializeComponent();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
