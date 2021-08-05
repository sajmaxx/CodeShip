using System.Text.Json;
using System.Text.Json.Serialization;

namespace CondadoTacos.Models
{
    public class Taco
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("protein")]
        public string Protein { get; set; }
        
        [JsonPropertyName("shell")]
        public string Shell { get; set; }
        
        [JsonPropertyName("flavor")]
        public string  Flavor { get; set; }

        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Taco>(this);
    }
}
