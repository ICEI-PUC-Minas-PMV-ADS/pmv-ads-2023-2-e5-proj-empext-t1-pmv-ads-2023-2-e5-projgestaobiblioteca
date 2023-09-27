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
    public class UsuarioPersist : IUsuarioPersist
    {
        // private readonly BibliotecaContext _context;
        // public UsuarioPersist(BibliotecaContext context)
        // {
        //     _context = context;
            
        // }
        private readonly ProEventosContext _context;
        public UsuarioPersist(ProEventosContext context)
        {
            _context = context;
            
        }

        public async Task<Usuario[]> GetAllUsuariosAsync(bool includePatrimonios = false)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            //CAUSARA PROBLEMAS ?
            if (includePatrimonios)
            {
                query = query.Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonio);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome, bool includePatrimonios = false)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            //CAUSARA PROBLEMAS ?
            if (includePatrimonios)
            {
                query = query.Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonio);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(u => u.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includePatrimonios = false)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            //CAUSARA PROBLEMAS ?
            if (includePatrimonios)
            {
                query = query.Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonio);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(u => u.Id == usuarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}