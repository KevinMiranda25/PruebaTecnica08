using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJMC.EN.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KJMC.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly KJMCDbContext dbContext;
        public UnitOfWork(KJMCDbContext pDbContext)
        {
            dbContext = pDbContext;
        }
        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
