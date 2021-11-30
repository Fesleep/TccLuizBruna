using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Semente : BaseModel
    {
        [Display(Name = "Nome da Semente")]

        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Required]
        [Display(Name = "Preço de Mil Sementes")]
        [Column(TypeName = "Money")]
        public decimal CustoMilSementes { get; set; }

        [Required]
        [Display(Name = "Peso de Mil Sementes(Kg)")]
        public double PesoMilSementesKg { get; set; }

        [Required]
        [Display(Name = "Poder Germinativo (%)")]
        public double PoderGerminativo { get; set; }

        [Required]
        [Display(Name = "Peso da Saca(Kg)")]
        public double PesoSacaKg { get; set; }

        [Required]
        [Display(Name = "Preço da Saca")]
        [Column(TypeName = "Money")]
        public decimal CustoSaca { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public Fornecedor? Fornecedor { get; set; }

        [Required]
        public int CulturaId { get; set; }

        [ForeignKey("CulturaId")]
        public Cultura? Cultura { get; set; }

    }
}
