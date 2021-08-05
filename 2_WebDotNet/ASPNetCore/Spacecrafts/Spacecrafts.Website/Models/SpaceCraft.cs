using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spacecrafts.Website.Models
{
    public class SpaceCraft
    {   [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("propellant")]
        public string Propellant { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("imageurl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("technologyexists")]
        public string TechnologyExists {get; set;}

        public override string ToString() =>  JsonSerializer.Serialize<SpaceCraft>(this);
      
    }
}
