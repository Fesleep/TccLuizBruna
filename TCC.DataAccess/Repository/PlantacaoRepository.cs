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
    public class PlantacaoRepository : RepositoryAsync<Plantacao>, IPlantacaoRepository
    {
        private readonly ApplicationDbContext _db;

        public PlantacaoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task CustomAddAsync(Plantacao plantacao)
        {
            var seed = _db.Sementes.FirstOrDefault(s => s.Id == plantacao.SementeId);
            var culture = _db.Culturas.FirstOrDefault(s => s.Id == seed.CulturaId);
            var batch = _db.Lotes.FirstOrDefault(s => s.Id == plantacao.LoteId);

            plantacao.MetragemLinear = batch.Hectares * 10000 / culture.EspacamentoEntreLinhas;
            plantacao.PlantasPorMetroLinear = plantacao.PlantasPorHectare * batch.Hectares / plantacao.MetragemLinear;
            plantacao.PlantasTotal = plantacao.PlantasPorMetroLinear * plantacao.MetragemLinear;

            plantacao.SementesPorMetroLinear = plantacao.PlantasPorMetroLinear * 100 / seed.PoderGerminativo;
            plantacao.SementesTotal = plantacao.SementesPorMetroLinear * plantacao.MetragemLinear;


            plantacao.PesoTotalSementes = seed.PesoMilSementesKg / 1000 * plantacao.SementesTotal;
            plantacao.QuantidadeDeSacas = plantacao.PesoTotalSementes / seed.PesoSacaKg;

            plantacao.CustoTotalPlantacao = ((decimal)plantacao.SementesTotal * seed.CustoMilSementes) + ((decimal)plantacao.QuantidadeDeSacas * seed.CustoSaca);
            plantacao.CustoPorHectare = plantacao.CustoTotalPlantacao / (decimal)batch.Hectares;

            plantacao.Ativo = true;
            plantacao.DataCriacao = DateTime.Now;
            plantacao.Deletado = false;

            DeactivateOthers(batch.Id);

            await dbSet.AddAsync(plantacao);
        }

        public void Update(Plantacao plantacao)
        {
            var objFromDb = _db.Plantacoes.FirstOrDefault(s => s.Id == plantacao.Id);
            var seed = _db.Sementes.FirstOrDefault(s => s.Id == plantacao.SementeId);
            var culture = _db.Culturas.FirstOrDefault(s => s.Id == seed.CulturaId);
            var batch = _db.Lotes.FirstOrDefault(s => s.Id == plantacao.LoteId);
            if (objFromDb != null)
            {
                objFromDb.Nome = plantacao.Nome;
                objFromDb.SementeId = plantacao.SementeId;
                objFromDb.LoteId = plantacao.LoteId;


                objFromDb.PlantasPorHectare = plantacao.PlantasPorHectare;
                objFromDb.MetragemLinear = batch.Hectares * 10000 / culture.EspacamentoEntreLinhas;
                objFromDb.PlantasPorMetroLinear = plantacao.PlantasPorHectare * batch.Hectares / objFromDb.MetragemLinear;
                objFromDb.PlantasTotal = objFromDb.PlantasPorMetroLinear * objFromDb.MetragemLinear;

                objFromDb.SementesPorMetroLinear = objFromDb.PlantasPorMetroLinear * 100 / seed.PoderGerminativo;
                objFromDb.SementesTotal = objFromDb.SementesPorMetroLinear * objFromDb.MetragemLinear;
                objFromDb.PesoTotalSementes = seed.PesoMilSementesKg / 1000 * objFromDb.SementesTotal;

                objFromDb.QuantidadeDeSacas = objFromDb.PesoTotalSementes / seed.PesoSacaKg;

                objFromDb.CustoTotalPlantacao = ((decimal)objFromDb.SementesTotal * seed.CustoMilSementes) + ((decimal)objFromDb.QuantidadeDeSacas * seed.CustoSaca);
                objFromDb.CustoPorHectare = objFromDb.CustoTotalPlantacao / (decimal)batch.Hectares;

                DeactivateOthers(batch.Id);

                objFromDb.Ativo = true;
                objFromDb.DataAtualizacao = DateTime.Now;
                objFromDb.Deletado = false;

            }
        }

        public void DeactivateOthers(int id)
        {
            var oldPlantations = _db.Plantacoes.Where(s => s.LoteId == id).ToList();

            foreach (var op in oldPlantations)
            {
                op.Ativo = false;
            }

        }

    }
}
