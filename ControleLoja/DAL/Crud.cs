using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ControleLoja.ConexaoBanco.Entity;



namespace ControleLoja.DAO
{
    public class Crud
    {


        ConexaoBanco.ConexaoBanco conexaoBanco = new ConexaoBanco.ConexaoBanco();
        SqlCommand cmd = new SqlCommand();
        string msg = string.Empty;

        public bool CadastrarProduto(string Nome, string Classe, decimal PrecoCusto, decimal PrecoVenda, DateTime DataCadastro, bool Status)
        {




            cmd.CommandText = "insert into Produtos(Nome, Classe, PrecoCusto, PrecoVenda, DataCadastro, Status)" +
                              "values(@Nome, @Classe, @PrecoCusto, @PrecoVenda, @DataCadastro, @Status)";

            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("Classe", Classe);
            cmd.Parameters.AddWithValue("PrecoCusto", PrecoCusto);
            cmd.Parameters.AddWithValue("PrecoVenda", PrecoVenda);
            cmd.Parameters.AddWithValue("@DataCadastro", DataCadastro);
            cmd.Parameters.AddWithValue("Status", Status);

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                cmd.ExecuteNonQuery();               
                msg = "Produto Cadastrado!";
                return true;
            }
            catch (Exception e)
            {
                msg = "Erro ao cadastrar Produto!";
                throw e;
            }
            finally { conexaoBanco.Desconectar(); }

            }


        public DataTable SelectTeste()
        {

            SqlDataAdapter sqa = new SqlDataAdapter(cmd);

            cmd.CommandText = "Select * from Usuarios";

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                DataTable Usuarios = new DataTable();
                sqa.Fill(Usuarios);               
                return Usuarios;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { conexaoBanco.Desconectar(); }

        }


        public int NovoCodigoProduto()
        {

            SqlDataAdapter sqa = new SqlDataAdapter(cmd);

            cmd.CommandText = "Select max(Codigo) from Produtos ";

            // Também consigo incrementar pela querySQl "Select (max(p.codigo) +1) from Produtos p"


            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                int mCodigo = Convert.ToInt32(cmd.ExecuteScalar());
                int nCodigo = mCodigo + 1;               
                return nCodigo;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { conexaoBanco.Desconectar(); }
        }

        public int NovoCodigoClasse()
        {
                       
            cmd.CommandText = "Select isnull(max(pc.Codigo),1) from ProdutoClasse pc";

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                int mCodigo = Convert.ToInt32(cmd.ExecuteScalar());
                int nCodigo = mCodigo + 1;
                if (nCodigo.ToString() == "" || nCodigo.ToString() == null)
                {
                    nCodigo = 1;
                }               
                return nCodigo;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { conexaoBanco.Desconectar(); }

        }

        public bool CadastrarClasse(string Nome, bool Status)
        {

            cmd.CommandText = "insert into ProdutoClasse(Nome, Status)" +
                              "values(@Nome, @Status)";

            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("Status", Status);

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                cmd.ExecuteNonQuery();               
                msg = "Classe Cadastrada!";
                return true;
            }
            catch (Exception e)
            {               
                throw e;
            }
            finally { conexaoBanco.Desconectar(); }

        }

        public List<string> SelecionarProdutoClasse() {

            List<string>Nomes = new List<string>();

            cmd.CommandText = "Select Nome from ProdutoClasse";

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
               

                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read()) 
                    {
                        string Nome = reader["Nome"].ToString();
                        Nomes.Add(Nome);                            
                    }               
            }
            catch (Exception e)
            {
                throw e;
            }

            finally { conexaoBanco.Desconectar(); }

            return Nomes;

                
        }

    }
}
