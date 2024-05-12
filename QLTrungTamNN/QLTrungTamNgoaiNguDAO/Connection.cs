using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLTrungTamNN.QLTrungTamNgoaiNguDAO
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=SC-202205200840\SQLEXPRESS;Initial Catalog=QuanLyTrungTamNgoaiNgu;Integrated Security=True;Encrypt=False";
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(stringConnection);
            return conn;
        }
        public static SqlDataReader truyVanDuLieu(string strTruyVan, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strTruyVan, conn);
            SqlDataReader reader = com.ExecuteReader();
            return reader;
        }
        public static SqlDataReader truyVanDuLieu(string strTruyVan, SqlParameter[] param, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strTruyVan, conn);
            com.Parameters.AddRange(param);
            SqlDataReader reader = com.ExecuteReader();
            return reader;
        }
        public static int thayDoiDuLieu(string strTruyVan, SqlParameter[] param, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strTruyVan, conn);
            com.Parameters.AddRange(param);
            conn.Open();
            int rowsAffected = com.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
        }
    }
}
