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

namespace CAR_BD2
{
    /// <summary>
    /// Логика взаимодействия для WhereTheCar.xaml
    /// </summary>
    public partial class WhereTheCar : Page
    {

        private SELLS_CAREntities whereTheCar = new SELLS_CAREntities();

        public WhereTheCar()
        {
            InitializeComponent();
            avto.ItemsSource = whereTheCar.WHERE_THE_CAR_COMES_FROM.ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AddWhereTheCar_Click(object sender, RoutedEventArgs e)
        {
            WHERE_THE_CAR_COMES_FROM wtccf = new WHERE_THE_CAR_COMES_FROM();
            wtccf.TITLE = WhereTHECar.Text;


            whereTheCar.WHERE_THE_CAR_COMES_FROM.Add(wtccf);
            whereTheCar.SaveChanges();
            avto.ItemsSource = whereTheCar.WHERE_THE_CAR_COMES_FROM.ToList();
        }

        private void DeleteWhereTheCar_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                whereTheCar.WHERE_THE_CAR_COMES_FROM.Remove(avto.SelectedItem as WHERE_THE_CAR_COMES_FROM);
                whereTheCar.SaveChanges();
                avto.ItemsSource = whereTheCar.WHERE_THE_CAR_COMES_FROM.ToList();
            }
        }

        private void UpdateWhereTheCar_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                whereTheCar.SaveChanges();
            }
        }

        private void avto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                var selected = avto.SelectedItem as WHERE_THE_CAR_COMES_FROM;

                selected.TITLE = WhereTHECar.Text;



                whereTheCar.SaveChanges();
                avto.ItemsSource = whereTheCar.WHERE_THE_CAR_COMES_FROM.ToList();
            }
        }
    }
}
