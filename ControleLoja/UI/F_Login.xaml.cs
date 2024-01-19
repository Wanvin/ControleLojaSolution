using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace ControleLoja
{
    /// <summary>
    /// Lógica interna para F_Login.xaml
    /// </summary>
    public partial class F_Login : Window

    {
        MainWindow mainwindow;
        public F_Login(MainWindow login)
        {
            InitializeComponent();
            mainwindow = login;
        }

        public void bt_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bt_logar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
