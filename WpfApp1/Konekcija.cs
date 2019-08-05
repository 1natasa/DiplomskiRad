using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace WpfApp1
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder();

            ccnSb.DataSource = @"DESKTOP-2NK7KM6\SQLEXPRESS";
            ccnSb.InitialCatalog = @"AutobuskaStanica";
            ccnSb.IntegratedSecurity = true;

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);

            return konekcija;
        }
    }
}
