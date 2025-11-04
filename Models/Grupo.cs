namespace InteraFacil.API.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}       