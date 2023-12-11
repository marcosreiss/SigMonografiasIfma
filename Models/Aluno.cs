using System.ComponentModel.DataAnnotations;

namespace SigMonografiasIfma.Models
{
    public class Aluno : Persona
    {
        [Required(ErrorMessage = "*")]
        public string Matricula { get; set; }

        public virtual ICollection<Monografia>? Monografias { get; set; }
    }
}
