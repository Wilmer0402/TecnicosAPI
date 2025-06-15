using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Domain.DTO;

namespace Tecnicos.Abstractions
{
    public interface ITecnicosService
    {
        Task<bool> Guardar(TecnicosDto tecnicos);
        Task<bool> Eliminar (int tecnicosId);

        Task<TecnicosDto> Buscar(int id);

        Task<List<TecnicosDto>> Listar(Expression<Func<TecnicosDto, bool>> criterio);

        Task<bool> ExisteTecnicos(int id, string nombres);
    }
}
