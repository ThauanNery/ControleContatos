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

        // Propriedade adicional apenas para exibição com máscara
        public string CelularFormatado
        {
            get
            {
                // Verifica se o número de celular possui pelo menos 10 dígitos
                if (!string.IsNullOrEmpty(Celular) && Celular.Length >= 10)
                {
                    // Aplica a máscara "(XX) XXXX-XXXX"
                    return string.Format("({0}) {1}-{2}", Celular.Substring(0, 2), Celular.Substring(2, 4), Celular.Substring(6));
                }
                else
                {
                    return Celular; // Retorna o número sem modificação se não for possível aplicar a máscara
                }
            }
        }
    }
}
