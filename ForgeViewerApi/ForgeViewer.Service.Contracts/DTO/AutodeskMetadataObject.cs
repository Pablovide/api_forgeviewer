using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.DTO
{
    public class AutodeskMetadataObject
    {
        [JsonProperty("objectid")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("objects")]
        public Dictionary<string, AutodeskMetadataObject> Objects { get; set; }
    }
}
