using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIUsers.Models
{
    interface IUsersRepositorio
    {
        IEnumerable<Users> GetAll();
        Users Get(int id);
        Users Add(Users item);
        void Remove(int id);
        bool Update(Users item);
    }
}
