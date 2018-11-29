using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIUsers.Models
{
    public class CervejasRepositorio : ICervejasRepositorio
    {
        private List<Cervejas> cervejas = new List<Cervejas>();
        private int _nextId = 1;
    
        public Cervejas Add(Cervejas item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            cervejas.Add(item);
            return item;
        }

        public Cervejas Get(int id)
        {
            return cervejas.Find(p => p.Id == id);
        }

        public IEnumerable<Cervejas> GetAll()
        {
            return cervejas;
        }

        public void Remove(int id)
        {
            cervejas.RemoveAll(p => p.Id == id);
        }

        public bool Update(Cervejas item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = cervejas.FindIndex(p => p.Id == item.Id);
            if (index == 1)
            {
                return false;
            }
            cervejas.RemoveAt(index);
            cervejas.Add(item);
            return true;
        }
    }
}