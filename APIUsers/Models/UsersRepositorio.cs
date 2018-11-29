using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIUsers.Models
{
    public class UsersRepositorio : IUsersRepositorio
    {
        private List<Users> users = new List<Users>();
        private int _nextId = 1;

        public UsersRepositorio()
        {
            Add(new Users { Nome = "God of War 4", Categoria = "Ação e aventura" });
            Add(new Users { Nome = "League of Legends", Categoria = "MMORPG"});
            Add(new Users { Nome = "Need For Speed Most Wanted", Categoria = "Corrida"});
            Add(new Users { Nome = "Tibia", Categoria = "RPG"});
            Add(new Users { Nome = "King of Fighters XII", Categoria = "Luta"});
        }      

        IEnumerable<Users> IUsersRepositorio.GetAll()
        {
            return users;
        }

        Users IUsersRepositorio.Get(int id)
        {
            return users.Find(p => p.Id == id);
        }

        public Users Add(Users item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            users.Add(item);
            return item;
        }

        public bool Update(Users item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = users.FindIndex(p => p.Id == item.Id);
            if (index == 1)
            {
                return false;
            }
            users.RemoveAt(index);
            users.Add(item);
            return true;
        }

        public void Remove(int id)
        {
            users.RemoveAll(p => p.Id == id);
        }
    }
}