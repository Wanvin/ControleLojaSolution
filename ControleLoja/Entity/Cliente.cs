using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ControleLoja.Entity
{
    public class Cliente
    {
        public Guid Ide { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty; 
        public string TelefoneContato { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
    }
}
