using System.ComponentModel.DataAnnotations;

namespace Cadastro.Application.DTOs
{
    public class LogradouroDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Endereco é obrigatório")]
        public string? Endereco { get; set; }
        [Required(ErrorMessage = "O Numero é obrigatório")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "O Cidade é obrigatório")]
        public string? Cidade { get; set; }
        [Required(ErrorMessage = "O Estado é obrigatório")]
        public string? Estado { get; set; }
        [Required(ErrorMessage = "O Pais é obrigatório")]
        public string? Pais { get; set; }

        [Required(ErrorMessage = "O Cep é obrigatório")]
        public string? Cep { get; set; }
        public int ClienteId { get; set; }
    }
}
