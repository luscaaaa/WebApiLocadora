namespace WebApiLocadora
{
    public class Filmes
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Alugado { get; set; }


        public Filmes(int id, string nome, bool alugado)
        {   
            Id = id;
            Nome = nome;
            Alugado = alugado;
        }

    }
}