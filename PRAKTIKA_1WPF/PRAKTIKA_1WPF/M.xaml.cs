using System;
using System.Collections.Generic;
using System.Data;
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
using PRAKTIKA_1WPF.megezDataSet1TableAdapters;

namespace PRAKTIKA_1WPF
{
    /// <summary>
    /// Логика взаимодействия для M.xaml
    /// </summary>
    public partial class M : Window
    {
        public string close;
        ProizvoditeTableAdapter Proizvodit = new ProizvoditeTableAdapter();

        public M()
        {
            InitializeComponent();
            GridP.ItemsSource = Proizvodit.GetData();

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            close = "Закрыть";
            DialogResult = true;
        }

        private void CreatP_Click(object sender, RoutedEventArgs e)
        {
            Proizvodit.InsertQueryP(Adres.Text, Munifaktyr.Text);
            GridP.ItemsSource = Proizvodit.GetData();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            object deli = (GridP.SelectedItem as DataRowView).Row[0];
            Proizvodit.DeleteQuery(Convert.ToInt32(deli));
            GridP.ItemsSource = Proizvodit.GetData();
        }

        private void chang_Click(object sender, RoutedEventArgs e)
        {
            object chan = (GridP.SelectedItem as DataRowView).Row[0];
            Proizvodit.ChangQuery(Adres.Text, Munifaktyr.Text,Convert.ToInt32(chan));
            GridP.ItemsSource = Proizvodit.GetData();
        }

        private void GridP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridP.SelectedItem as DataRowView) != null)
            {
                Adres.Text = (GridP.SelectedItem as DataRowView).Row[1].ToString();
                Munifaktyr.Text = (GridP.SelectedItem as DataRowView).Row[2].ToString();
            }
        

        }
    }
}
