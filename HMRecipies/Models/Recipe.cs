using System;
using SQLite;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HMRecipies.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Category")]
        public string Category { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("OriginalURL")]
        public string OriginalURL { get; set; }

    }

}
