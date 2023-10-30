using System;
using System.Collections.Generic;


namespace CoffeOnPoint.Models {
    public class Pedido {

        public int Id { get; set; }
        public string Cliente { get; set; }
        public string NomeProduto {  get; set; }
        public decimal Total { get; set; }
        public DateTime DataPedido { get; set; }
        
        
        public List<Produto> Produtos { get; set; }

        /*public void VerificaQuantidadeEstoque() {
            if (NomeProduto.Equals(Nome) & Total > 0 & Total <=Quantidade ) {
                Console.WriteLine("Pedido Cadastrado!");
            }else {
                Console.WriteLine("Informar outra quantidade dentro da quantidade" + Quantidade);
            }
        }*/

    }
}
