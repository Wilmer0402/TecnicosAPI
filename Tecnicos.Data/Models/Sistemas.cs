using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Data.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }


        [Required(ErrorMessage = "Ingrese un nombre valido")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El nombre del sistema solo debe contener letras.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una descripcion valido")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "La descripcion del sistema solo debe contener letras.")]

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese un costo valido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El costo debe ser mayor que 0.")]
        public double Costo { get; set; }
    }
}
