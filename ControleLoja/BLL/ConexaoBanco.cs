using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControleLoja.ConexaoBanco
{
    class ConexaoBanco
    {

            SqlConnection con = new SqlConnection();

            public ConexaoBanco()
            {
                con.ConnectionString = "Server = localhost\\SQLEXPRESS; Database = ControleLoja; Trusted_Connection = True; Encrypt=False;";         
            }

            public SqlConnection Conectar()
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }

            public SqlConnection Desconectar()
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return con;
            }

    }

}
