using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models.DTO
{
    public class SementeVMDTO
    {
        public SementeDTO? Semente { get; set; }
        public IEnumerable<SelectListItem>? CultureList { get; set; }
        public IEnumerable<SelectListItem>? ProviderList { get; set; }
    }

    public class SementeDTO : BaseModel
    {
        public string? Nome { get; set; }

        [Display(Name = "Preço de Mil Sementes")]
        public string? CustoMilSementes { get; set; }
        
        [Display(Name = "Peso de Mil Sementes(Kg)")]
        public string? PesoMilSementesKg { get; set; }

        [Display(Name = "Poder Germinativo (%)")]
        public string? PoderGerminativo { get; set; }

        [Display(Name = "Peso da Saca(Kg)")]
        public string? PesoSacaKg { get; set; }

        [Display(Name = "Preço da Saca")]
        public string? CustoSaca { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public int CulturaId { get; set; }
        public Cultura? Cultura { get; set; }
    }
}
