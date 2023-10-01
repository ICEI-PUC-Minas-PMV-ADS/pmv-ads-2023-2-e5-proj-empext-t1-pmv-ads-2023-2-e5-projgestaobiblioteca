using BibCorp.Domain.Models.Usuarios;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Usuarios;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence
{
    public class UsuarioPersist : IUsuarioPersist
    {

        private readonly BibCorpContext _context;
        public UsuarioPersist(BibCorpContext context)
        {
            _context = context;

        }

        public async Task<Usuario[]> GetAllUsuariosAsync(bool includePatrimonios = false)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            if (includePatrimonios)
            {
                query = query.Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonios);
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
                query = query.Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonios);
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
                query = query.Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonios);
            }

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(u => u.Id == usuarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
