]using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient.Model {

    public class Carrinho {

        public long Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public string Endereco { get; set; }

        public Carrinho() {

        }
    }
}
