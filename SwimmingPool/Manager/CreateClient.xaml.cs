using SwimmingPool.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        public CreateClient()
        {
            InitializeComponent();
            //GetList();
            CMBGender.ItemsSource = Classes.DBContext.context.Gender.ToList();
            CMBGender.DisplayMemberPath = "Title";
            CMBGender.SelectedIndex = 0;

            CMBType.ItemsSource = Classes.DBContext.context.SubscriptionTypes.ToList();
            CMBType.DisplayMemberPath = "TitleType";
            CMBType.SelectedIndex = 0;

            CMBDuration.ItemsSource = Classes.DBContext.context.SubscriptionDuration.ToList();
            CMBDuration.DisplayMemberPath = "Duration";
            CMBDuration.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClientGrid.ItemsSource = Classes.DBContext.context.Client.ToList();
        }
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text;
            FilterData(searchText);
        }
        private void FilterData(string searchText)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ClientGrid.ItemsSource);
            if (view != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    view.Filter = obj =>
                    {
                        var item = obj as Client;
                        return item != null && item.LName.Contains(searchText);
                    };
                }
                else
                {
                    view.Filter = null;
                }
            }
        }
        private void AddClient(object sender, RoutedEventArgs e)
        {
            SwimmingPool.Client newClient = new SwimmingPool.Client();
            newClient.FName = TBFName.Text;
            newClient.LName = TBLName.Text;
            newClient.Patronymic = TBPatronymic.Text;
            newClient.BirthDay = Convert.ToDateTime(TBBirthDay.Text);
            newClient.Phone = TBPhone.Text;
            newClient.Gender = (CMBGender.SelectedItem as SwimmingPool.Gender);
            newClient.Email = TBEmail.Text;
            newClient.RegistartionDate = DateTime.Now;

            DBContext.context.Client.Add(newClient);
            DBContext.context.SaveChanges();
            ClientGrid.ItemsSource = DBContext.context.Client.ToList();
            MessageBox.Show("Клиент добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BTNPay_Click(object sender, RoutedEventArgs e)
        {
            Sales newSales = new Sales();
            newSales.SaleDate = DateTime.Now;
            newSales.IDClient = Convert.ToInt32(TBClient.Text);
            newSales.IDEmployee = 1;

            int selectedDuratId = (CMBDuration.SelectedItem as SubscriptionDuration)?.DurationID ?? -1;
            int selectedTitleTypeId = (CMBType.SelectedItem as SubscriptionTypes)?.TypeID ?? -1;
            int? subscriptionId = null;
            using (var dbContext = new SwimmingPoolComplexEntities())
            {
                var subscription = dbContext.Subscription.FirstOrDefault(s => s.IDDuration == selectedDuratId && s.IDType == selectedTitleTypeId);
                if (subscription != null)
                {
                    subscriptionId = subscription.SubscriptionID;
                }
            }
            newSales.IDSubscription = Convert.ToInt32(subscriptionId);

            DBContext.context.Sales.Add(newSales);
            DBContext.context.SaveChanges();
            MessageBox.Show("Абонемент продан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
