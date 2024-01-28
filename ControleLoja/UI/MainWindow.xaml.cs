
using ControleLoja.ConexaoBanco.Entity;
using ControleLoja.DAO;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ControleLoja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

  

        public MainWindow()
        {
            InitializeComponent();
  
        }

        public void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          

        }

        public void tb_DadoBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Crud crud = new Crud();

            List<Usuarios> selects = crud.SelectData();

            foreach (Usuarios usuario in selects)
            {
                dg_resultado.ItemsSource = selects;
            }

            //DataTable resultado = crud.SelectTeste();

            /* Filtro pela exibicao da busca
               string filtro = "Status = 0";
               resultado.DefaultView.RowFilter = filtro; */
            /*

            dg_resultado.AutoGenerateColumns = false; // Desativa a geração automática de colunas

            // Diz somente quais Columns vão ser exibidas.
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "Código", Binding = new Binding("Codigo") });
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "Nome", Binding = new Binding("Nome") });
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "Username", Binding = new Binding("Username") });
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "Acesso", Binding = new Binding("Acesso") });
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "Cargo", Binding = new Binding("Cargo") });
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "DataCadastro", Binding = new Binding("DataCadastro") });
            dg_resultado.Columns.Add(new DataGridTextColumn { Header = "Status", Binding = new Binding("Status") });

            dg_resultado.ItemsSource = resultado.DefaultView; // Grid recebe resultado
            */




        }

        public void bt_NovoCadastro_Click(object sender, RoutedEventArgs e)
        {
            // Chamar tela de Cadastro
            NovoProduto novoProdutoUI = new NovoProduto();
            novoProdutoUI.Show();


        }
    }

}