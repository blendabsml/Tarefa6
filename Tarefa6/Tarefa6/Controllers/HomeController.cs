using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarefa6.Models;

namespace Tarefa6.Controllers
{
    public class HomeController : Controller
    {

        private static readonly List<Produtos> ProdutosLista = new List<Produtos>
        {
            new Produtos { Id = 1, Nome = "Casaco Vermelho", Valor = 99.99m, Imagem = "casaco.png" },
            new Produtos { Id = 2, Nome = "Blusa Verde", Valor = 149.99m, Imagem = "blusa.png" },
            new Produtos { Id = 3, Nome = "Shorts Rosa", Valor = 149.99m, Imagem = "shorts.png" },
            new Produtos { Id = 4, Nome = "Calça Jeans", Valor = 149.99m, Imagem = "calca.png" },
            new Produtos { Id = 5, Nome = "Vestido Rosa", Valor = 149.99m, Imagem = "vestido.png" },
        };

        public ActionResult Produtos()
        {
            return View(ProdutosLista);
        }
    }
}