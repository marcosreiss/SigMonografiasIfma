using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SigMonografiasIfma.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Login { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Lembrar Usuário")]
        public bool RememberMe { get; set; }
    }
}
