using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestRabbit.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("categoryName")]
        public string Category { get; set; }
        [JsonProperty("nameProduct")]
        public string Name { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("unitsAvailable")]
        public int Units { get; set; }
    }

    public class AllProducts
    {
        [JsonProperty("Body")]
        public List<Product> Products { get; set; }
        //[JsonProperty("Time")]
        //public DateTime Time { get; set; }
    }
}
