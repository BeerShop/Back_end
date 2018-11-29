using APIUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIUsers.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        static readonly IUsersRepositorio repositorio = new UsersRepositorio();

        public IEnumerable<Users> GetAllUsers()
        {
            return repositorio.GetAll();
        }
        public Users GetUsers(int id)
        {
            Users item = repositorio.Get(id);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            return item;
        }
        //GET api/valules
        [HttpGet, Authorize]
        public IEnumerable<Users> GetUsersPorTipo(string tipo)
        {
            return repositorio.GetAll().Where(p => string.Equals(p.Tipo, tipo, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostUsers(Users item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Users>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutUsers(int id, Users users)
        {
            users.Id = id;
            if (!repositorio.Update(users))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUsers(int id)
        {
            Users item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
