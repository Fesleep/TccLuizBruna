using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models.DTO
{
    public class LoteVMDTO
    {
        public LoteDTO? Lote { get; set; }
    }

    public class LoteDTO : BaseModel
    {
        public string? Nome { get; set; }
        public string? Hectares { get; set; }

        [Display(Name = "Metros Quadrados")]
        public string? MetrosQuadrados { get; set; }
        public string? Coordinates { get; set; }
    }
}
