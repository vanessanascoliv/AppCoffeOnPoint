using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeOnPoint.Models {

      
    public class Produto {
    
        public  int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public string Ingredientes { get; set; }
        public Categoria Categoria { get; set; }

        public int Quantidade  { get; set; }

        public IList<Pedido> Pedidos { get; set; }  
        
    }

}
