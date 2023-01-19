using System.Text.Json.Serialization;

namespace GenusEventosApi.Model
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        // [JsonIgnore]
        public List<Profissional> Profissionais { get; set; } = new();
    }
}
