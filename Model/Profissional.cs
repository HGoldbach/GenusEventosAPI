using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GenusEventosApi.Model
{
    public class Profissional
    {
        public int Id { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public double ValorHora { get; set; }
        public string Endereco { get; set; } = string.Empty;
        [JsonIgnore]
        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
    }
}
