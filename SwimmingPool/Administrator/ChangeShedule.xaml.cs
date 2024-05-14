using SwimmingPool.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SwimmingPool.Administrator
{
    /// <summary>
    /// Логика взаимодействия для ChangeShedule.xaml
    /// </summary>
    public partial class ChangeShedule : Window
    {
        public ChangeShedule()
        {
            InitializeComponent();
        }
    }
}
//        private void Shedule_Load(object sender, RoutedEventArgs e)
//        {
//            List<ClassShedule> combinedDataList;
//            using (var dbContext = new SwimmingPoolComplexEntities())
//            {
//                combinedDataList = (from Shedule in DBContext.context.Shedule
//                                    join Pools in DBContext.context.Pools on Shedule.IDPool equals Pools.PoolsID
//                                    join Sales in DBContext.context.Sales on Shedule.IDSales equals Sales.SalesID
//                                    join Client in DBContext.context.Client on Sales.IDClient equals Client.ClientID
//                                    join Employee in DBContext.context.Employee on Shedule.IDEmployee equals Employee.EmployeeID
//                                    select new ClassShedule
//                                    {
//                                        NameTrainer = Employee.LName,
//                                        NameClient = Client.LName,
//                                        NamePool = Pools.TitlePool,
//                                        Start = Shedule.StartTime,
//                                        End = Shedule.EndTime,
//                                        Day = Shedule.DayOfWek
//                                    }).ToList();
//            }
//            var combinedDataCollection = new ObservableCollection<ClassShedule>(combinedDataList);

//            SheduleGrid.ItemsSource = combinedDataCollection;
//        }
//        private void SheduleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            ClassShedule selectedItem = (ClassShedule)SheduleGrid.SelectedItem;
//            if (selectedItem != null)
//            {
//                //TBTrainer.Text = selectedItem.NameTrainer;
//                //TBClient.Text = selectedItem.NameClient;
//                TBStart.Text = Convert.ToString(selectedItem.Start);
//                TBEnd.Text = Convert.ToString(selectedItem.End);
//            }
//        }

//        private void SaveChange_Click(object sender, RoutedEventArgs e)
//        {
//            using (var dbContext = new SwimmingPoolComplexEntities())
//            {
//                // Перебор всех объектов в коллекции данных вашего класса
//                foreach (var item in shedule)
//                {
//                    // Нахождение соответствующего объекта в базе данных по ID
//                    var scheduleItemInDb = dbContext.Shedule.FirstOrDefault(s => s.SheduleID == item.SheduleID);

//                    // Обновление свойств объекта в базе данных новыми значениями из вашего класса
//                    if (scheduleItemInDb != null)
//                    {
//                        //scheduleItemInDb.LName = item.NameTrainer;
//                        //scheduleItemInDb.LName = item.NameClient;
//                        scheduleItemInDb.StartTime = item.StartTime;
//                        scheduleItemInDb.EndTime = item.EndTime;
//                        //scheduleItemInDb.DayOfWek = item.Day;
//                    }
//                }

//                // Сохранение изменений в базе данных
//                try
//                {
//                    dbContext.SaveChanges();
//                    MessageBox.Show("Изменения сохранены успешно.");
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
//                }
//            }

//            //ClassShedule selectedItem = (ClassShedule)SheduleGrid.SelectedItem;
//            //if (selectedItem != null)
//            //{
//            //    // Проверка корректности введенных данных времени
//            //    TimeSpan startTime, endTime;
//            //    if (!TimeSpan.TryParse(TBStart.Text, out startTime))
//            //    {
//            //        MessageBox.Show("Введите корректное время начала.");
//            //        return;
//            //    }

//            //    if (!TimeSpan.TryParse(TBEnd.Text, out endTime))
//            //    {
//            //        MessageBox.Show("Введите корректное время окончания.");
//            //        return;
//            //    }

//            //    // Обновление данных в базе данных
//            //    using (var dbContext = new SwimmingPoolComplexEntities())
//            //    {
//            //        // Получение объектов клиента и тренера из базы данных по их именам
//            //        //var clientInDb = dbContext.Client.FirstOrDefault(c => c.LName == TBClient.Text);
//            //        //var trainerInDb = dbContext.Employee.FirstOrDefault(t => t.LName == TBTrainer.Text);
//            //        selectedItem.Start = startTime;
//            //        selectedItem.End = endTime;
//            //         dbContext.SaveChanges();
//            // Проверка наличия объектов клиента и тренера в базе данных
//            //if (clientInDb != null && trainerInDb != null)
//            //{
//            //    // Обновление данных в выбранной записи расписания
//            //    //selectedItem.NameClient = clientInDb.LName;
//            //    //selectedItem.NameTrainer = trainerInDb.LName;
//            //    //selectedItem.Start = startTime;
//            //    //selectedItem.End = endTime;

//            //    // Сохранение изменений в базе данных
//            //    try
//            //    {
//            //        dbContext.SaveChanges();
//            //        MessageBox.Show("Изменения сохранены успешно.");
//            //    }
//            //    catch (Exception ex)
//            //    {
//            //        MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
//            //    }
//            //}
//            //else
//            //{
//            //    MessageBox.Show("Клиент или тренер не найден в базе данных.");
//            //    //    }






//            //selectedItem.NameTrainer = TBTrainer.Text;
//            //selectedItem.NameClient = TBClient.Text;
//            //selectedItem.Start = TimeSpan.Parse(TBStart.Text);
//            //selectedItem.End = TimeSpan.Parse(TBEnd.Text);

//            //using (var dbContext = new SwimmingPoolComplexEntities())
//            //{
//            //    // Найдите объект в базе данных
//            //    var scheduleItemInDb = dbContext.Shedule.FirstOrDefault(s => s.SheduleID == selectedItem.SheduleID);

//            //    // Обновите свойства объекта сущности из базы данных новыми значениями
//            //    if (scheduleItemInDb != null)
//            //    {
//            //        //scheduleItemInDb.NameTrainer = selectedItem.NameTrainer;
//            //        //scheduleItemInDb.NameClient = selectedItem.NameClient;
//            //        scheduleItemInDb.StartTime = selectedItem.Start;
//            //        scheduleItemInDb.EndTime = selectedItem.End;

//            //        // Сохраните изменения в базе данных
//            //        dbContext.SaveChanges();
//            //    }
//            //}




//        }
    

//        private void BTNgoClient_Click(object sender, RoutedEventArgs e)
//        {
//            ChangeClient changeClient = new ChangeClient();
//            changeClient.Show();
//            Close();
//        }
//    }
//}
