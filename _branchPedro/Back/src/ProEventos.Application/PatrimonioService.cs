using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ProEventos.Application.Contratos;
using ProEventos.Domain.Biblioteca;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class PatrimonioService : IPatrimonioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPatrimonioPersist _patrimonioPersist;

        public PatrimonioService(IGeralPersist geralPersist, IPatrimonioPersist patrimonioPersist)
        {
            _patrimonioPersist = patrimonioPersist;
            _geralPersist = geralPersist;
            
        }
        public async Task<Patrimonio> AddPatrimonio(Patrimonio model)
        {
            try
            {
                _geralPersist.Add<Patrimonio>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    //opcional pois vc pode ou não retornar algo após salvar mudanças.
                    return await _patrimonioPersist.GetPatrimonioByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Patrimonio> UpdatePatrimonio(int patrimonioId, Patrimonio model)
        {
            try
            {
                var patrimonio = await _patrimonioPersist.GetPatrimonioByIdAsync(patrimonioId, false);
                if(patrimonio == null) return null;

                model.Id = patrimonio.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    //opcional pois vc pode ou não retornar algo após salvar mudanças.
                    return await _patrimonioPersist.GetPatrimonioByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePatrimonio(int patrimonioId)
        {
            try
            {
                var patrimonio = await _patrimonioPersist.GetPatrimonioByIdAsync(patrimonioId, false);
                if(patrimonio == null) throw new Exception("Patrimonio para Deletar não encontrado");


                _geralPersist.Delete<Patrimonio>(patrimonio);
                return await _geralPersist.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Patrimonio[]> GetAllPatrimonioByTituloAsync(string titulo, bool includePalestrantes = false)
        {
            try
            {
                var patrimonios = await _patrimonioPersist.GetAllPatrimoniosByTituloAsync(titulo, includePalestrantes);
                if(patrimonios == null) return null;

                return patrimonios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Patrimonio[]> GetAllPatrimoniosAsync(bool includePalestrantes = false)
        {
            try
            {
                var patrimonios = await _patrimonioPersist.GetAllPatrimoniosAsync(includePalestrantes);
                if(patrimonios == null) return null;

                return patrimonios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Patrimonio> GetPatrimonioByIdAsync(int patrimonioId, bool includePalestrantes = false)
        {
            try
            {
                var patrimonios = await _patrimonioPersist.GetPatrimonioByIdAsync(patrimonioId, includePalestrantes);
                if(patrimonios == null) return null;

                return patrimonios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}