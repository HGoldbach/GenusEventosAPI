using System.ComponentModel.DataAnnotations;

namespace GenusEventosApi.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}
