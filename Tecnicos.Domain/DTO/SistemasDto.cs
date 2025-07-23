using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Domain.DTO
{
   public class SistemasDto
    {
        public int SistemaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public double Costo { get; set; }
    }
}
