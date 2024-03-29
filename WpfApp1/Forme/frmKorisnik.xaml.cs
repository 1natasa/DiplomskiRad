﻿using System;
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
    /// Interaction logic for frmKorisnik.xaml
    /// </summary>
    public partial class frmKorisnik : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnik.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {

                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update Korisnik
                                        set ime='" + txtImeKorisnik.Text + "', prezime='" + txtPrezimeKorisnik.Text + "' , jmbg='" + txtJmbgKorisnik.Text + "', kontakt='" + txtKontaktKorisnik.Text + "', adresa='" + txtAdresaKorisnik.Text + "', grad='" + txtGradKorisnik.Text + "' where korisnikID = " + red["Redni broj"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    
                    string insert = @"insert into Korisnik(ime,prezime,jmbg,kontakt,adresa,grad)
                values('" + txtImeKorisnik.Text + "','" + txtPrezimeKorisnik.Text + "','" + txtJmbgKorisnik.Text + "','" + txtKontaktKorisnik.Text + "','" + txtAdresaKorisnik.Text + "','" + txtGradKorisnik.Text + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
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
