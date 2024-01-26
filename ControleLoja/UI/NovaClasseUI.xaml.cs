using ControleLoja.DAO;
using ControleLoja.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControleLoja.UI
{
    /// <summary>
    /// Lógica interna para NovaClasse.xaml
    /// </summary>
    /// 
    public partial class NovaClasse : Window
    {

        Crud crud =  new Crud();
        ProdutoClasse Classe  = new ProdutoClasse(); 

        public NovaClasse()
        {
            InitializeComponent();
            int CodigoClasse = crud.NovoCodigoClasse();
            tb_codigo.Text = CodigoClasse.ToString();
            
        }

        private void bt_cadastrar_Click(object sender, RoutedEventArgs e)
        {
           
            Classe.Codigo = int.Parse(tb_codigo.Text); 
            Classe.Nome = tb_nome.Text;
            Classe.Status = false;

            if (tb_nome.Text == "")
            {
                System.Windows.MessageBox.Show("Não é possível cadastrar Classe sem um Nome.");
            }
            else
            {
                string msg = string.Empty;

                try
                {
                    crud.CadastrarClasse(Classe.Nome, Classe.Status);
                    msg = "Classe Cadastrada!";
                    this.Close();

                }
                catch (Exception)
                {
                    msg = "Erro ao Cadastrar Classe!";
                    throw;
                }

            }        
                      

             /*
             * DESAFIO FUTURO -- CRIAR UM MESSAGE BOX PERSONALIZADO DE SIM E NAO. 
             * Para Cadastrar uma NovaClasse se clicar sim ou voltar para o Cadastro do Produto se clicar não.
             */


        }
        private void bt_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();   
        }
        private void tb_codigo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
