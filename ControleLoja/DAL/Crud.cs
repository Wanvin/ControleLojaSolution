﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ControleLoja.ConexaoBanco.Entity;
using System.Windows;
using static Azure.Core.HttpHeader;
using Microsoft.VisualBasic.ApplicationServices;
using ControleLoja.Entity;



namespace ControleLoja.DAO
{
    public class Crud
    {

        ConexaoBanco.ConexaoBanco conexaoBanco = new ConexaoBanco.ConexaoBanco();
        SqlCommand cmd = new SqlCommand();
        string msg = string.Empty;

        public string CadastrarProduto(string Nome, string Classe, decimal PrecoCusto, decimal PrecoVenda, DateTime DataCadastro, bool Status)
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
                cmd.Parameters.Clear();
                msg = "Produto Cadastrado!";
                return msg;
            }
            catch (Exception e)
            {                
                msg = e.Message;
                MessageBox.Show(msg);
                throw;
            }
            finally { conexaoBanco.Desconectar(); }

        }

        
        public List<Usuarios> SelectData()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            cmd.CommandText = "Select * from Usuarios";

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuarios usuario = new Usuarios
                        {
                            Codigo = Convert.ToInt32(reader["Codigo"]),
                            Nome = reader["Nome"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Acesso = Convert.ToInt32(reader["Acesso"]),
                            Cargo = Convert.ToString(reader["Cargo"]),                            
                            DataCadastro = Convert.ToDateTime(reader["DataCadastro"]),
                            Status = Convert.ToBoolean(reader["Status"])
                        };

                        usuarios.Add(usuario);

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conexaoBanco.Desconectar(); }
            return usuarios;
        }
        /*
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
                // Enviar a exception como mensagem ou definir mensagem padrão, como por exemplo: Erro ao selecionar usuario.
                msg = e.Message;
                MessageBox.Show(msg);
                throw;
            }
            finally { conexaoBanco.Desconectar(); }

        }
        */
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

        public string CadastrarClasse(string NomeClasse, bool Status)
        {

            cmd.CommandText = "insert into ProdutoClasse(Nome, Status)" +
                              "values(@Nome, @Status)";

            cmd.Parameters.AddWithValue("@Nome", NomeClasse);
            cmd.Parameters.AddWithValue("Status", Status);

            try
            {
                cmd.Connection = conexaoBanco.Conectar();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                msg = "Classe Cadastrada!";
                return msg;                
            }
            catch (Exception e)
            {               
                msg = e.Message;
                MessageBox.Show(msg);
                throw;
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
            catch (Exception)
            {
                throw;
            }

            finally { conexaoBanco.Desconectar(); }

            return Nomes;
                
        }

        public List<Produto> SelectProduto() 
        {
            List<Produto> listProdutos = new List<Produto>();
            cmd.CommandText = "Select * from Produtos where Status = 0 order by Codigo;";

            try
            {
                cmd.Connection = conexaoBanco.Conectar();

                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Produto produto = new Produto 
                        {
                          Codigo = Convert.ToInt32(reader["Codigo"]),
                          Nome = Convert.ToString(reader["Nome"]),
                          Classe = Convert.ToString(reader["Classe"]),
                          PrecoCusto = Convert.ToDecimal(reader["PrecoCusto"]),
                          PrecoVenda = Convert.ToDecimal(reader["PrecoCusto"]),

                        };
                        listProdutos.Add(produto);                      
                    }

            }
            catch (Exception)
            {

                throw;
            }
            finally { conexaoBanco.Desconectar(); }
            return listProdutos;
        }

    }
}
