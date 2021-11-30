using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.DataAccess.Repository.IRepository
{
    public interface IPlantacaoRepository : IRepositoryAsync<Plantacao>
    {
        void Update(Plantacao plantacao);
        Task CustomAddAsync(Plantacao plantacao);
    }
}
