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
using PRAKTIKA_1WPF.megezDataSet1TableAdapters;

namespace PRAKTIKA_1WPF
{
    /// <summary>
    /// Логика взаимодействия для ProizvoditePage.xaml
    /// </summary>
    public partial class ProizvoditePage : Page
    {
        ProizvoditeTableAdapter Proizvod = new ProizvoditeTableAdapter();

        public ProizvoditePage()
        {
            InitializeComponent();
            GridPro.ItemsSource = Proizvod.GetData();

        }

       
    }
}
