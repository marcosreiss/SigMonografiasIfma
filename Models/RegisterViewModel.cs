using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SigMonografiasIfma.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Login { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas são diferentes")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        public string Nome { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "*")]
        [StringLength(13, MinimumLength = 11, ErrorMessage = "Telefone Inválido")]
        public string Telefone { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "*")]
        public string Cidade { get; set; }

        [DisplayName("Campus")]
        [Required(ErrorMessage = "*")]
        public string Campus { get; set; }




    }
}
