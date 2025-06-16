using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Domain.DTO
{
   public  class TecnicosDto
    {
        public int TecnicosId { get; set; }

        public string? Nombres { get; set; }

        public double Sueldo { get; set; }
    }
}
