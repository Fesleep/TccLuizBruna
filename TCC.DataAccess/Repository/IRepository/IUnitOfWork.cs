using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models;

namespace TCC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IFornecedorRepository Fornecedor { get; }
        ILoteRepository Lote { get; }
        IPlantacaoRepository Plantacao { get; }
        ICulturaRepository Cultura { get; }
        ISementeRepository Semente { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ISP_Call SP_Call { get; }

        Task SaveAsync();
        //void Save();
    }
}
