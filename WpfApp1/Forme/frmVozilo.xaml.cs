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
    /// Interaction logic for frmVozilo.xaml
    /// </summary>
    public partial class frmVozilo : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmVozilo()
        {
            InitializeComponent();
            txtBrSasije.Focus();

            try
            {
                
                //cbxTipVozila
                konekcija.Open();
                string vratiTipVozila = "select tipID, naziv from TipVozila";
                DataTable dtTipVozila = new DataTable();
                SqlDataAdapter daTipVozila = new SqlDataAdapter(vratiTipVozila, konekcija);
                daTipVozila.Fill(dtTipVozila);
                cbxTip.ItemsSource = dtTipVozila.DefaultView;

                //cbxMarkaVozila
                string vratiMarkuVozila = "select markaID, naziv from MarkaVozila";
                DataTable dtMarkaVozila = new DataTable();
                SqlDataAdapter daMarkaVozila = new SqlDataAdapter(vratiMarkuVozila, konekcija);
                daMarkaVozila.Fill(dtMarkaVozila);
                cbxMarka.ItemsSource = dtMarkaVozila.DefaultView;

                //cbxModelVozila

                string vratiModelVozila = "select modelID, naziv from ModelVozila";
                DataTable dtModelVozila = new DataTable();
                SqlDataAdapter daModelVozila = new SqlDataAdapter(vratiModelVozila, konekcija);
                daModelVozila.Fill(dtModelVozila);
                cbxModel.ItemsSource = dtModelVozila.DefaultView;

                //cbxVozac

                string vartiVozaca = "select vozacID, ime + ' ' + prezime + ' ' + kontakt + ' ' + dozvola as Vozac from Vozac";
                DataTable dtVozac = new DataTable();
                SqlDataAdapter daVozac = new SqlDataAdapter(vartiVozaca, konekcija);
                daVozac.Fill(dtVozac);
                cbxVozac.ItemsSource = dtVozac.DefaultView;

                //cbxPrevoznik
                string vratiPrevoznika = "select prevoznikID, naziv from Prevoznik";
                DataTable dtPrevoznik = new DataTable();
                SqlDataAdapter daPrevoznik = new SqlDataAdapter(vratiPrevoznika, konekcija);
                daPrevoznik.Fill(dtPrevoznik);
                cbxPrevoznik.ItemsSource = dtPrevoznik.DefaultView;

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

                    string update = @"Update Vozilo
                                        set brSasije='" + txtBrSasije.Text + "', kubikaza=" + txtKubikaza.Text + " , konjskaSnaga=" + txtKonjskeSnage.Text + ", boja='" + txtBoja.Text + "', brSedista=" + txtBrSedista.Text + ",nosivost=" + txtNosivost.Text + ",masa=" + txtMasa.Text + ", tipID=" + cbxTip.SelectedValue + ", markaID=" + cbxMarka.SelectedValue + ", modelID=" + cbxModel.SelectedValue + ", vozacID=" + cbxVozac.SelectedValue + ", prevoznikID=" + cbxPrevoznik.SelectedValue + " where voziloID = " + red["Redni broj"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into Vozilo(brSasije,kubikaza,konjskaSnaga,boja,brSedista,nosivost,masa,tipID,markaID,modelID,vozacID,prevoznikID)
                values(" + txtBrSasije.Text + "," + txtKubikaza.Text + "," + txtKonjskeSnage.Text + ",'" + txtBoja.Text + "'," + txtBrSedista.Text + "," + txtNosivost.Text + "," + txtMasa.Text + ",'" + cbxTip.SelectedValue + "','" + cbxMarka.SelectedValue + "','" + cbxModel.SelectedValue + "','" + cbxVozac.SelectedValue + "','" + cbxPrevoznik.SelectedValue + "');";
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
