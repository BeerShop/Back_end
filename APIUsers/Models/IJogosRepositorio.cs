using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIUsers.Models
{
    interface IJogosRepositorio
    {
        IEnumerable<Jogos> GetAll();
        Jogos Get(int id);
        Jogos Add(Jogos item);
        void Remove(int id);
        bool Update(Jogos item);
    }
}
