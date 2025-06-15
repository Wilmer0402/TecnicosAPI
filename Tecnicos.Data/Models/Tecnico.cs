using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Data.Models
{
    public  class Tecnico
    {
        [Key]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage ="Solo se Permiten Letras")]

        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Solo se permiten numeros")]
        public double Monto { get; set; }

    }
}
