using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models.DTO
{
    public class CulturaDTO : BaseModel
    {
        public string? Nome { get; set; }

        [Display(Name = "Espaçamento entre linhas")]
        public string? EspacamentoEntreLinhas { get; set; }

        public string? ImagemUrl { get; set; }
    }
}