using StoreOfBuild.Data.Contexts;
using StoreOfBuild.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Data
{
    public class IUnitOfWork : Domain.IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
