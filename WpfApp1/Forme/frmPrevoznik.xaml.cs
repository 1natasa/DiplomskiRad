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
    /// Interaction logic for frmPrevoznik.xaml
    /// </summary>
    public partial class frmPrevoznik : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmPrevoznik()
        {
            InitializeComponent();
            txtNaziv.Focus();
        }


        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuriraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update Prevoznik
                                        set grad='" + txtGrad.Text + "', naziv='" + txtNaziv.Text + "', kontakt='" + txtKontakt.Text + "'  where prevoznikID = " + red["Redni broj"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    if (txtGrad.Text == "")
                    {

                        MessageBox.Show("Unos određenih podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (txtKontakt.Text == "")
                    {

                        MessageBox.Show("Unos određenih podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (txtNaziv.Text == "")
                    {

                        MessageBox.Show("Unos određenih podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        string insert = @"insert into Prevoznik(grad,naziv,kontakt)
                values('" + txtGrad.Text + "','" + txtNaziv.Text + "','" + txtKontakt.Text + "');";
                        SqlCommand cmd = new SqlCommand(insert, konekcija);
                        cmd.ExecuteNonQuery();
                        this.Close();
                    }
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
