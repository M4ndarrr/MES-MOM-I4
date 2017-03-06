using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MES_2.Database;
using MES_application.Modules.CommunicationModule;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //zkouska
            using (var db = new TestDatabaseEntities())
            {
                var table = db.ResultTable.GroupBy(id => id.IDComObject).ToList();
                //var table = db.ResultTable.ToList();
                                foreach (var prvek in table)
                                {
                    var line = new RadLinearSparkline();
                    line.ItemsSource = prvek.ToList();
                                   
                                }
//                var line = new RadLinearSparkline();
//                myLinearSparkline.ItemsSource = table;
            }

            

        }

        private void PLCADD_Click(object sender, RoutedEventArgs e)
        {
            PlcConnectorModule jednicka = PlcConnectorModuleRepository.Instance.Add
            (
                new PLCConnectorModuleConfigure()
                {
                    // IpString = "10.132.70.232",
                    IpString = "172.20.192.41",
                    PortString = "102",
                    Rack = 0,
                    Slot = 1
                }
            );
        }

    }
}