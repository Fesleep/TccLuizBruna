using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.DataAccess.Data;
using TCC.DataAccess.Repository.IRepository;
using TCC.Models;
using TCC.Utility;

namespace TCC.DataAccess.Repository
{
    public class SementeRepository : RepositoryAsync<Semente>, ISementeRepository
    {
        private readonly ApplicationDbContext _db;

        public SementeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public async Task CustomAddAsync(Semente semente)
        //{
        //    semente.PesoMilSementesKg = semente.PesoMilSementesKg;
        //    semente.PoderGerminativo = semente.PoderGerminativo;
        //    semente.PesoSacaKg = semente.PesoSacaKg;

        //    semente.DataCriacao = DateTime.Now;
        //    semente.Deletado = false;
        //    await dbSet.AddAsync(semente);
        //}

        public void Update(Semente semente)
        {
            var objFromDb = _db.Sementes.FirstOrDefault(s => s.Id == semente.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome = semente.Nome;
                objFromDb.CustoMilSementes = semente.CustoMilSementes;
                objFromDb.PesoMilSementesKg = semente.PesoMilSementesKg;
                objFromDb.PoderGerminativo = semente.PoderGerminativo;
                objFromDb.PesoSacaKg = semente.PesoSacaKg;
                objFromDb.CustoSaca = semente.CustoSaca;
                objFromDb.CulturaId = semente.CulturaId;
                objFromDb.FornecedorId = semente.FornecedorId;
                objFromDb.DataAtualizacao = DateTime.Now;
                objFromDb.Deletado = false;
            }
        }
    }
}
