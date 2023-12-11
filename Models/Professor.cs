using System.ComponentModel.DataAnnotations;

namespace SigMonografiasIfma.Models
{
    public class Professor : Persona
    {


        [Required(ErrorMessage = "*")]
        public string Siap { get; set; }

        public  ICollection<Monografia>? Monografias { get; set; }
    }
}
