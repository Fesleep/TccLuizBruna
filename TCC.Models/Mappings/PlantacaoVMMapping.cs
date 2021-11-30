using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.DTO;
using TCC.Models.ViewModels;

namespace TCC.Models.Mappings
{
    public static class PlantacaoVMMapping
    {
        public static PlantacaoVM AsPlantacaoVM(PlantacaoVMDTO plantacaoVMDTO)
        {
            return new PlantacaoVM()
            {
                Plantacao = new Plantacao()
                {
                    Id = plantacaoVMDTO.Plantacao.Id,
                    LoteId = plantacaoVMDTO.Plantacao.LoteId,
                    Nome = plantacaoVMDTO.Plantacao.Nome,
                    PlantasPorHectare = double.Parse(plantacaoVMDTO.Plantacao.PlantasPorHectare.Replace('.', ',')),
                    SementeId = plantacaoVMDTO.Plantacao.SementeId,
                },
                BatchList = plantacaoVMDTO.BatchList,
                SeedList = plantacaoVMDTO.SeedList
            };
        }

        public static PlantacaoVMDTO AsPlantacaoVMDTO(PlantacaoVM plantacaoVM)
        {
            return new PlantacaoVMDTO()
            {
                Plantacao = new PlantacaoDTO()
                {
                    Id = plantacaoVM.Plantacao.Id,
                    Semente = plantacaoVM.Plantacao.Semente,
                    Ativo = plantacaoVM.Plantacao.Ativo,
                    CustoPorHectare = plantacaoVM.Plantacao.CustoPorHectare.ToString().Replace(',', '.'),
                    CustoTotalPlantacao = plantacaoVM.Plantacao.CustoTotalPlantacao.ToString().Replace(',', '.'),
                    Lote = plantacaoVM.Plantacao.Lote,
                    LoteId = plantacaoVM.Plantacao.LoteId,
                    Nome = plantacaoVM.Plantacao.Nome,
                    PesoTotalSementes = plantacaoVM.Plantacao.PesoTotalSementes.ToString().Replace('.', ','),
                    PlantasPorHectare = plantacaoVM.Plantacao.PlantasPorHectare.ToString().Replace('.', ','),
                    PlantasPorMetroLinear = plantacaoVM.Plantacao.PlantasPorMetroLinear.ToString().Replace('.', ','),
                    PlantasTotal = plantacaoVM.Plantacao.PlantasTotal.ToString().Replace('.', ','),
                    QuantidadeDeSacas = plantacaoVM.Plantacao.QuantidadeDeSacas.ToString().Replace('.', ','),
                    SementeId = plantacaoVM.Plantacao.SementeId,
                    SementesPorMetroLinear = plantacaoVM.Plantacao.SementesPorMetroLinear.ToString().Replace('.', ','),
                    SementesTotal = plantacaoVM.Plantacao.SementesTotal.ToString().Replace('.', ',')
                },
                BatchList = plantacaoVM.BatchList,
                SeedList = plantacaoVM.SeedList
            };
        }
    }
}
