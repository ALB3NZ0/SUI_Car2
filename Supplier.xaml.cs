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

    public partial class Supplier : Page
    {


        private SELLS_CAREntities s = new SELLS_CAREntities();

        public Supplier()
        {
            InitializeComponent();
            avto.ItemsSource = s.SUPPLIER.ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            SUPPLIER sup = new SUPPLIER();
            sup.SURNAME = SurnameSupplier.Text;
            sup.SUPPLIER_NAME = NameSupplier.Text;
            sup.PATRONYMIC = PatronymicSupplier.Text;

            s.SUPPLIER.Add(sup);
            s.SaveChanges();
            avto.ItemsSource = s.SUPPLIER.ToList();

        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            if(avto.SelectedItem != null)
            {
                s.SUPPLIER.Remove(avto.SelectedItem as SUPPLIER);
                s.SaveChanges();
                avto.ItemsSource = s.SUPPLIER.ToList();
            }
        }

        private void UpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null) 
            {
                s.SaveChanges();
            }
        }

        private void avto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                var selected = avto.SelectedItem as SUPPLIER;

                selected.SURNAME = SurnameSupplier.Text;
                selected.SUPPLIER_NAME = NameSupplier.Text;
                selected.PATRONYMIC = PatronymicSupplier.Text;

                
                s.SaveChanges();
                avto.ItemsSource = s.SUPPLIER.ToList();
            }
        }
    }
}
