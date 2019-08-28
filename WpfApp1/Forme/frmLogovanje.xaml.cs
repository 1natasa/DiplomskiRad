using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public  static string jmbgKorisnik="";
        public frmLogovanje()
        {
           
            InitializeComponent();
        }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                konekcija.Open();
                string upit = "select * from Korisnik where ime = '" + txtImeKorisnik.Text.Trim() + "' and prezime = '" + txtPrezimeKorisnik.Text.Trim() + "' and jmbg = '" + txtJmbgKorisnik.Text.Trim() + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                jmbgKorisnik = txtJmbgKorisnik.Text.Trim();
                Console.WriteLine("LOGOVANJE");
                Console.WriteLine(jmbgKorisnik);

                if (dt.Rows.Count == 1)
                {
                    MainWindow.rbr = true;
                    MainWindow prozor = new MainWindow();
                    this.Close();
                    prozor.ShowDialog();
                 
                }
                else
                {
                    
                    if (txtImeKorisnik.Text == "")
                    {
                        MessageBox.Show("Niste uneli ime!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (txtPrezimeKorisnik.Text == "")
                        MessageBox.Show("Niste uneli prezime!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    else if (txtJmbgKorisnik.Text == "")
                        MessageBox.Show("Niste uneli jmbg!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                         
                        MessageBox.Show("Podaci nisu validni!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch {

                MessageBox.Show("Korisnik ne postoji!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnRegistrujSe_Click(object sender, RoutedEventArgs e)
        {
            frmRegistracija prozor = new frmRegistracija();
            prozor.ShowDialog();
        }

        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseApp_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
