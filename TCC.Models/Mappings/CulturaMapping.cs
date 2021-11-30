using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Models.DTO;

namespace TCC.Models.Mappings
{
    public static class CulturaMapping
    {
        public static Cultura AsCultura(CulturaDTO culturaDTO)
        {
            return new Cultura()
            {
                Id = culturaDTO.Id,
                Nome = culturaDTO.Nome,
                EspacamentoEntreLinhas = float.Parse(culturaDTO.EspacamentoEntreLinhas.Replace('.', ',')),
                ImagemUrl = culturaDTO.ImagemUrl
            };
        }

        public static CulturaDTO AsCulturaDTO(Cultura cultura)
        {
            return new CulturaDTO()
            {
                Id = cultura.Id,
                Nome = cultura.Nome,
                EspacamentoEntreLinhas = cultura.EspacamentoEntreLinhas.ToString().Replace(',', '.'),
                ImagemUrl = cultura.ImagemUrl
            };
        }
    }
}
