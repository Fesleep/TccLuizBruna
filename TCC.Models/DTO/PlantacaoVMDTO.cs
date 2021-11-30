using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models.DTO
{
    public class PlantacaoVMDTO
    {
        public PlantacaoDTO? Plantacao { get; set; }
        public IEnumerable<SelectListItem>? SeedList { get; set; }
        public IEnumerable<SelectListItem>? BatchList { get; set; }
    }

    public class PlantacaoDTO : BaseModel
    {
        public string? Nome { get; set; }
        [Display(Name = "Plantas por Hectare")]
        public string? PlantasPorHectare { get; set; }

        [Display(Name = "Total de Plantas")]
        public string? PlantasTotal { get; set; }

        [Display(Name = "Plantas por metro linear")]
        public string? PlantasPorMetroLinear { get; set; }

        [Display(Name = "Sementes por metro linear")]
        public string? SementesPorMetroLinear { get; set; }

        [Display(Name = "Total de Sementes")]
        public string? SementesTotal { get; set; }

        [Display(Name = "Peso total de sementes")]
        public string? PesoTotalSementes { get; set; }

        [Display(Name = "Quantidade de sacas")]
        public string? QuantidadeDeSacas { get; set; }

        [Display(Name = "Custo por Hectare")]
        public string? CustoPorHectare { get; set; }

        [Display(Name = "Custo total da Plantação")]
        public string? CustoTotalPlantacao { get; set; }
        public int SementeId { get; set; }
        public Semente? Semente { get; set; }
        public int LoteId { get; set; }
        public Lote? Lote { get; set; }
        public bool Ativo { get; set; }
    }
}
