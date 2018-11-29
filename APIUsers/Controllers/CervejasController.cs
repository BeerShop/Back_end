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
    public class CervejasController : ApiController
    {
        static readonly ICervejasRepositorio repositorio = new CervejasRepositorio();

        public IEnumerable<Cervejas> GetAllJogos()
        {
            return repositorio.GetAll();
        }
        public Cervejas GetCervejas(int id)
        {
            Cervejas item = repositorio.Get(id);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            return item;
        }
        [HttpGet, Authorize]
        public IEnumerable<Cervejas> GetCervejasPorTipo(string tipo)
        {
            return repositorio.GetAll().Where(p => string.Equals(p.Tipo, tipo, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostCervejas(Cervejas item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Cervejas>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutCervejas(int id, Cervejas cervejas)
        {
            cervejas.Id = id;
            if (!repositorio.Update(cervejas))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteCervejas(int id)
        {
            Cervejas item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}
