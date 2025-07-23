using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Abstractions;
using Tecnicos.Data.Context;
using Tecnicos.Data.Models;
using Tecnicos.Domain.DTO;

namespace Tecnicos.Services
{
    public class SistemasService(IDbContextFactory<TecnicosContext> DbFactory) : ISistemasService
    {
        public async Task<SistemasDto> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var sistema = await contexto.Sistemas
                .Where(e => e.SistemaId == id).Select(p => new SistemasDto()
                {
                    SistemaId = p.SistemaId,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Costo = p.Costo
                }).FirstOrDefaultAsync();
            return sistema ?? new SistemasDto();
        }

        public async Task<bool> Eliminar(int sistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas
                .Where(e => e.SistemaId == sistemaId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> ExisteSistema(int id, string nombre)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas
                .AnyAsync(e => e.SistemaId != id
    && e.Nombre.ToLower().Equals(nombre.ToLower()));
        }

        private async Task<bool> Insertar(SistemasDto sistemaDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var sistema = new Sistemas()
            {
                Nombre = sistemaDto.Nombre,
                Descripcion = sistemaDto.Descripcion,
                Costo = sistemaDto.Costo
            };
            contexto.Sistemas.Add(sistema);
            var guardo = await contexto.SaveChangesAsync() > 0;
            sistemaDto.SistemaId = sistema.SistemaId;
            return guardo;
        }

        private async Task<bool> Modificar(SistemasDto sistemaDto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var sistema = new Sistemas()
            {
                SistemaId = sistemaDto.SistemaId,
                Nombre = sistemaDto.Nombre,
                Descripcion = sistemaDto.Descripcion,
                Costo = sistemaDto.Costo
            };
            contexto.Update(sistema);
            var modificado = await contexto.SaveChangesAsync() > 0;
            return modificado;
        }

        private async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas
                .AnyAsync(e => e.SistemaId == id);
        }

        public async Task<bool> Guardar(SistemasDto sistema)
        {
            if (!await Existe(sistema.SistemaId))
                return await Insertar(sistema);
            else
                return await Modificar(sistema);
        }

        public async Task<List<SistemasDto>> Listar(Expression<Func<SistemasDto, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas.Select(p => new SistemasDto()
            {
                SistemaId = p.SistemaId,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Costo = p.Costo,
            })
            .Where(criterio)
            .ToListAsync();
        }
    }
}
