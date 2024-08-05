using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarefa6.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
    }
}