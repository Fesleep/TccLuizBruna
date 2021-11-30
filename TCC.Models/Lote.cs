using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Lote : BaseModel
    {
        [Display(Name = "Nome do Lote")]
        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        public double Hectares { get; set; }

        public double MetrosQuadrados { get; set; }

        public string? Coordinates { get; set; }

    }
}
