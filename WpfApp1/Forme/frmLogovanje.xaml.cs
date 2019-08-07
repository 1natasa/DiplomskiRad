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
using System.Windows.Shapes;

namespace WpfApp1.Forme
{
    /// <summary>
    /// Interaction logic for frmLogovanje.xaml
    /// </summary>
    public partial class frmLogovanje : Window
    {
        public frmLogovanje()
        {
           
            InitializeComponent();
        }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.rbr = true;
            MainWindow prozor = new MainWindow();
            this.Close();
            prozor.ShowDialog();
        }

        private void btnRegistrujSe_Click(object sender, RoutedEventArgs e)
        {
            frmRegistracija prozor = new frmRegistracija();
            prozor.ShowDialog();
        }
    }
}
