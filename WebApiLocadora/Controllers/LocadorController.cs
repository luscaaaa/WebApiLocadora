using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiLocadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocadorController : ControllerBase
    {
        //criando uma lista de Locador
        public static List<Locador> listaLocador = new List<Locador>();

        //função para inserir alguns locadores(parâmetos já informado no código) na lista
        [HttpGet]
        [Route("IniciarLocadores")]
        public string Iniciar()
        {
            listaLocador.Add(new Locador(1, "José"));
            listaLocador.Add(new Locador(2, "João"));
            listaLocador.Add(new Locador(3, "Amanda"));
            listaLocador.Add(new Locador(4, "Fernanda"));

            return listaLocador.Count() + " locadores foram adicionados a lista";
        }

        //função para listar locadores cadastrados
        [HttpGet]
        [Route("ListarLocador")]
        public string Get()
        {
            return JsonConvert.SerializeObject(listaLocador);
        }

        //função para adicionar um locador na lista
        [HttpPost]
        [Route("AdicionarLocador")]
        public string Post(Locador locador)
        {
            var check = listaLocador.Find(x => x.Nome.Equals(locador.Nome) && x.Id.Equals(locador.Id));

            if (check == null)
            {
                listaLocador.Add(new Locador(locador.Id, locador.Nome));
                return "o locador foi adicionado a lista";
            }
            else
            {
                return "o locador informado já existe em nossa lista";
            }
        }
    };

}