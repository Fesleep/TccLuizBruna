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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Fornecedor = new FornecedorRepository(_db);
            Lote = new LoteRepository(_db);
            Plantacao = new PlantacaoRepository(_db);
            Cultura = new CulturaRepository(_db);
            Semente = new SementeRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public IFornecedorRepository Fornecedor { get; private set; }
        public ILoteRepository Lote { get; private set; }
        public IPlantacaoRepository Plantacao { get; private set; }
        public ICulturaRepository Cultura { get; private set; }
        public ISementeRepository Semente { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ISP_Call SP_Call { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
    }
}
