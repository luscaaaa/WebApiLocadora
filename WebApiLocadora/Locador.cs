namespace WebApiLocadora
{
    public class Locador
    {

        public int Id { get; set; }

        public string Nome { get; set; }


        public Locador(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
