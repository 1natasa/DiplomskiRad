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
    /// Interaction logic for frmKarta.xaml
    /// </summary>
    public partial class frmKarta : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmKarta()
        {
            InitializeComponent();
            txtBrKarte.Focus();

            try
            {

                //cbxRelacija
                konekcija.Open();
                string vratiRelaciju = "select relacijaID, pocetnaStanica + '-' + krajnjaStanica as Relacija, peron, cena  from Relacija";
                DataTable dtRelacija = new DataTable();
                SqlDataAdapter daKarta = new SqlDataAdapter(vratiRelaciju, konekcija);
                daKarta.Fill(dtRelacija);
                cbxRelacija.ItemsSource = dtRelacija.DefaultView;

                //cbxKorisnik
                frmLogovanje frmLogovanje = new frmLogovanje();
                string vratiKorisnika = "select korisnikID, ime + ' ' + prezime as Korisnik from Korisnik where jmbg = '" + frmLogovanje.jmbgKorisnik + "'";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                daKorisnik.Fill(dtKorisnik);
                cbxKorisnik.ItemsSource = dtKorisnik.DefaultView;


            }

            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuriraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update Karta
                                        set brKarte='" + txtBrKarte.Text + "', vrsta='" + txtVrstaKarte.Text + "' , relacijaID=" + cbxRelacija.SelectedValue + ", korisnikID=" + cbxKorisnik.SelectedValue + " where kartaID = " + red["Redni broj"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into Karta(brKarte,vrsta,relacijaID,korisnikID)
                    values(" + txtBrKarte.Text + ",'" + txtVrstaKarte.Text + "','" + cbxRelacija.SelectedValue + "','" + cbxKorisnik.SelectedValue + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
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
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
    }
}
