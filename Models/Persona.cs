using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SigMonografiasIfma.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "*")]
        public string Nome { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"[a-z0-9._-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Insira um email válido")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "*")]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "Telefone Inválido")]
        public string Telefone { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "*")]
        public String Cidade { get; set; }

        [DisplayName("Campus")]
        [Required(ErrorMessage = "*")]
        public string Campus { get; set; }
    }
}
