using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLoja.Entity
{
    public class ProdutoClasse
    {

        public Guid Ide { get; set; }
        public int Codigo {  get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Status { get; set; }

    }
}
