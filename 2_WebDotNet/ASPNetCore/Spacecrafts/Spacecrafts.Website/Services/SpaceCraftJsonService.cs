using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Spacecrafts.Website.Models;

namespace Spacecrafts.Website.Services
{
    public class SpaceCraftJsonService
    {
        public SpaceCraftJsonService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;

        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonfileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "spacecrafts.json"); }

        }

        public IEnumerable<SpaceCraft> GetSpaceCrafts()
        {
            using (var jsonFileReader = File.OpenText(JsonfileName))
            {
                return JsonSerializer.Deserialize<SpaceCraft[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        //todo add a customer rating
        //public void AddRating(string productId, int rating)
        //{
        //    var products = GetProducts();

        //    if(products.First(x => x.Id == productId).Ratings == null)
        //    {
        //        products.First(x => x.Id == productId).Ratings = new int[] { rating };
        //    }
        //    else
        //    {
        //        var ratings = products.First(x => x.Id == productId).Ratings.ToList();
        //        ratings.Add(rating);
        //        products.First(x => x.Id == productId).Ratings = ratings.ToArray();
        //    }

        //    using(var outputStream = File.OpenWrite(JsonFileName))
        //    {
        //        JsonSerializer.Serialize<IEnumerable<Product>>(
        //            new Utf8JsonWriter(outputStream, new JsonWriterOptions
        //            {
        //                SkipValidation = true,
        //                Indented = true
        //            }), 
        //            products
        //        );
        //    }
        //}
    }
}


