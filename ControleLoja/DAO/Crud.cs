using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ControleLoja.DAO
{
    public class Crud
    {
        

        ConexaoBanco.ConexaoBanco conexaoBanco = new ConexaoBanco.ConexaoBanco();
        SqlCommand cmd = new SqlCommand();



        string msg = string.Empty;



        public bool AdicionarProduto() {

            cmd.CommandText = " ";

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                cmd.ExecuteNonQuery();
                conexaoBanco.Desconectar();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return false;
           
        }


        public DataTable SelectTeste()
        {

            SqlDataAdapter sqa = new SqlDataAdapter(cmd);

            // Comando Sql

            cmd.CommandText = "Select * from Usuarios";

            //Parametros
            /* Ex cmd.Parameters.AddWithValue("@codigo", codigo); */

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                DataTable Usuarios = new DataTable();
                sqa.Fill(Usuarios);
                conexaoBanco.Desconectar();
                return Usuarios;
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;


        }


    }
}
