using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Biblioteca;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PatrimonioPersist : IPatrimonioPersist
    {
        // private readonly BibliotecaContext _context;
        // public PatrimonioPersist(BibliotecaContext context)
        // {
        //     _context = context;
            
        // }
        private readonly ProEventosContext _context;
        public PatrimonioPersist(ProEventosContext context)
        {
            _context = context;
            
        }

        public async Task<Patrimonio[]> GetAllPatrimoniosAsync(bool includeUsuarios = false)
        {
            //IQueryable<Patrimonio> query = _context.Patrimonios.Include(p => p.Emprestimos);
            IQueryable<Patrimonio> query = _context.Patrimonios;

            //CAUSARA PROBLEMAS ?
            if (includeUsuarios)
            {
                query = query.Include(p => p.Emprestimos).ThenInclude(e => e.Usuario);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Patrimonio[]> GetAllPatrimoniosByTituloAsync(string titulo, bool includeUsuarios = false)
        {
            //IQueryable<Patrimonio> query = _context.Patrimonios.Include(p => p.Emprestimos);
            IQueryable<Patrimonio> query = _context.Patrimonios;

            //CAUSARA PROBLEMAS ?
            if (includeUsuarios)
            {
                query = query.Include(p => p.Emprestimos).ThenInclude(e => e.Usuario);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Titulo.ToLower().Contains(titulo.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Patrimonio> GetPatrimonioByIdAsync(int patrimonioId, bool includeUsuarios = false)
        {
            //IQueryable<Patrimonio> query = _context.Patrimonios.Include(p => p.Emprestimos);
            IQueryable<Patrimonio> query = _context.Patrimonios;

            //CAUSARA PROBLEMAS ?
            if (includeUsuarios)
            {
                query = query.Include(p => p.Emprestimos).ThenInclude(e => e.Usuario);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == patrimonioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}