using WPF.ViewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);



//            using (var db = new TestDatabaseEntities())
//            {
//                db.USR_UserList.Add(new USR_UserList()
//                {
//                    First_Name = "Jan",
//                    Last_Name = "Tichy",
//                    LOGIN = "xtichy25",
//                    PASSWORD = "1234"
//                });
//                db.SaveChanges();

            //}
            //zkouska
            //            using (var db = new TestDatabaseEntities())
            //            {
            //                var table = db.ResultTable.GroupBy(id => id.IDComObject).ToList();
            //                //var table = db.ResultTable.ToList();
            //                                foreach (var prvek in table)
            //                                {
            //                    var line = new RadLinearSparkline();
            //                    line.ItemsSource = prvek.ToList();
            //                                   
            //                                }
            ////                var line = new RadLinearSparkline();
            ////                myLinearSparkline.ItemsSource = table;
            //            }



        }
    }
}