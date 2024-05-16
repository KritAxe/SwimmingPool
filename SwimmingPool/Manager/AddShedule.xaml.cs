using SwimmingPool.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SwimmingPool.Manager
{
    /// <summary>
    /// Логика взаимодействия для AddShedule.xaml
    /// </summary>
    public partial class AddShedule : Window
    {
        public AddShedule()
        {
            InitializeComponent();
            EnterTrainer.ItemsSource = Classes.DBContext.context.Employee.Where(i => i.IDPosition == 3).ToList();
            EnterTrainer.DisplayMemberPath = "LName";
            EnterTrainer.SelectedIndex = 0;

            EnterClient.ItemsSource = Classes.DBContext.context.Sales.ToList();
            EnterClient.DisplayMemberPath = "Client.LName";
            EnterClient.SelectedIndex = 0;

            CMBWeekDay();
        }
        private void CMBWeekDay()
        {
            var daysOfWeek = new[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

            foreach (var day in daysOfWeek)
            {
                CMBTitleDay.Items.Add(day);
            }
            CMBTitleDay.SelectedIndex = 0;
        }
        private void AddGridShedule(object sender, RoutedEventArgs e)
        {
            SheduleGrid.ItemsSource = Classes.DBContext.context.Shedule.ToList();
        }
        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            Shedule newShedule = new Shedule();
            newShedule.IDEmployee = (EnterTrainer.SelectedItem as Employee).EmployeeID - 1;
            newShedule.IDSales = (EnterClient.SelectedItem as Sales)?.SalesID ?? - 1;
            newShedule.IDPool = (EnterClient.SelectedItem as Sales)?.Subscription.IDType ?? - 1;
            newShedule.StartTime = TimeSpan.Parse("09:00:00");
            newShedule.EndTime = TimeSpan.Parse("13:00:00");
            newShedule.DayOfWek = Convert.ToString(CMBTitleDay.SelectedItem);

            DBContext.context.Shedule.Add(newShedule);
            DBContext.context.SaveChanges();
            SheduleGrid.ItemsSource = DBContext.context.Shedule.ToList();
        }


        private void BackClient_Click(object sender, RoutedEventArgs e)
        {
            CreateClient createClient = new CreateClient();
            createClient.Show();
            Close();
        }

        
    }
}
