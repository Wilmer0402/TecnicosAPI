using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Domain.DTO
{
   public  class TecnicosDto
    {
        public int TecnicoId { get; set; }

        public string? Nombre { get; set; }

        public double Sueldo { get; set; }
    }
}
