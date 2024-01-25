using ControleLoja.DAO;
using ControleLoja.Entity;
using ControleLoja.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Azure.Core.HttpHeader;

namespace ControleLoja
{
    /// <summary>
    /// Lógica interna para NovoProduto.xaml
    /// </summary>
    public partial class NovoProduto : Window
    {

        Crud crud = new Crud();
        Produto produto = new Produto();
        


        public NovoProduto()
        {
            InitializeComponent();
            int CodigoProduto = crud.NovoCodigoProduto();
            tb_codigo.Text = CodigoProduto.ToString();
            PreencherComboBox();

        }

        public void tb_codigo_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private void bt_Cadastrar_Click(object sender, RoutedEventArgs e)
        {

            produto.Codigo = crud.NovoCodigoProduto();
            produto.Classe = cb_classe.Text;
            produto.PrecoCusto = decimal.Parse(tb_PrecoCusto.Text);
            produto.PrecoVenda= decimal.Parse(tb_PrecoVenda.Text);
            produto.Status = false;

            try
            {
                crud.CadastrarProduto(tb_Nome.Text, cb_classe.Text, produto.PrecoCusto, produto.PrecoVenda, DateTime.Now, produto.Status);
                var dialogResult =  MessageBox.Show("Produto Cadastrado, deseja cadastrar novo ?", "Produto Cadastrado", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
             
                    // Limpar itens da janela ao clicar Sim e atualizar código do Novo Produto
                                   
                } 
                else if (dialogResult == MessageBoxResult.No)
                {
                    this.Close();
                    NovoProduto.GetWindow(this).Close();                   
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            

             /*
             * DESAFIO FUTURO -- CRIAR UM MESSAGE BOX PERSONALIZADO DE SIM E NAO. 
             * Para quando cadastrar o Produto perguntar se quer cadastrar um novo produto. Se sim, limpa as text box e atualiza o codigo, se não close volta para MainWindow
             */

        }

        private void PreencherComboBox()
        {

            cb_classe.Items.Clear();

            List<string> nomes = crud.SelecionarProdutoClasse();

            foreach (string nome in nomes)
            {
                cb_classe.Items.Add(nome);
            }

        }

        private void cb_classe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cb_classe.SelectedItem != null)
            {
                string valorSelecionado = cb_classe.SelectedItem.ToString();               
            }

        }

        private void bt_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bt_NovaClasse_Click(object sender, RoutedEventArgs e)
        {

            NovaClasse novaClasse = new NovaClasse();
            novaClasse.Show();

        }


    }
}
