using System.ComponentModel.DataAnnotations;

namespace GeradorDeAtas.Models
{
    public class Atas
    {
        [Key]
        public Guid Id { get; set; }
        [Required (ErrorMessage="A paz de Deus! Poderia Digite um titulo por gentileza.")]
        public string Titulo { get; set; } = string.Empty;
        [Required (ErrorMessage ="A paz de Deus! O conteudo não pode ser vazio.")]
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataCriacao{ get; set; } = DateTime.Now;
        public DateTime Alteracao { get; set; } = DateTime.Now;
    }
}
