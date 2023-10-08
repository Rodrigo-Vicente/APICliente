namespace Cadastro.Domain.Entity
{
    public class Logradouro : Entity
    {
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Cep { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
