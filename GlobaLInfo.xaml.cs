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
    /// Логика взаимодействия для GlobaLInfo.xaml
    /// </summary>
    public partial class GlobaLInfo : Page
    {


        private SELLS_CAREntities globalInfo = new SELLS_CAREntities();

        public GlobaLInfo()
        {
            InitializeComponent();
            avto.ItemsSource = globalInfo.GLOBAL_INFO.ToList();



            CAR_IDComboBox.ItemsSource = globalInfo.CAR.ToList();
            CAR_IDComboBox.DisplayMemberPath = "ID_CARNAME";

            WHERE_IDComboBox.ItemsSource = globalInfo.WHERE_THE_CAR_COMES_FROM.ToList();
            WHERE_IDComboBox.DisplayMemberPath = "ID_WHERE_THE_CAR_COMES_FROM";

            SUPPLIER_IDComboBox.ItemsSource = globalInfo.SUPPLIER.ToList();
            SUPPLIER_IDComboBox.DisplayMemberPath = "ID_SUPPLIER";


        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AddID_Click(object sender, RoutedEventArgs e)
        {
            GLOBAL_INFO globl = new GLOBAL_INFO();

            globl.CARNAME_ID = int.Parse(CAR_IDComboBox.Text);
            globl.WHERE_THE_CAR_COMES_FROM_ID = int.Parse(WHERE_IDComboBox.Text);
            globl.SUPPLIER_ID = int.Parse(SUPPLIER_IDComboBox.Text);


            globalInfo.GLOBAL_INFO.Add(globl);
            globalInfo.SaveChanges();
            avto.ItemsSource = globalInfo.GLOBAL_INFO.ToList();
        }

        private void DeleteIDr_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                globalInfo.GLOBAL_INFO.Remove(avto.SelectedItem as GLOBAL_INFO);
                globalInfo.SaveChanges();
                avto.ItemsSource = globalInfo.GLOBAL_INFO.ToList();
            }
        }

        private void UpdateID_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                globalInfo.SaveChanges();
            }
        }

        private void CAR_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CAR_IDComboBox.SelectedItem != null)
            {
                var selected = CAR_IDComboBox.SelectedItem as CAR;
                MessageBox.Show(selected.NAME_CAR);
            }
        }

        private void WHERE_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WHERE_IDComboBox.SelectedItem != null)
            {
                var selected = WHERE_IDComboBox.SelectedItem as WHERE_THE_CAR_COMES_FROM;
                MessageBox.Show(selected.TITLE);
            }
        }

        private void SUPPLIER_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SUPPLIER_IDComboBox.SelectedItem != null)
            {
                var selected = SUPPLIER_IDComboBox.SelectedItem as SUPPLIER;
                MessageBox.Show(selected.SURNAME);
            }  
        }
    }
}
