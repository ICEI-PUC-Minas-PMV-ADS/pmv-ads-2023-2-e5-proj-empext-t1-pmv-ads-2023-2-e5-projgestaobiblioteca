using BibCorp.Domain.Models.Identity;
using BibCorp.Persistence.Interfaces.Contexts;
using BibCorp.Persistence.Interfaces.Contracts.Usuarios;
using BibCorp.Persistence.Interfaces.Packages.Shared;
using Microsoft.EntityFrameworkCore;

namespace BibCorp.Persistence.Interfaces.Packages.Usuarios
{
    public class UsuarioPersistence : SharedPersistence, IUsuarioPersistence
    {
        private readonly BibCorpContext _context;
        public UsuarioPersistence(BibCorpContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Users
                .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            IQueryable<Usuario> query = _context.Users;

            query = query
                .AsNoTracking()
                .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByUserNameAsync(string userName)

        {
            IQueryable<Usuario> query = _context.Users;

            query = query
                .AsNoTracking()
                .Where(c => c.UserName.ToLower() == userName.ToLower());

            return await query.SingleOrDefaultAsync();
        }

    }
}
