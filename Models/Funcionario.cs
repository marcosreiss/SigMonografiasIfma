using SigMonografiasIfma.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace SigMonografiasIfma.Models
{
    public class Funcionario : IdentityUser
    {
        //-------------------------persona atributos-----------------------
        [Key]
        public int Id { get; set; }


        [DisplayName("Nome")]
        [Required(ErrorMessage = "*")]
        public string Nome { get; set; }

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

        //-------------------------Funcionário atributos-----------------------

        [Required(ErrorMessage = "*")]
        public string Login { get; set; }

        public TipoFuncionario NivelAcesso { get; set; }
    }
}
