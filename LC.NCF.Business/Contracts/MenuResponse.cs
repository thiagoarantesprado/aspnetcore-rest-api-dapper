using System;
using System.Collections.Generic;
using LC.NCF.Data.Models;
using Newtonsoft.Json;

namespace LC.NCF.Business.Contracts
{
    public class MenuResponse
    {
        public MenuResponse()
        {
            Menus = new List<Menu>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Menu> Menus { get; set; }
    }
}
