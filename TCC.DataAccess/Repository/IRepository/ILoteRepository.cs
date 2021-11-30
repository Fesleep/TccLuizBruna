using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.DataAccess.Repository.IRepository
{
    public interface ILoteRepository : IRepositoryAsync<Lote>
    {
        void Update(Lote lote);
        Task CustomAddAsync (Lote lote);
    }
}
