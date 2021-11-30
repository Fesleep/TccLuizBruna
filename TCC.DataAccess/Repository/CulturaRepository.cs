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
    public class CulturaRepository : RepositoryAsync<Cultura>, ICulturaRepository
    {
        private readonly ApplicationDbContext _db;

        public CulturaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cultura cultura)
        {
            var objFromDb = _db.Culturas.FirstOrDefault(s => s.Id == cultura.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome = cultura.Nome;
                objFromDb.EspacamentoEntreLinhas = cultura.EspacamentoEntreLinhas;
                objFromDb.DataAtualizacao = DateTime.Now;
                objFromDb.Deletado = false;
                if (cultura.ImagemUrl != null)
                {
                    objFromDb.ImagemUrl = cultura.ImagemUrl;
                }
            }
        }
    }
}
