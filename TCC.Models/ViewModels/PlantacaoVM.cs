using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models.ViewModels
{
    public class PlantacaoVM
    {
        [Required]
        public Plantacao? Plantacao { get; set; }
        public IEnumerable<SelectListItem>? SeedList { get; set; }
        public IEnumerable<SelectListItem>? BatchList { get; set; }
    }
}