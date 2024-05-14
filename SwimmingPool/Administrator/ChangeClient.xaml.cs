using SwimmingPool.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SwimmingPool.Administrator
{
    /// <summary>
    /// Логика взаимодействия для ChangeClient.xaml
    /// </summary>
    public partial class ChangeClient : Window
    {
        public ChangeClient()
        {
            InitializeComponent();
        }

        private void Client_Loaded(object sender, RoutedEventArgs e)
        {
            ClientGrid.ItemsSource = Classes.DBContext.context.Client.ToList();
        }

        private void ClientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwimmingPool.Client selectedItem = (SwimmingPool.Client)ClientGrid.SelectedItem;
            if (selectedItem != null)
            {
                
                TBChangeFName.Text = selectedItem.FName;
                TBChangeLName.Text = selectedItem.LName;
                TBChangePatr.Text = selectedItem.Patronymic;
                TBChangePhone.Text = selectedItem.Phone;
                TBChangeEmail.Text = selectedItem.Email;
            }
        }

        private void SaveClient_Click(object sender, RoutedEventArgs e)
        {
            SwimmingPool.Client selectedItem = (Client)ClientGrid.SelectedItem;
            if (selectedItem != null)
            {
                selectedItem.FName = TBChangeFName.Text;
                selectedItem.LName = TBChangeLName.Text;
                selectedItem.Patronymic = TBChangePatr.Text;
                selectedItem.Phone = TBChangePhone.Text;
                selectedItem.Email = TBChangeEmail.Text;
                Classes.DBContext.context.SaveChanges();
            }
            ClientGrid.ItemsSource = DBContext.context.Client.ToList();
        }

        //private void BTNgoShedule_Click(object sender, RoutedEventArgs e)
        //{
        //    ChangeShedule changeShedule = new ChangeShedule();
        //    changeShedule.Show();
        //    Close();
        //}
    }
}
