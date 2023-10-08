using System.ComponentModel.DataAnnotations;

namespace Cadastro.Application.DTOs
{
    public class ClienteDTO
    {   
        public int ID { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string? Email { get; set; }
        public string? LogotipoName { get; set; }
        public byte[]? Logo { get; set; }
    }
}
