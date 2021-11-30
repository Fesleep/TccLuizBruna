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
    public class LoteRepository : RepositoryAsync<Lote>, ILoteRepository
    {
        private readonly ApplicationDbContext _db;

        public LoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task CustomAddAsync(Lote lote)
        {
            lote.Hectares = lote.MetrosQuadrados/10000;
            lote.DataCriacao = DateTime.Now;
            lote.Deletado = false;
            await dbSet.AddAsync(lote);
        }

        public void Update(Lote lote)
        {
            var objFromDb = _db.Lotes.FirstOrDefault(s => s.Id == lote.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome = lote.Nome;
                objFromDb.Coordinates = lote.Coordinates;
                objFromDb.Hectares = lote.MetrosQuadrados / 10000;
                objFromDb.DataAtualizacao = DateTime.Now;
                objFromDb.Deletado = false;
            }
        }
    }
}
