using CoffeOnPoint.Data;
using CoffeOnPoint.Models;
using System;
using System.Linq;

namespace CoffeOnPoint {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("CoffeOnPoint");

            using var context = new CoffeDataContext();

            //1º INSERT CATEGORIAS
            context.Categorias.Add(new Categoria {
                Nome = "Afogadinhos",
                Icone = "https://www.icone.com/afogadinho",
            });

            context.Categorias.Add(new Categoria {
                Nome = "Brownies",
                Icone = "https://www.icone.com/brownies",
            });

            context.Categorias.Add(new Categoria {
                Nome = "Bebidas",
                Icone = "https://www.icone.com/bebidas",
            });

            context.SaveChanges();


            //2ºINSERT PRODUTO NA CATEGORIA = 2006

            var categoria = context.Categorias.FirstOrDefault(x => x.Id == 2006);

            context.Produtos.Add(new Produto {
                Nome = "Afogadinho de Chocolate",
                Descricao = "Massa de chocolate recheio chocolate",
                Imagem = "https://www.icone.com/afogadinhochocolate",
                Categoria = categoria,
                Ingredientes = "massa de chocolate com chocolate amargo",
                Preco = 25,

            });

            context.Produtos.Add(new Produto {
                Nome = "Afogadinho de Ninho",
                Descricao = "Massa de chocolate recheio ninho",
                Imagem = "https://www.icone.com/afogadinhoninho",
                Categoria = categoria,
                Ingredientes = "massa de chocolate com leite ninho",
                Preco = 25,

            });

            //2º INSERT PRODUTO NA CATEGORIA = 2007

            var categoria2 = context.Categorias.FirstOrDefault(x => x.Id == 2007);

            context.Produtos.Add(new Produto {
                Nome = "Brownies",
                Descricao = "Massa de chocolate recheio chocolate",
                Imagem = "https://www.icone.com/brownies",
                Categoria = categoria2,
                Ingredientes = "massa de chocolate com chocolate amargo",
                Preco = 25,

            });

            //2º INSERT PRODUTO NA CATEGORIA = 2008

            var categoria3 = context.Categorias.FirstOrDefault(x => x.Id == 2008);

            context.Produtos.Add(new Produto {
                Nome = "Café com Leite",
                Descricao = "Café com Leite",
                Imagem = "https://www.icone.com/cafecomleite",
                Categoria = categoria3,
                Ingredientes = "Café com Leite",
                Preco = 25,

            });

            context.SaveChanges();


            //3º INSERT PEDIDOS
            context.Pedidos.Add(new Pedido {
                Cliente = "Vanessa",
                NomeProduto = "Afogadinho de Chocolate",
                DataPedido = DateTime.Now,
                Total = 1,
            });

            context.Pedidos.Add(new Pedido {
                Cliente = "Paulo",
                NomeProduto = "Afogadinho de Ninho",
                DataPedido = DateTime.Now,
                Total = 1,
            });

            context.SaveChanges();



            //4º UPDATE PARA ALTERAR NOME, DESCRICAO E INGREDIENTES, QUANTIDADE DO PRODUTO
            var produto = context.Produtos.FirstOrDefault(x => x.Id == 1004);
            produto.Nome = "Afogadinho de Maracuja";
            produto.Descricao = "Massa de Chocolate e recheio de Maracujá";
            produto.Ingredientes = "Massa de Chocolate e recheio de Maracujá";
            produto.Quantidade = 2;
            context.Update(produto);
            context.SaveChanges();

            //5º UPDATE EM PRODUTO PARA ALTERAR A QUANTIDADE
            var produto2 = context.Produtos.FirstOrDefault(x => x.Id == 1003);
            produto.Quantidade = 3;
            context.Update(produto2);
            context.SaveChanges();

            //6º DELETE NO PRODUTO
            var produto3 = context.Produtos.FirstOrDefault(x => x.Id == 1006);
            context.Remove(produto3);
            context.SaveChanges();

            //READ PRODUTO
            var produtos = context.Produtos
                 .Where(x => x.Nome.Contains("Afogadinho"))
                 .ToList();
            foreach (var prod in produtos) {
                Console.WriteLine(prod.Nome);
            }

        }
    }
}
