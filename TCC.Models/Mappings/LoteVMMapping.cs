using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.DTO;
using TCC.Models.ViewModels;

namespace TCC.Models.Mappings
{
    public static class LoteVMMapping
    {
        public static LoteVM AsLoteVM(LoteVMDTO loteVMDTO)
        {
            return new LoteVM()
            {
                Lote = new Lote()
                {
                    Id = loteVMDTO.Lote.Id,
                    Nome = loteVMDTO.Lote.Nome,
                    MetrosQuadrados = double.Parse(loteVMDTO.Lote.MetrosQuadrados.Replace('.', ',')),
                    Coordinates = loteVMDTO.Lote.Coordinates,
                }
            };
        }
        public static LoteVMDTO AsLoteVMDTO(LoteVM loteVM)
        {
            return new LoteVMDTO()
            {
                Lote = new LoteDTO()
                {
                    Id = loteVM.Lote.Id,
                    Nome = loteVM.Lote.Nome,
                    MetrosQuadrados = loteVM.Lote.MetrosQuadrados.ToString().Replace(',', '.'),
                    Coordinates = loteVM.Lote.Coordinates,
                }
            };
        }
    }
}
