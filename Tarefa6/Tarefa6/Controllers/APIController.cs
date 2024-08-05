using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tarefa6.Models;

namespace Tarefa6.Controllers
{
    //Criação de CRUD - Fictício - Apenas para avaliação 
    //Em modo real, usuaria EF ou dapper
    public class APIController : ApiController
    {
        private static readonly List<Produtos> ProdutosLista = new List<Produtos>
        {
            new Produtos { Id = 1, Nome = "Casaco Vermelho", Valor = 99.99m, Imagem = "casaco.png" },
            new Produtos { Id = 2, Nome = "Blusa Verde", Valor = 149.99m, Imagem = "blusa.png" },
            new Produtos { Id = 3, Nome = "Shorts Rosa", Valor = 149.99m, Imagem = "shorts.png" },
            new Produtos { Id = 4, Nome = "Calça Jeans", Valor = 149.99m, Imagem = "calca.png" },
            new Produtos { Id = 5, Nome = "Vestido Rosa", Valor = 149.99m, Imagem = "vestido.png" },
        };

        [HttpGet]
        public IEnumerable<Produtos> ObterProdutos()
        {
            return ProdutosLista;
        }

        [HttpGet]
        public IHttpActionResult ObterProduto(int id)
        {
            var produto = ProdutosLista.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IHttpActionResult AdicionarProduto(Produtos produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            produto.Id = ProdutosLista.Max(p => p.Id) + 1;
            ProdutosLista.Add(produto);
            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);
        }

        [HttpPut]
        public IHttpActionResult AtualizarProduto(int id, Produtos produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ProdutoExiste = ProdutosLista.FirstOrDefault(p => p.Id == id);
            if (ProdutoExiste == null)
            {
                return NotFound();
            }

            ProdutoExiste.Nome = produto.Nome;
            ProdutoExiste.Valor = produto.Valor;
            ProdutoExiste.Imagem = produto.Imagem;
            return Ok(ProdutoExiste);
        }

        [HttpDelete]
        public IHttpActionResult ExcluirProduto(int id)
        {
            var produto = ProdutosLista.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            ProdutosLista.Remove(produto);
            return Ok();
        }
    }
}