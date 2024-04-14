using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Avto.xaml
    /// </summary>
    public partial class Avto : Page
    {

        private SELLS_CAREntities avtO = new SELLS_CAREntities();
        public Avto()
        {
            InitializeComponent();
            avto.ItemsSource = avtO.CAR.ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            CAR car = new CAR();

            car.NAME_CAR = NameСar.Text;
            car.MODEL_CAR = ModelСar.Text;
            car.COLOR_CAR = ColorCar.Text;
            car.NUMBER_CAR = NumberCar.Text;


            avtO.CAR.Add(car);
            avtO.SaveChanges();
            avto.ItemsSource = avtO.CAR.ToList();
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                avtO.CAR.Remove(avto.SelectedItem as CAR);
                avtO.SaveChanges();
                avto.ItemsSource = avtO.CAR.ToList();
            }
        }

        private void UpdateCar_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                avtO.SaveChanges();
            }
        }

        private void avto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                var selected = avto.SelectedItem as CAR;


                selected.NAME_CAR = NameСar.Text;
                selected.MODEL_CAR = ModelСar.Text;
                selected.COLOR_CAR = ColorCar.Text;
                selected.NUMBER_CAR = NumberCar.Text;


                avtO.SaveChanges();
                avto.ItemsSource = avtO.CAR.ToList();
            }
        }

    }
}
