using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibCorp.Persistence.Interfaces.Contracts.Shared;
using BibCorp.Persistence.Interfaces.Contexts;

namespace BibCorp.Persistence.Interfaces.Packages.Shared
{
    public class SharedPersistence : ISharedPersistence
    {
        private readonly BibCorpContext _context;
        public SharedPersistence(BibCorpContext context)
        {
           _context = context;

        }
        public void Create<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return ((await _context.SaveChangesAsync()) > 0);
        }

        public void Update<T>(T entity) where T : class
        {
    //        _context.Add(entity);
            _context.Update(entity);
        }
    }
}
