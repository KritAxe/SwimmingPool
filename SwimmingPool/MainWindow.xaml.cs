using SwimmingPool.Administrator;
using SwimmingPool.Classes;
using SwimmingPool.Manager;
using SwimmingPool.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwimmingPool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = DBContext.context.Employee.ToList().
                Where(i => i.Login == TBLogin.Text && i.Password == PBPassword.Password && i.IDPosition == 1 && i.IDStatus == 1).
                FirstOrDefault();
            if (userAuth != null)
            {
                CreateClient createClient = new CreateClient();
                createClient.Show();
                Close();
            }
            
            var userAuthh = DBContext.context.Employee.ToList().
                Where(i => i.Login == TBLogin.Text && i.Password == PBPassword.Password && i.IDPosition == 2 && i.IDStatus == 1).
                FirstOrDefault();
            if (userAuthh != null)
            {
                ChangeClient changeClient = new ChangeClient();
                changeClient.Show();
                Close();
            }
            
            var userAuthhh = DBContext.context.Employee.ToList().
                Where(i => i.Login == TBLogin.Text && i.Password == PBPassword.Password && i.IDPosition == 3 && i.IDStatus == 1).
                FirstOrDefault();
            if (userAuthhh != null)
            {
                BrowseShedule browseShedule = new BrowseShedule();
                browseShedule.Show(); 
                Close();
            }
           
        }
    }
}
