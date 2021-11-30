using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Fornecedor : BaseModel
    {
        [Display(Name = "Nome do Fornecedor")]
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        [Display(Name = "Número de Telefone")]
        public string NumeroTelefone { get; set; }
    }
}