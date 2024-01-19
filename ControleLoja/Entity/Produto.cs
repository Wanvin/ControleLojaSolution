using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLoja.Entity
{
    public class Produto
    {
        public Guid ProdutoIde {  get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Classe { get; set; } = string.Empty;
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoVenda { get; set; }
        public bool Status { get; set; }

    }
}
