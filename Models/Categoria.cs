using System;
using System.Collections.Generic;


namespace CoffeOnPoint.Models {
    public class Categoria {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; } 
        public IList<Produto> Produtos { get; set; }    
    }
}
