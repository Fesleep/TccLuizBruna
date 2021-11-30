using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCC.Models.DTO;

namespace TCC.Models.ViewModels
{
    public class SementeVM
    {
        [Required]
        public Semente? Semente { get; set; }
        public IEnumerable<SelectListItem>? CultureList { get; set; }
        public IEnumerable<SelectListItem>? ProviderList { get; set; }

    }
}