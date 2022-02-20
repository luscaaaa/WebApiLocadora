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

        //função para inserir alguns filmes(parâmetos já informado no código) na lista
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

        //função para listar filmes cadastrados
        [HttpGet]
        [Route("ListarFilmes")]
        public string Get()
        {
            return JsonConvert.SerializeObject(listaFilmes);
        }

        //função para buscar um filme especificnado um id
        [HttpGet]
        [Route("BuscarFilme/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(listaFilmes.Find(x => x.Id.Equals(id)));
        }

        //função para deletar um filme especificnado um id 
        [HttpDelete]
        [Route("DeleteFilme/{id}")]
        public string Delete(int id)
        {
            var filme = listaFilmes.Find(x => x.Id.Equals(id));
            listaFilmes.Remove(filme);

            return "deletado";
        }

        //função para adicionar um filme na lista
        [HttpPost]
        [Route("AdicionarFilme")]
        public string Post(Filmes filmes)
        {
            var check = listaFilmes.Find(x => x.Nome.Equals(filmes.Nome) && x.Id.Equals(filmes.Id));

            if (check != null)
            {
                return "o filme informado já existe em nossa lista";
            }
            else
            {
                listaFilmes.Add(new Filmes(filmes.Id, filmes.Nome, filmes.Alugado));
                return "o filme foi adicionado a lista";
            }
        }

        //função para alugar um filme
        [HttpPut]
        [Route("AlugarFilme/{id}")]
        public string PutAluga(int id)
        {
            var idFilme = id;
            var check = listaFilmes.Find(x => x.Id.Equals(id));
            var message = " ";

            if(check == null)
            {
                message = "o filme informado não foi encontrado!";
            }
            else if (check.Alugado == true)
            {
                message = "filme indisponível";
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
                message = "o filme informado não foi encontrado!";

            }else if (check.Alugado == true)
            {
                check.Alugado = false;
                message = "o filme foi devolvido com sucesso!";
            }
            else
            {
                message = "o filme não está alugado!";
            }

            return message;
        }
    };
 
}