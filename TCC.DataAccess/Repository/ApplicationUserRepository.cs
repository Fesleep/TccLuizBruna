using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.DataAccess.Data;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;

namespace TCC.DataAccess.Repository
{
    public class ApplicationUserRepository : RepositoryAsync<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicationUser> GetByIdStringAsync(string id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
