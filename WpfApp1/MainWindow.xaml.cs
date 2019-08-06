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

        public MainWindow()
        {
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
           // PocetniDataGrid(dataGridCentralni);
           //

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
                string upit = "select kartaID,brKarte as 'broj karte', vrsta, r.pocetnaStanica + '-' + r.krajnjaStanica as relacija, " +
                    "ko.ime + ' ' + ko.prezime as korisnik" +
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

            btnDodajKorisnika.Visibility = Visibility.Visible;
            btnIzmeniKorisnika.Visibility = Visibility.Visible;
            btnObrisiKorisnika.Visibility = Visibility.Visible;

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
                string upit = "select korisnikID, ime, prezime, jmbg, kontakt, adresa, grad from Korisnik";
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
                string upit = "select markaID, naziv from MarkaVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("MarkaVozila");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
                string upit = "select modelID, naziv from ModelVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("ModelVozila");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
                string upit = "select tipID, naziv from TipVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("TipVozila");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
                string upit = "select prevoznikID, grad,naziv,kontakt from Prevoznik";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Prevoznik");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
                string upit = "select relacijaID, pocetnaStanica as 'pocetna stanica',KrajnjaStanica as 'krajnja stanica',km,vremePolaska as 'vreme polaska', vremeDolaska as 'vreme dolaska'," +
                    "peron,cena,p.naziv" +
                    " from Relacija r inner join Prevoznik p on r.prevoznikID = p.prevoznikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Relacija");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
                string upit = "select vozacID,ime,prezime,jmbg,kontakt,dozvola, adresa,grad from Vozac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Vozac");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
                string upit = "select voziloID, brSasije as 'broj sasije', kubikaza, konjskaSnaga as 'konjske snage',brSedista as 'broj sedista',nosivost,masa,boja, " +
                    "t.naziv as tip, m.naziv as marka, mo.naziv as model, vo.ime + ' ' + vo.prezime as vozac," +
                    " p.naziv as prevoznik " +
                    "from Vozilo v " +
                    "inner join TipVozila t on v.tipID=t.tipID " +
                    "inner join MarkaVozila m on m.markaID=v.markaID " +
                    "inner join ModelVozila mo on mo.modelID=v.modelID " +
                    "inner join Vozac vo on v.vozacID=vo.vozacID " +
                    "inner join Prevoznik p on p.prevoznikID=v.prevoznikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Vozilo");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
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
            string upit = "select tipID, naziv from TipVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("TipVozila");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
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
                string upit = "select * from TipVozila where tipID = " + red["tipID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtNaziv.Text = citac["naziv"].ToString();



                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

                //dodati jos ostali deo koda!!!
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red!", "Obavestenje");

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
                string upit = "Delete from TipVozila where tipID= " + red["tipID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite selektovan podatak?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obavestenje");


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
                btnTip_Click(sender, e);
            }
        }

        private void btnDodajMarku_Click(object sender, RoutedEventArgs e)
        {
            frmMarka prozor = new frmMarka();
            prozor.ShowDialog();
            string upit = "select markaID, naziv from MarkaVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("MarkaVozila");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;
            //PocetniDataGrid(dataGridCentralni);
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
                string upit = "select * from MarkaVozila where markaID = " + red["markaID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtNaziv.Text = citac["naziv"].ToString();



                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

                //dodati jos ostali deo koda!!!
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");

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
                string upit = "Delete from MarkaVozila where markaID= " + red["markaID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Marku?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnMarka_Click(sender, e);
            }
        }

        private void btnDodajModel_Click(object sender, RoutedEventArgs e)
        {
            frmModel prozor = new frmModel();
            prozor.ShowDialog();
            string upit = "select modelID, naziv from ModelVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("ModelVozila");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
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
                string upit = "select * from ModelVozila where modelID = " + red["modelID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtNaziv.Text = citac["naziv"].ToString();



                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

                //dodati jos ostali deo koda!!!
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");

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
                string upit = "Delete from ModelVozila where modelID= " + red["modelID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Model?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnModel_Click(sender, e);
            }
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            frmKorisnik prozor = new frmKorisnik();
            prozor.ShowDialog();
            string upit = "select korisnikID, ime, prezime, jmbg, kontakt, adresa, grad from Korisnik";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Korisnik");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
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
                string upit = "select * from Korisnik where korisnikID = " + red["korisnikID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtImeKorisnik.Text = citac["ime"].ToString();
                    prozor.txtPrezimeKorisnik.Text = citac["prezime"].ToString();
                    prozor.txtJmbgKorisnik.Text = citac["jmbg"].ToString();
                    prozor.txtKontaktKorisnik.Text = citac["kontakt"].ToString();
                    prozor.txtAdresaKorisnik.Text = citac["adresa"].ToString();
                    prozor.txtGradKorisnik.Text = citac["grad"].ToString();
                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

                //dodati jos ostali deo koda!!!
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");

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
            try
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
            }
        }

        private void btnDodajVozaca_Click(object sender, RoutedEventArgs e)
        {
            frmVozac prozor = new frmVozac();

            prozor.ShowDialog();
            string upit = "select vozacID,ime,prezime,jmbg,kontakt,dozvola, adresa,grad from Vozac";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Vozac");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
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
                string upit = "select * from Vozac where vozacID = " + red["vozacID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtImeVozac.Text = citac["ime"].ToString();
                    prozor.txtPrezimeVozac.Text = citac["prezime"].ToString();
                    prozor.txtJmbgVozac.Text = citac["jmbg"].ToString();
                    prozor.txtKontaktVozac.Text = citac["kontakt"].ToString();


                    prozor.txtVozackaDoz.Text = citac["dozvola"].ToString();
                    prozor.txtAdresaVozac.Text = citac["adresa"].ToString();
                    prozor.txtGradVozac.Text = citac["grad"].ToString();
                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");
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
                string upit = "Delete from Vozac where vozacID= " + red["vozacID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Vozaca?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnVozac_Click(sender, e);
            }
        }

        private void btnDodajPrevoznika_Click(object sender, RoutedEventArgs e)
        {
            frmPrevoznik prozor = new frmPrevoznik();
            prozor.ShowDialog();
            string upit = "select prevoznikID, grad,naziv,kontakt from Prevoznik";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Prevoznik");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
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
                string upit = "select * from Prevoznik where prevoznikID = " + red["prevoznikID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtGrad.Text = citac["grad"].ToString();
                    prozor.txtNaziv.Text = citac["naziv"].ToString();
                    prozor.txtKontakt.Text = citac["kontakt"].ToString();



                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

                //dodati jos ostali deo koda!!!
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");

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
                string upit = "Delete from Prevoznik where prevoznikID= " + red["prevoznikID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Prevoznika?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnPrevoznik_Click(sender, e);
            }
        }

        private void btnDodajRelaciju_Click(object sender, RoutedEventArgs e)
        {
            frmRelacija prozor = new frmRelacija();
            prozor.ShowDialog();
            string upit = "select relacijaID, pocetnaStanica as 'pocetna stanica',KrajnjaStanica as 'krajnja stanica',km,vremePolaska as 'vreme polaska'," +
                    "vremeDolaska as 'vreme dolaska',peron,cena,p.naziv" +
                    " from Relacija r inner join Prevoznik p on r.prevoznikID = p.prevoznikID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Relacija");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
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
                string upit = "select * from Relacija where relacijaID = " + red["relacijaID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtPocetnaStanica.Text = citac["pocetnaStanica"].ToString();
                    prozor.txtKrajnjaStanica.Text = citac["krajnjaStanica"].ToString();
                    prozor.txtKilometri.Text = citac["km"].ToString();

                    prozor.txtVremePolaska.Text = citac["vremePolaska"].ToString();
                    prozor.txtVremeDolaska.Text = citac["vremeDolaska"].ToString();
                    prozor.txtPeron.Text = citac["peron"].ToString();
                    prozor.txtCena.Text = citac["cena"].ToString();
                    prozor.cbxPrevoznik.SelectedValue = citac["prevoznikID"].ToString();
                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");
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
                string upit = "Delete from Relacija where relacijaID= " + red["relacijaID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Relaciju?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnRelacija_Click(sender, e);
            }
        }

        private void btnDodajKartu_Click(object sender, RoutedEventArgs e)
        {
            frmKarta prozor = new frmKarta();
            prozor.ShowDialog();
            string upit = "select kartaID,brKarte as 'broj karte', vrsta, r.pocetnaStanica + '-' + r.krajnjaStanica as relacija," +
                    "ko.ime + ' ' + ko.prezime as korisnik" +
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
                string upit = "select * from Karta where kartaID = " + red["kartaID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    //podaci iz baze
                    prozor.txtBrKarte.Text = citac["brKarte"].ToString();
                    prozor.txtVrstaKarte.Text = citac["vrsta"].ToString();
                    prozor.cbxRelacija.SelectedValue = citac["relacijaID"].ToString();
                    prozor.cbxKorisnik.SelectedValue = citac["korisnikID"].ToString();
                   
                    //fali za strane kljuceve

                    prozor.ShowDialog();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");
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
                string upit = "Delete from Karta where kartaID= " + red["kartaID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Kartu?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnKarta_Click(sender, e);
            }
        }
    }
}
