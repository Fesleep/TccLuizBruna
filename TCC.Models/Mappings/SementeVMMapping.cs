using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.DTO;
using TCC.Models.ViewModels;

namespace TCC.Models.Mappings
{
    public static class SementeVMMapping
    {
        public static SementeVM AsSementeVM(SementeVMDTO sementeVMDTO)
        {
            return new SementeVM()
            {
                Semente = new Semente()
                {
                    Id = sementeVMDTO.Semente.Id,
                    Nome = sementeVMDTO.Semente.Nome,
                    Cultura = sementeVMDTO.Semente.Cultura,
                    CulturaId = sementeVMDTO.Semente.CulturaId,
                    CustoMilSementes = decimal.Parse(sementeVMDTO.Semente.CustoMilSementes.Replace('.', ',')),
                    CustoSaca = decimal.Parse(sementeVMDTO.Semente.CustoSaca.Replace('.', ',')),
                    Fornecedor = sementeVMDTO.Semente.Fornecedor,
                    FornecedorId = sementeVMDTO.Semente.FornecedorId,
                    PesoMilSementesKg = double.Parse(sementeVMDTO.Semente.PesoMilSementesKg.Replace('.', ',')),
                    PesoSacaKg = double.Parse(sementeVMDTO.Semente.PesoSacaKg.Replace('.', ',')),
                    PoderGerminativo = double.Parse(sementeVMDTO.Semente.PoderGerminativo.Replace('.', ','))
                },
                CultureList = sementeVMDTO.CultureList,
                ProviderList = sementeVMDTO.ProviderList
            };
        }
        public static SementeVMDTO AsSementeVMDTO(SementeVM sementeVM)
        {
            return new SementeVMDTO()
            {
                Semente = new SementeDTO()
                {
                    Id = sementeVM.Semente.Id,
                    Nome = sementeVM.Semente.Nome,
                    Cultura = sementeVM.Semente.Cultura,
                    CulturaId = sementeVM.Semente.CulturaId,
                    CustoMilSementes = sementeVM.Semente.CustoMilSementes.ToString().Replace(',', '.'),
                    CustoSaca = sementeVM.Semente.CustoSaca.ToString().Replace(',', '.'),
                    Fornecedor = sementeVM.Semente.Fornecedor,
                    FornecedorId = sementeVM.Semente.FornecedorId,
                    PesoMilSementesKg = sementeVM.Semente.PesoMilSementesKg.ToString().Replace(',', '.'),
                    PesoSacaKg = sementeVM.Semente.PesoSacaKg.ToString().Replace(',', '.'),
                    PoderGerminativo = sementeVM.Semente.PoderGerminativo.ToString().Replace(',', '.')
                },
                CultureList = sementeVM.CultureList,
                ProviderList = sementeVM.ProviderList
            };
        }
    }
}
