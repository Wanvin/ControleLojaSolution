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

        public void LimparCampos()
        {
            int CodigoProduto = crud.NovoCodigoProduto();
            tb_codigo.Text = CodigoProduto.ToString();
            PreencherComboBox();
            tb_Nome.Text = "";
            tb_PrecoCusto.Text = "";
            tb_PrecoVenda.Text = "";
            produto.Nome = string.Empty;
        }

        public void tb_codigo_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private void bt_Cadastrar_Click(object sender, RoutedEventArgs e)
        {

            produto.Codigo = crud.NovoCodigoProduto();
            produto.Nome = tb_Nome.Text;
            produto.Classe = cb_classe.Text;
            produto.PrecoCusto = decimal.Parse(tb_PrecoCusto.Text);
            produto.PrecoVenda= decimal.Parse(tb_PrecoVenda.Text);
            produto.Status = false;

            try
            {
                crud.CadastrarProduto(produto.Nome, produto.Classe, produto.PrecoCusto, produto.PrecoVenda, DateTime.Now, produto.Status);
                var dialogResult =  MessageBox.Show("Produto Cadastrado, deseja cadastrar novo ?", "Produto Cadastrado", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {                                                          
                    LimparCampos();                  
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
