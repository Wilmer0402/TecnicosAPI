using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Abstractions;
using Tecnicos.Data.Context;
using Tecnicos.Domain.DTO;

namespace Tecnicos.Services
{
    public class TecnicosServices(IDbContextFactory<TecnicosContext> DbFactory) : ITecnicosService
    {
        public async Task<TecnicosDto> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var tecnicos = await contexto.Tecnico
                .Where(e => e.TecnicoId == id)
                .Select(p => new TecnicosDto()
                {
                    TecnicosId = p.TecnicoId,
                    Nombres = p.Nombres,
                    Monto = p.Monto
                }).FirstOrDefaultAsync();

            return tecnicos;
        }

        public async Task<bool> Eliminar(int tecnicoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnico
                .Where(e => e.TecnicoId == tecnicoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteTecnicos(int id, string nombres)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnico
                .AnyAsync(e => e.TecnicoId != id && e.Nombres.ToLower().Equals(nombres.ToLower()));
        }

        private async Task<bool> Insertar(TecnicosDto tecnicosDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var tecnico = new Data.Models.Tecnico()
            {

                Nombres = tecnicosDto.Nombres,
                Monto = tecnicosDto.Monto
            };
            contexto.Tecnico.Add(tecnico);
            var guardo = await contexto.SaveChangesAsync() > 0;
            tecnicosDto.TecnicosId = tecnico.TecnicoId;
            return guardo;
        }

        private async Task<bool> Modificar(TecnicosDto tecnicosDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var tecnico = new Data.Models.Tecnico()
            {
                TecnicoId = tecnicosDto.TecnicosId,
                Nombres = tecnicosDto.Nombres,
                Monto = tecnicosDto.Monto
            };
            contexto.Update(tecnico);
            var modificado = await contexto.SaveChangesAsync() > 0;
            return modificado;
        }

        private async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnico
                .AnyAsync(e => e.TecnicoId == id);
        }

        public async Task<bool> Guardar(TecnicosDto tecnicos)
        {
            if (!await Existe(tecnicos.TecnicosId))
                return await Insertar(tecnicos);
            else
                return await Modificar(tecnicos);
        }

        public async Task<List<TecnicosDto>> Listar(Expression<Func<TecnicosDto, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Tecnico.Select(p => new TecnicosDto()
            {
                TecnicosId = p.TecnicoId,
                Nombres = p.Nombres,
                Monto = p.Monto,
            })
                .Where(criterio)
                .ToListAsync();
        }
    }

}