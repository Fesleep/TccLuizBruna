using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models.ViewModels
{
    public class LoteVM
    {
        [Required]
        public Lote? Lote { get; set; }

    }
}