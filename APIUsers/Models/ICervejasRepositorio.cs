using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIUsers.Models
{
    interface ICervejasRepositorio
    {
        IEnumerable<Cervejas> GetAll();
        Cervejas Get(int id);
        Cervejas Add(Cervejas item);
        void Remove(int id);
        bool Update(Cervejas item);
    }
}
