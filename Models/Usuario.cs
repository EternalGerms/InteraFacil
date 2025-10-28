using System.Text.Json.Serialization;

namespace InteraFacil.API.Models
{
    public class Usuario
    {
        private string _nome;

        public string SenhaHash { get; private set; }

        public int Id { get; set; }
        
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }
                _nome = value;
            }
        }
        public string Email { get; set; }

        [JsonIgnore]
        public string Senha { 
            get
            {
                throw new InvalidOperationException("A senha não pode ser lida diretamente.");
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 8)
                {
                    throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
                }
                
                SenhaHash = "HASHED_" + value;
            } }
        
    }
}