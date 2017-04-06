using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public string dataSource = "Data Source=DESKTOP-MV2TBFL\\SQLEXPRESS;Initial Catalog=IMPRENTA-LIBERIA;Integrated Security=true;";

        
        public void connection()
        {
            this.con = new SqlConnection();
            this.con.ConnectionString = dataSource;
        } 

        public bool executeQuery(string query)
        {
            connection();
            SqlCommand cmd = new SqlCommand(query, this.con);
            try
            {
                this.con.Open();
                int result = cmd.ExecuteNonQuery();
                this.con.Close();
                return Convert.ToBoolean(result);
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public DataTable executeReadQuery(string query)
        {
            connection();
            SqlCommand cmd = new SqlCommand(query, this.con);
            this.con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.con.Close();
                return dt;
            }
            catch (SqlException e)
            {
                return null;
            }
        }
        
    }
}
