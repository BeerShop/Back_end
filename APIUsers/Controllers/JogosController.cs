using APIUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIUsers.Controllers
{
    public class JogosController : ApiController
    {
        static readonly IJogosRepositorio repositorio = new JogosRepositorio();

        public IEnumerable<Jogos> GetAllJogos()
        {
            return repositorio.GetAll();
        }
        public Jogos GetJogos(int id)
        {
            Jogos item = repositorio.Get(id);
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            return item;
        }

        public IEnumerable<Jogos> GetJogosPorCategoria(string categoria)
        {
            return repositorio.GetAll().Where(p => string.Equals(p.Categoria, categoria, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostJogos(Jogos item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Jogos>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutJogos(int id, Jogos jogos)
        {
            jogos.Id = id;
            if (!repositorio.Update(jogos))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteJogos(int id)
        {
            Jogos item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }

    }
}
