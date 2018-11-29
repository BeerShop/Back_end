using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIUsers.Models
{
    public class Cervejas
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Imagem { get; set; }
    }
}