using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class Cultura : BaseModel
    {
        [Display(Name = "Tipo de Cultura")]
        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Display(Name = "Espaçamento (metros)")]
        [Required]
        public float EspacamentoEntreLinhas { get; set; }

        public string? ImagemUrl { get; set; }
    }
}
