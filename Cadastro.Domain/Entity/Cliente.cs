namespace Cadastro.Domain.Entity
{
    public class Cliente : Entity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? LogotipoName { get; set; }
        public byte[]? Logo { get; set; }
        public ICollection<Logradouro>? Logradouros { get; set; }
    }
}
