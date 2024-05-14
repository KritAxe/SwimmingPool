using SwimmingPool.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace SwimmingPool.Trainer
{
    /// <summary>
    /// Логика взаимодействия для BrowseShedule.xaml
    /// </summary>
    public partial class BrowseShedule : Window
    {
        public BrowseShedule()
        {
            InitializeComponent();
        }
        private void Shedule_Loaded(object sender, RoutedEventArgs e)
        {
            List<ClassShedule> combinedDataList;
            using (var dbContext = new SwimmingPoolComplexEntities())
            {
                combinedDataList = (from Shedule in DBContext.context.Shedule
                                    join Pools in DBContext.context.Pools on Shedule.IDPool equals Pools.PoolsID
                                    join Sales in DBContext.context.Sales on Shedule.IDSales equals Sales.SalesID
                                    join Client in DBContext.context.Client on Sales.IDClient equals Client.ClientID
                                    join Employee in DBContext.context.Employee on Shedule.IDEmployee equals Employee.EmployeeID
                                    select new ClassShedule
                                    {
                                        NameTrainer = Employee.LName,
                                        NameClient = Client.LName,
                                        NamePool = Pools.TitlePool,
                                        Start = Shedule.StartTime,
                                        End = Shedule.EndTime,
                                        Day = Shedule.DayOfWek
                                    }).ToList();
            }
            var combinedDataCollection = new ObservableCollection<ClassShedule>(combinedDataList);

            Shedulegrid.ItemsSource = combinedDataCollection;
        }
        private void SearhTriner_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTexte = SearhTriner.Text;
            FilterDataTrainer(searchTexte);
        }
        private void FilterDataTrainer(string searchTexte)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Shedulegrid.ItemsSource);
            if (view != null)
            {
                if (!string.IsNullOrEmpty(searchTexte))
                {
                    view.Filter = obj =>
                    {
                        var item = obj as ClassShedule;
                        return item != null && item.NameTrainer.Contains(searchTexte);
                    };
                }
                else
                {
                    view.Filter = null;
                }
            }
        }
        private void SearchClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchClient.Text;
            FilterDataClient(searchText);
        }
        private void FilterDataClient(string searchText)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Shedulegrid.ItemsSource);
            if (view != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    view.Filter = obj =>
                    {
                        var item = obj as ClassShedule;
                        return item != null && item.NameClient.Contains(searchText);
                    };
                }
                else
                {
                    view.Filter = null;
                }
            }
        }
    }
}
