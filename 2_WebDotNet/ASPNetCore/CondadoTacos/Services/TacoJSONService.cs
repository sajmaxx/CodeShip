using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CondadoTacos.Models;
using Microsoft.AspNetCore.Hosting;

namespace CondadoTacos.Services
{
    public class TacoJSONService
    {

        public TacoJSONService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath,"data","tacos.json");

        public IEnumerable<Taco> GetTacos()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Taco[]>(
                jsonFileReader.ReadToEnd(), new JsonSerializerOptions{ PropertyNameCaseInsensitive =  true}
            );
        }

        public void AddRating(string tacoid, int rating)
        {
            var tacos = GetTacos();

            var chosenTaco = tacos.First(ta => ta.Id == tacoid);

            if (chosenTaco != null)
            {
                if (chosenTaco.Ratings == null)
                {
                    chosenTaco.Ratings = new int[] {rating};
                    
                }
                else
                { var listver = chosenTaco.Ratings.ToList(); 
                    listver.Add(rating);
                    chosenTaco.Ratings = listver.ToArray();
                }
            }


            using var tacoStream = File.OpenWrite(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<Taco>>
            (
                new Utf8JsonWriter(tacoStream,
                    new JsonWriterOptions { SkipValidation = true, Indented = true }), tacos



            );


        }



    }
}
