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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Forme;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public static bool azuriraj;
        public static object pomocni;
        public static bool rbr=false;

        
        public MainWindow()
        {
            frmLogovanje logovanje = new frmLogovanje();
            if (rbr == false)
            {
                InitializeComponent();
               
                logovanje.ShowDialog();
            }

            else 
            {
                //logovanje.Close();
                InitializeComponent();
                
                pocetniEkran.Visibility = Visibility.Visible;
                podaci.Visibility = Visibility.Collapsed;
                dataGridCentralni.Visibility = Visibility.Collapsed;
                btnDodajKartu.Visibility = Visibility.Collapsed;
                btnIzmeniKartu.Visibility = Visibility.Collapsed;
                btnObrisiKartu.Visibility = Visibility.Collapsed;

                btnDodajKorisnika.Visibility = Visibility.Collapsed;
                btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
                btnObrisiKorisnika.Visibility = Visibility.Collapsed;


                btnDodajMarku.Visibility = Visibility.Collapsed;
                btnObrisiMarku.Visibility = Visibility.Collapsed;
                btnIzmeniMarku.Visibility = Visibility.Collapsed;

                btnIzmeniModel.Visibility = Visibility.Collapsed;
                btnObrisiModel.Visibility = Visibility.Collapsed;
                btnDodajModel.Visibility = Visibility.Collapsed;


                btnDodajTip.Visibility = Visibility.Collapsed;
                btnIzmeniTip.Visibility = Visibility.Collapsed;
                btnObrisiTip.Visibility = Visibility.Collapsed;

                btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
                btnDodajPrevoznika.Visibility = Visibility.Collapsed;
                btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

                btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
                btnObrisiRelaciju.Visibility = Visibility.Collapsed;
                btnDodajRelaciju.Visibility = Visibility.Collapsed;

                btnDodajVozaca.Visibility = Visibility.Collapsed;
                btnIzmeniVozaca.Visibility = Visibility.Collapsed;
                btnObrisiVozaca.Visibility = Visibility.Collapsed;

                btnDodajVozilo.Visibility = Visibility.Collapsed;
                btnIzmeniVozilo.Visibility = Visibility.Collapsed;
                btnObrisiVozilo.Visibility = Visibility.Collapsed;
            }
            

            // PocetniDataGrid(dataGridCentralni);
           

        }

        

        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Visible;
            btnIzmeniKartu.Visibility = Visibility.Visible;
            btnObrisiKartu.Visibility = Visibility.Visible;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;
            try
            {
                string upit = "select kartaID as 'Redni broj',brKarte as 'Broj karte', vrsta as 'Vrsta', r.pocetnaStanica + '-' + r.krajnjaStanica as Relacija, " +
                    "ko.ime + ' ' + ko.prezime as Korisnik" +
                    " from Karta k " +
                    "inner join Relacija r on k.relacijaID=r.relacijaID" +
                    " inner join Korisnik ko  on k.korisnikID=ko.korisnikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Karta");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Visible;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                
                frmLogovanje logovanje = new frmLogovanje();
                string upit = "select korisnikID as 'Redni broj', ime as 'Ime', prezime as 'Prezime', jmbg as 'Jmbg', kontakt as 'Kontakt', adresa as 'Adresa', grad as 'Grad' from Korisnik where jmbg ='"+frmLogovanje.jmbgKorisnik +"'";
                Console.WriteLine("Ovo stigne");
                Console.WriteLine(logovanje.txtJmbgKorisnik.Text);
                Console.WriteLine(frmLogovanje.jmbgKorisnik);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Korisnik");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnMarka_Click(object sender, RoutedEventArgs e)
        {

            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            

            btnDodajMarku.Visibility = Visibility.Visible;
            btnObrisiMarku.Visibility = Visibility.Visible;
            btnIzmeniMarku.Visibility = Visibility.Visible;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select markaID as 'Redni broj', naziv as 'Naziv' from MarkaVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("MarkaVozila");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnModel_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Visible;
            btnObrisiModel.Visibility = Visibility.Visible;
            btnDodajModel.Visibility = Visibility.Visible;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;
            konekcija.Open();

            try
            {
                string upit = "select modelID as 'Redni broj', naziv as 'Naziv' from ModelVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("ModelVozila");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }

        }

        private void btnTip_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Visible;
            btnIzmeniTip.Visibility = Visibility.Visible;
            btnObrisiTip.Visibility = Visibility.Visible;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select tipID as 'Redni broj', naziv as 'Naziv' from TipVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("TipVozila");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnPrevoznik_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Visible;
            btnDodajPrevoznika.Visibility = Visibility.Visible;
            btnIzmeniPrevoznika.Visibility = Visibility.Visible;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;
            konekcija.Open();

            try
            {
                string upit = "select prevoznikID as 'Redni broj', grad as 'Grad',naziv as 'Naziv',kontakt as 'Kontakt' from Prevoznik";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Prevoznik");
                dataAdapter.Fill(dt);

                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

       

        private void btnRelacija_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Visible;
            btnObrisiRelaciju.Visibility = Visibility.Visible;
            btnDodajRelaciju.Visibility = Visibility.Visible;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;
            konekcija.Open();

            try
            {
                string upit = "select relacijaID as 'Redni broj', pocetnaStanica as 'Početna stanica',krajnjaStanica as 'Krajnja stanica',km as 'Km',vremePolaska as 'Vreme polaska', vremeDolaska as 'Vreme dolaska'," +
                    "peron as 'Peron',cena as 'Cena',p.naziv as 'Naziv prevoznika'" +
                    " from Relacija r inner join Prevoznik p on r.prevoznikID = p.prevoznikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Relacija");
                dataAdapter.Fill(dt);

                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnVozac_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Visible;
            btnIzmeniVozaca.Visibility = Visibility.Visible;
            btnObrisiVozaca.Visibility = Visibility.Visible;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;
            konekcija.Open();

            try
            {
                string upit = "select vozacID as 'Redni broj',ime as 'Ime',prezime as 'Prezime',jmbg as 'Jmbg',kontakt as 'Kontakt',dozvola as 'Dozvola', adresa as 'Adresa',grad as 'Grad' from Vozac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Vozac");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }

        }

        private void btnVozilo_Click(object sender, RoutedEventArgs e)
        {
            pocetniEkran.Visibility = Visibility.Collapsed;
            podaci.Visibility = Visibility.Visible;
            dataGridCentralni.Visibility = Visibility.Visible;
            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Visible;
            btnIzmeniVozilo.Visibility = Visibility.Visible;
            btnObrisiVozilo.Visibility = Visibility.Visible;
            konekcija.Open();

            try
            {
                string upit = "select voziloID as 'Redni broj', brSasije as 'Broj šasije', kubikaza as 'Kubikaža', konjskaSnaga as 'Konjske snage',brSedista as 'Broj sedišta',nosivost as 'Nosivost',masa as 'Masa',boja as 'Boja', " +
                    "t.naziv as 'Tip', m.naziv as 'Marka', mo.naziv as 'Model', vo.ime + ' ' + vo.prezime as 'Vozač'," +
                    " p.naziv as 'Prevoznik' " +
                    "from Vozilo v " +
                    "inner join TipVozila t on v.tipID=t.tipID " +
                    "inner join MarkaVozila m on m.markaID=v.markaID " +
                    "inner join ModelVozila mo on mo.modelID=v.modelID " +
                    "inner join Vozac vo on v.vozacID=vo.vozacID " +
                    "inner join Prevoznik p on p.prevoznikID=v.prevoznikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Vozilo");
                dataAdapter.Fill(dt);

                dataGridCentralni.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }



        }

        private void btnDodajTip_Click(object sender, RoutedEventArgs e)
        {
            frmTip prozor = new frmTip();
            prozor.ShowDialog();
            string upit = "select tipID as 'Redni broj', naziv as 'Naziv' from TipVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("TipVozila");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniTip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmTip prozor = new frmTip();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from TipVozila where tipID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                   
                    prozor.txtNaziv.Text = citac["naziv"].ToString();
                    prozor.ShowDialog();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }


                btnTip_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiTip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from TipVozila where tipID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete tip?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguće obrisati red.", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnTip_Click(sender, e);
            }
        }

        private void btnDodajMarku_Click(object sender, RoutedEventArgs e)
        {
            frmMarka prozor = new frmMarka();
            prozor.ShowDialog();
            string upit = "select markaID as 'Redni broj', naziv as 'Naziv' from MarkaVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("MarkaVozila");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
            
        }

        private void btnIzmeniMarku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmMarka prozor = new frmMarka();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from MarkaVozila where markaID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    prozor.txtNaziv.Text = citac["naziv"].ToString();

                    prozor.ShowDialog();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }


                btnMarka_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiMarku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from MarkaVozila where markaID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete marku?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguće obrisati red.", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnMarka_Click(sender, e);
            }
        }

        private void btnDodajModel_Click(object sender, RoutedEventArgs e)
        {
            frmModel prozor = new frmModel();
            prozor.ShowDialog();
            string upit = "select modelID as 'Redni broj', naziv as 'Naziv' from ModelVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("ModelVozila");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniModel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmModel prozor = new frmModel();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from ModelVozila where modelID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {

                    prozor.txtNaziv.Text = citac["naziv"].ToString();

                    prozor.ShowDialog();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }


                btnModel_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiModel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from ModelVozila where modelID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete model?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguće obrisati red.", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnModel_Click(sender, e);
            }
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            /*frmKorisnik prozor = new frmKorisnik();
            prozor.ShowDialog();
            string upit = "select korisnikID, ime, prezime, jmbg, kontakt, adresa, grad from Korisnik";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Korisnik");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;*/
        }

        private void btnIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmKorisnik prozor = new frmKorisnik();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from Korisnik where korisnikID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                   
                    prozor.txtImeKorisnik.Text = citac["ime"].ToString();
                    prozor.txtPrezimeKorisnik.Text = citac["prezime"].ToString();
                    prozor.txtJmbgKorisnik.Text = citac["jmbg"].ToString();
                    prozor.txtKontaktKorisnik.Text = citac["kontakt"].ToString();
                    prozor.txtAdresaKorisnik.Text = citac["adresa"].ToString();
                    prozor.txtGradKorisnik.Text = citac["grad"].ToString();

                    prozor.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

                btnKorisnik_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
           /* try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from Korisnik where korisnikID= " + red["korisnikID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Korisnika?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguce obrisati red.", "Obavestenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnKorisnik_Click(sender, e);
            }*/
        }

        private void btnDodajVozaca_Click(object sender, RoutedEventArgs e)
        {
            frmVozac prozor = new frmVozac();

            prozor.ShowDialog();
            string upit = "select vozacID as 'Redni broj',ime as 'Ime',prezime as 'Prezime',jmbg as 'Jmbg',kontakt as 'Kontakt',dozvola as 'Dozvola', adresa as 'Adresa',grad as 'Grad' from Vozac";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Vozac");
            dataAdapter.Fill(dt); 
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniVozaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                azuriraj = true;
                frmVozac prozor = new frmVozac();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from Vozac where vozacID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                  
                    prozor.txtImeVozac.Text = citac["ime"].ToString();
                    prozor.txtPrezimeVozac.Text = citac["prezime"].ToString();
                    prozor.txtJmbgVozac.Text = citac["jmbg"].ToString();
                    prozor.txtKontaktVozac.Text = citac["kontakt"].ToString();
                    prozor.txtVozackaDoz.Text = citac["dozvola"].ToString();
                    prozor.txtAdresaVozac.Text = citac["adresa"].ToString();
                    prozor.txtGradVozac.Text = citac["grad"].ToString();
                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnVozac_Click(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiVozaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from Vozac where vozacID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete vozača?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguće obrisati red!", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnVozac_Click(sender, e);
            }
        }

        private void btnDodajPrevoznika_Click(object sender, RoutedEventArgs e)
        {
            frmPrevoznik prozor = new frmPrevoznik();
            prozor.ShowDialog();
            string upit = "select prevoznikID as 'Redni broj', grad as 'Grad',naziv as 'Naziv',kontakt as 'Kontakt' from Prevoznik";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Prevoznik");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniPrevoznika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmPrevoznik prozor = new frmPrevoznik();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from Prevoznik where prevoznikID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    
                    prozor.txtGrad.Text = citac["grad"].ToString();
                    prozor.txtNaziv.Text = citac["naziv"].ToString();
                    prozor.txtKontakt.Text = citac["kontakt"].ToString();

                    prozor.ShowDialog();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }


                btnPrevoznik_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiPrevoznika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from Prevoznik where prevoznikID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete prevoznika?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguće obrisati red.", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnPrevoznik_Click(sender, e);
            }
        }

        private void btnDodajRelaciju_Click(object sender, RoutedEventArgs e)
        {
            frmRelacija prozor = new frmRelacija();
            prozor.ShowDialog();
            string upit = "select relacijaID as 'Redni broj', pocetnaStanica as 'Početna stanica',krajnjaStanica as 'Krajnja stanica',km as 'Km',vremePolaska as 'Vreme polaska'," +
                    "vremeDolaska as 'Vreme dolaska',peron as 'Peron',cena as 'Cena',p.naziv as 'Naziv prevoznika'" +
                    " from Relacija r inner join Prevoznik p on r.prevoznikID = p.prevoznikID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Relacija");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniRelaciju_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                azuriraj = true;
                frmRelacija prozor = new frmRelacija();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from Relacija where relacijaID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    
                    prozor.txtPocetnaStanica.Text = citac["pocetnaStanica"].ToString();
                    prozor.txtKrajnjaStanica.Text = citac["krajnjaStanica"].ToString();
                    prozor.txtKilometri.Text = citac["km"].ToString();

                    prozor.txtVremePolaska.Text = citac["vremePolaska"].ToString();
                    prozor.txtVremeDolaska.Text = citac["vremeDolaska"].ToString();
                    prozor.txtPeron.Text = citac["peron"].ToString();
                    prozor.txtCena.Text = citac["cena"].ToString();
                    prozor.cbxPrevoznik.SelectedValue = citac["prevoznikID"].ToString();

                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnRelacija_Click(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiRelaciju_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from Relacija where relacijaID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete relaciju?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguće obrisati red.", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnRelacija_Click(sender, e);
            }
        }

        private void btnDodajKartu_Click(object sender, RoutedEventArgs e)
        {
            frmKarta prozor = new frmKarta();
            prozor.ShowDialog();
            string upit = "select kartaID as 'Redni broj',brKarte as 'Broj karte', vrsta as 'Vrsta', r.pocetnaStanica + '-' + r.krajnjaStanica as Relacija," +
                    "ko.ime + ' ' + ko.prezime as Korisnik" +
                    " from Karta k " +
                    "inner join Relacija r on k.relacijaID=r.relacijaID" +
                    " inner join Korisnik ko  on k.korisnikID=ko.korisnikID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Karta");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniKartu_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                azuriraj = true;
                frmKarta prozor = new frmKarta();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from Karta where kartaID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    
                    prozor.txtBrKarte.Text = citac["brKarte"].ToString();
                    prozor.txtVrstaKarte.Text = citac["vrsta"].ToString();
                    prozor.cbxRelacija.SelectedValue = citac["relacijaID"].ToString();
                    prozor.cbxKorisnik.SelectedValue = citac["korisnikID"].ToString();
    
                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnKarta_Click(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiKartu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from Karta where kartaID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete kartu?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli! Nije moguće obrisati red.", "Obaveštenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnKarta_Click(sender, e);
            }
        }

        private void btnDodajVozilo_Click(object sender, RoutedEventArgs e)
        {
            frmVozilo prozor = new frmVozilo();

            prozor.ShowDialog();
            string upit = "select voziloID as 'Redni broj', brSasije as 'Broj šasije', kubikaza as 'Kubikaža', konjskaSnaga as 'Konjske snaga',brSedista as 'Broj sedišta',nosivost as 'Nosivost',masa as 'Masa',boja as 'Boja', " +
                   "t.naziv as 'Tip', m.naziv as 'Marka', mo.naziv as 'Model', vo.ime + ' ' + vo.prezime as 'Vozač'," +
                   " p.naziv as 'Prevoznik' " +
                   "from Vozilo v " +
                   "inner join TipVozila t on v.tipID=t.tipID " +
                   "inner join MarkaVozila m on m.markaID=v.markaID " +
                   "inner join ModelVozila mo on mo.modelID=v.modelID " +
                   "inner join Vozac vo on v.vozacID=vo.vozacID " +
                   "inner join Prevoznik p on p.prevoznikID=v.prevoznikID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Vozilo");
            dataAdapter.Fill(dt);
            
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniVozilo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                azuriraj = true;
                frmVozilo prozor = new frmVozilo();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from Vozilo where voziloID = " + red["Redni broj"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtBrSasije.Text = citac["brSasije"].ToString();
                    prozor.txtKubikaza.Text = citac["kubikaza"].ToString();
                    prozor.txtKonjskeSnage.Text = citac["konjskaSnaga"].ToString();
                    prozor.txtBoja.Text = citac["boja"].ToString();


                    prozor.txtBrSedista.Text = citac["brSedista"].ToString();
                    prozor.txtNosivost.Text = citac["nosivost"].ToString();
                    prozor.txtMasa.Text = citac["masa"].ToString();
                    prozor.cbxTip.SelectedValue = citac["tipID"].ToString();
                    prozor.cbxMarka.SelectedValue = citac["markaID"].ToString();
                    prozor.cbxModel.SelectedValue = citac["modelID"].ToString();
                    prozor.cbxVozac.SelectedValue = citac["vozacID"].ToString();
                    prozor.cbxPrevoznik.SelectedValue = citac["prevoznikID"].ToString();
                    

                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnVozilo_Click(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiVozilo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from Vozilo where voziloID= " + red["Redni broj"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete vozilo?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguce obrisati red.", "Obavestenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnVozilo_Click(sender, e);
            }
        }
    }
}
