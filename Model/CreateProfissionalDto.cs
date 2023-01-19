using System.Text.Json.Serialization;

namespace GenusEventosApi.Model
{
    public class CreateProfissionalDto
    {
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public double ValorHora { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public int EspecialidadeId { get; set; }
    }
}
