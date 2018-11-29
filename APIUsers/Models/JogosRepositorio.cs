using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIUsers.Models
{
    public class JogosRepositorio : IJogosRepositorio
    {
        private List<Jogos> jogos = new List<Jogos>();
        private int _nextId = 1;

        public JogosRepositorio()
        {
            Add(new Jogos { Nome = "God of War 4", Categoria = "Ação e aventura", Descricao = "God of War é um jogo eletrônico de ação-aventura desenvolvido pela SIE Santa Monica Studio e é o oitavo jogo da série God of War e a sequência dos eventos ocorridos em God of War III.", Ano = "20 de Abril de 2018" });
            Add(new Jogos { Nome = "League of Legends", Categoria = "MMORPG", Descricao = "eague of Legends é um jogo online competitivo que mistura a velocidade e a intensidade de um RTS com elementos de RPG", Ano = "27 de Outubro de 2009" });
            Add(new Jogos { Nome = "Need For Speed Most Wanted", Categoria = "Corrida", Descricao = "O principal objetivo do jogo é fugir da polícia para subir na 'Lista negra dos procurados'", Ano = "30 de outubro de 2012" });
            Add(new Jogos { Nome = "Tibia", Categoria = "RPG", Descricao = "Nele, os jogadores podem desenvolver as habilidades de seus avatares, buscar tesouros, resolver enigmas e explorar áreas como cidades, masmorras, florestas, desertos, ilhas, praias, minas, etc.", Ano = "7 de janeiro de 1997" });
            Add(new Jogos { Nome = "King of Fighters XII", Categoria = "Luta", Descricao = "É a continuação de uma das séries de jogos de luta mais famosa em todo o mundo. .", Ano = "20 de Abril de 201810 de abril de 2009" });
        }


        public IEnumerable<Jogos> GetAll()
        {
            return jogos;
        }

        public Jogos Get(int id)
        {
            return jogos.Find(p => p.Id == id);
        }

        public Jogos Add(Jogos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            jogos.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            jogos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Jogos item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = jogos.FindIndex(p => p.Id == item.Id);
            if (index == 1)
            {
                return false;
            }
            jogos.RemoveAt(index);
            jogos.Add(item);
            return true;
        }
    }
}