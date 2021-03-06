using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Net5.GlobalizationAndlocalization.Domain.Models;
using Newtonsoft.Json;

namespace Net5.GlobalizationAndlocalization.Infrastructure
{
    public class ProductRepository
    {
        public IEnumerable<Product> Get()
        {
            Assembly assembly;

            try
            {
                assembly = Assembly.GetExecutingAssembly()
                .GetSatelliteAssembly(CultureInfo.CurrentCulture);
            }
            catch(Exception ex)
            {
                assembly = Assembly.GetExecutingAssembly();
            }

            string resource = "Net5.GlobalizationAndlocalization.Infrastructure.Data.products.json";

            using (var stream = assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();

                var products = 
                    JsonConvert.DeserializeObject<IEnumerable<Product>>(json);


                return products;
            }
        }
    }
}
