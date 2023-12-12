using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SigMonografiasIfma.Models
{
    public class Aluno : Persona
    {
        [Required(ErrorMessage = "*")]
        public string Matricula { get; set; }

        public virtual ICollection<Monografia>? Monografias { get; set; }


        //aluno so cadastra email acadêmico
        [DisplayName("Email")]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"[a-z0-9._-]+@acad\.ifma\.edu\.br", ErrorMessage = "Insira um email acadêmico válido")]
        public override string Email { get; set; }
    }
}
