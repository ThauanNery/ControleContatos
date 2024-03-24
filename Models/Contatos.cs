using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class Contatos
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o Nome do contato!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Endereço do contato!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Digite o número de Celular do contato!")]
        [Phone(ErrorMessage = "Digite o número de Celular válido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do contato!")]
        [EmailAddress(ErrorMessage = "Digite o E-mail válido!")]
        public string Email { get; set; }
    }
}
