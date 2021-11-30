using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TCC.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool? Deletado { get; set; }

    }
}
