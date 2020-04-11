using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using TestRabbit.Models;

namespace TestRabbit
{
    public interface IProcess
    {
        public AllProducts FullProducts { get; set; }
        public string Run(string data);
    }

    public class ProcessDefault : IProcess
    {
        public ProcessDefault()
        {
            FullProducts = new AllProducts();
            FullProducts.Products = new List<Product>();
        }
        public AllProducts FullProducts { get; set; }

        public string Run(string data)
        {
            try
            {
                string jsonString;
                var product = JsonConvert.DeserializeObject<Product>(JsonConvert.DeserializeObject<string>(data));

                if (File.Exists(@"E:/Archivo/ProcessedProducts.json"))
                {
                    using (StreamReader file = File.OpenText(@"E:/Archivo/ProcessedProducts.json"))

                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        var result = (JObject)JToken.ReadFrom(reader);

                        var products = JsonConvert.DeserializeObject<AllProducts>(result.ToString());

                        products.Products.Add(product);

                        jsonString = JsonConvert.SerializeObject(products);
                    }

                    System.IO.File.WriteAllText(@"E:/Archivo/ProcessedProducts.json", jsonString);
                }
                else
                {
                    FullProducts.Products.Add(product);
                    jsonString = JsonConvert.SerializeObject(FullProducts);
                    System.IO.File.WriteAllText(@"E:/Archivo/ProcessedProducts.json", jsonString);
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }

            return string.Empty;
            
        }
    }
}
