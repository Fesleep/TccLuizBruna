using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.DataAccess.Repository.IRepository
{
    public interface ISementeRepository : IRepositoryAsync<Semente>
    {
        void Update(Semente semente);
    }
}
