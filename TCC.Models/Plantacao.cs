using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TCC.Models.ViewModels;

namespace TCC.Models
{
    public class Plantacao : BaseModel
    {
        [Display(Name = "Nome do Lote")]
        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Display(Name = "Metragem linear")]
        public double MetragemLinear { get; set; }

        [Required]
        [Display(Name = "Total de Plantas por Hectare")]
        public double PlantasPorHectare { get; set; }

        [Display(Name = "Total de Plantas na Plantação")]
        public double PlantasTotal { get; set; }

        [Display(Name = "Plantas por Metro linear")]
        public double PlantasPorMetroLinear { get; set; }

        [Display(Name = "Sementes por Metro linear")]
        public double SementesPorMetroLinear { get; set; }

        [Display(Name = "Total de Sementes na Plantação")]
        public double SementesTotal { get; set; }

        [Display(Name = "Peso total de Sementes (em Kg)")]
        public double PesoTotalSementes { get; set; }

        [Display(Name = "Quantidade total de Sacas")]
        public double QuantidadeDeSacas { get; set; }

        [Display(Name = "Custo por Hectare")]
        [Column(TypeName = "Money")]
        public decimal CustoPorHectare { get; set; }

        [Display(Name = "Custo Total da Plantação")]
        [Column(TypeName = "Money")]
        public decimal CustoTotalPlantacao { get; set; }

        [Required]
        public int SementeId { get; set; }

        [ForeignKey("SementeId")]
        public Semente? Semente { get; set; }

        [Required]
        public int LoteId { get; set; }

        [ForeignKey("LoteId")]
        public Lote? Lote { get; set; }

        [Required]
        public bool Ativo { get; set; }
     
    }
}
