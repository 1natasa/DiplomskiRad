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
    /// Interaction logic for frmMarka.xaml
    /// </summary>
    public partial class frmMarka : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmMarka()
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

                    string update = @"Update MarkaVozila
                                        set naziv='" + txtNaziv.Text + "' where markaID = " + red["Redni broj"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    if (txtNaziv.Text == "")
                    {

                        MessageBox.Show("Unos određenih podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        string insert = @"insert into MarkaVozila(naziv)
                values('" + txtNaziv.Text + "');";
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
