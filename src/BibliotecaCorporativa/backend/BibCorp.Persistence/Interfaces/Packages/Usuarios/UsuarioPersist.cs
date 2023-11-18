using BibCorp.Domain.Models.Usuarios;
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
        .Include(u => u.Emprestimos).ThenInclude(e => e.Patrimonio)
        .AsNoTracking()
        .OrderBy(u => u.Id);

      return await query.ToArrayAsync();
    }

    public async Task<IEnumerable<Usuario>> GetAllUsuariosByNomeAsync(string nome)
    {
      IQueryable<Usuario> query = _context.Users
        .Include(u => u.Emprestimos)
        .ThenInclude(e => e.Patrimonio)
        .AsNoTracking()
        .OrderBy(u => u.Id)
        .Where(u => u.Nome.ToLower().Contains(nome.ToLower()));

      return await query.ToArrayAsync();
    }

    public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId)
    {
      IQueryable<Usuario> query = _context.Users
       .Include(u => u.Emprestimos)
       .ThenInclude(e => e.Patrimonio)
       .AsNoTracking()
       .Where(u => u.Id == usuarioId);

      return await query.FirstOrDefaultAsync();
    }
    public async Task<Usuario> GetUsuarioByUserNameAsync(string userName)

    {
      IQueryable<Usuario> query = _context.Users;

      query = query
          .Include(u => u.Emprestimos)
          .ThenInclude(e => e.Patrimonio)
          .AsNoTracking()
          .Where(c => c.UserName.ToLower() == userName.ToLower());

      return await query.SingleOrDefaultAsync();
    }
  }
}
