using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLoja.ConexaoBanco.Entity
{
    public class Usuarios
    {

        public Guid Ide { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Acesso { get; set; }
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }

    }
}
