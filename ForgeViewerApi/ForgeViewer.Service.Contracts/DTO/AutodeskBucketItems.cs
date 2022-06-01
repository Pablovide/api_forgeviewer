using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.DTO
{
    public class AutodeskBucketItems
    {
        [JsonProperty("items")]
        public Dictionary<string, AutodeskItem> Items { get; set; }
    }
}
