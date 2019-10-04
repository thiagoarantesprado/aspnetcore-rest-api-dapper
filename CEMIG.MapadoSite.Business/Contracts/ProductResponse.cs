using System;
using System.Collections.Generic;
using CEMIG.MapadoSite.Data.Models;
using Newtonsoft.Json;

namespace CEMIG.MapadoSite.Business.Contracts
{
    public class ProductResponse
    {
        public ProductResponse()
        {  
             Products = new List<Product>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Product> Products { get; set; }
    }
}