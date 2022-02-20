using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiLocadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        //criando uma lista de Locador
        public static List<Filmes> listaFilmes = new List<Filmes>();

        //fun��o para inserir alguns filmes(par�metos j� informado no c�digo) na lista
        [HttpGet]
        [Route("IniciarFilmes")]
        public string Iniciar()
        {
            listaFilmes.Add(new Filmes(1, "filme 1", false));
            listaFilmes.Add(new Filmes(13, "filme 2", false));
            listaFilmes.Add(new Filmes(90, "filme 3", false));
            listaFilmes.Add(new Filmes(33, "filme 4", false));

            return listaFilmes.Count() + " filmes foram adicionados a lista";
        }

        //fun��o para listar filmes cadastrados
        [HttpGet]
        [Route("ListarFilmes")]
        public string Get()
        {
            return JsonConvert.SerializeObject(listaFilmes);
        }

        //fun��o para buscar um filme especificnado um id
        [HttpGet]
        [Route("BuscarFilme/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(listaFilmes.Find(x => x.Id.Equals(id)));
        }

        //fun��o para deletar um filme especificnado um id 
        [HttpDelete]
        [Route("DeleteFilme/{id}")]
        public string Delete(int id)
        {
            var filme = listaFilmes.Find(x => x.Id.Equals(id));
            listaFilmes.Remove(filme);

            return "deletado";
        }

        //fun��o para adicionar um filme na lista
        [HttpPost]
        [Route("AdicionarFilme")]
        public string Post(Filmes filmes)
        {
            var check = listaFilmes.Find(x => x.Nome.Equals(filmes.Nome) && x.Id.Equals(filmes.Id));

            if (check != null)
            {
                return "o filme informado j� existe em nossa lista";
            }
            else
            {
                listaFilmes.Add(new Filmes(filmes.Id, filmes.Nome, filmes.Alugado));
                return "o filme foi adicionado a lista";
            }
        }

        //fun��o para alugar um filme
        [HttpPut]
        [Route("AlugarFilme/{id}")]
        public string PutAluga(int id)
        {
            var idFilme = id;
            var check = listaFilmes.Find(x => x.Id.Equals(id));
            var message = " ";

            if(check == null)
            {
                message = "o filme informado n�o foi encontrado!";
            }
            else if (check.Alugado == true)
            {
                message = "filme indispon�vel";
            }
            else
            {
                check.Alugado = true;
                message = "o filme foi alugado com sucesso!";
            }

            return message;
        }

        [HttpPut]
        [Route("DevolverFilme/{id}")]
        public string PutDevolve(int id)
        {
            var idFilme = id;
            var check = listaFilmes.Find(x => x.Id.Equals(id));
            var message = " ";

            if(check == null)
            {
                message = "o filme informado n�o foi encontrado!";

            }else if (check.Alugado == true)
            {
                check.Alugado = false;
                message = "o filme foi devolvido com sucesso!";
            }
            else
            {
                message = "o filme n�o est� alugado!";
            }

            return message;
        }
    };
 
}