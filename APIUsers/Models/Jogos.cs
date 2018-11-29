using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIUsers.Models
{
    public class Jogos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Ano { get; set;}
        public string Categoria { get; set; }

    }
}