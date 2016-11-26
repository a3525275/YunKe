using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Service;

namespace YunKe.Commerce.EfDbContext
{
    public class YunKeDbContextRepositoryUnitOfWork : IUnitOfWork
    {
        private YunKeDbContext _dbContext;

        public YunKeDbContextRepositoryUnitOfWork()
        {

        }

        public DbContext Context
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new YunKeDbContext();
                }

                return _dbContext;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}
