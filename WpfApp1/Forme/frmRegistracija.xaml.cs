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
    /// Interaction logic for frmRegistracija.xaml
    /// </summary>
    public partial class frmRegistracija : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmRegistracija()
        {
            InitializeComponent();
            txtImeKorisnik.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                //frmRegistracija frmRegistracija = new frmRegistracija();
                if (txtImeKorisnik.Text == "")
                {
                    MessageBox.Show("Niste uneli ime!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtPrezimeKorisnik.Text == "")
                {
                    MessageBox.Show("Niste uneli prezime!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtJmbgKorisnik.Text == "")
                {
                    MessageBox.Show("Niste uneli jmbg!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtJmbgKorisnik.Text.Length != 13)
                {
                    MessageBox.Show("Jmbg mora da ima 13 cifara!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                } else if (txtJmbgKorisnik.Text != txtPonovoJmbgKorisnik.Text)
                {
                    MessageBox.Show("Jmbg se ne poklapaju!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtKontaktKorisnik.Text == "")
                {
                    MessageBox.Show("Niste uneli kontakt!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtKontaktKorisnik.Text.Length < 6 || txtKontaktKorisnik.Text.Length > 10)
                {
                    MessageBox.Show("Kontakt mora da bude duži od 6 i kraći od 11 cifara!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtAdresaKorisnik.Text == "")
                {
                    MessageBox.Show("Niste uneli adresu!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtGradKorisnik.Text == "")
                {
                    MessageBox.Show("Niste uneli grad!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string insert = @"insert into Korisnik(ime,prezime,jmbg,kontakt,adresa,grad)
                values('" + txtImeKorisnik.Text + "','" + txtPrezimeKorisnik.Text + "','" + txtJmbgKorisnik.Text + "','" + txtKontaktKorisnik.Text + "','" + txtAdresaKorisnik.Text + "','" + txtGradKorisnik.Text + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                    MessageBox.Show("Korisnik je uspešno registrovan!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Unos određenih podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
               
            }

             //
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }
    }
}
