using Microsoft.AspNetCore.Mvc;
using Tecnicos.Abstractions;
using Tecnicos.Domain.DTO;

namespace TecnicosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosControllers(ITecnicosService tecnicosService) : ControllerBase
    {

        // GET: api/Tecnicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TecnicosDto>>> GetTecnicos()
        {
            return await tecnicosService.Listar(p => true);
        }

        // GET: api/Tecnicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TecnicosDto>> GetTecnicos(int id)
        {
            return await tecnicosService.Buscar(id);
        }

        // PUT: api/Tecnicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnicos(int id, TecnicosDto tecnicosDto)
        {

            if (id != tecnicosDto.TecnicosId)
            {
                return BadRequest();
            }
            await tecnicosService.Guardar(tecnicosDto);
            return NoContent();
        }

        // POST: api/Tecnicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tecnicos.Data.Models.Tecnico>> PostPrioridades(TecnicosDto tecnicosDto)
        {
            await tecnicosService.Guardar(tecnicosDto);

            return CreatedAtAction("GetTecnicos", new { id = tecnicosDto.TecnicosId }, tecnicosDto);
        }

        // DELETE: api/Tecnicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnicos(int id)
        {
            await tecnicosService.Eliminar(id);
            return NoContent();
        }
    }
}
