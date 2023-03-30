using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для P.xaml
    /// </summary>
    public partial class P : Window
    {
       
        public string clos;
        ProdyktTableAdapter prodykt = new ProdyktTableAdapter();
        public P()
        {
            InitializeComponent();
            GridProd.ItemsSource = prodykt.GetData();

            Box_idK.ItemsSource= prodykt.GetData();
            Box_idK.DisplayMemberPath = "Klient_id";

            Box_idP.ItemsSource= prodykt.GetData();
            Box_idP.DisplayMemberPath = "Proizvodite_id";
           

        }

        private void Creat_p_k_Click(object sender, RoutedEventArgs e)
        {

            int p_id =  Convert.ToInt32(Box_idP.Text);
            int klient_id_= Convert.ToInt32(Box_idK.Text);
            prodykt.InsertQueryProd(p_id,klient_id_);
            GridProd.ItemsSource = prodykt.GetData();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            clos = "Закрыть";
            DialogResult = true;
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            object dell = (GridProd.SelectedItem as DataRowView).Row[0];
            prodykt.DeleteQueryP(Convert.ToInt32(dell));
            GridProd.ItemsSource = prodykt.GetData();
        }

        private void c_Click(object sender, RoutedEventArgs e)
        {
            object c = (GridProd.SelectedItem as DataRowView).Row[0];
            int Pid = Convert.ToInt32(Box_idP.Text);
            int klientid = Convert.ToInt32(Box_idK.Text);
            prodykt.UpdateQueryC(klientid, Pid,Convert.ToInt32(c));
            GridProd.ItemsSource = prodykt.GetData();
        }

        private void GridProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridProd.SelectedItem as DataRowView) != null)
            {
                Box_idP.Text = (GridProd.SelectedItem as DataRowView).Row[1].ToString();
                Box_idK.Text = (GridProd.SelectedItem as DataRowView).Row[2].ToString();
            }
            
        }
    }
}
