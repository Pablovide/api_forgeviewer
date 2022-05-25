using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.DTO
{
    public class AutodeskMetadataData
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, AutodeskMetadataMetadata> Metadata { get; set; }
        [JsonProperty("objects")]
        public Dictionary<string, AutodeskMetadataObject> Objects { get; set; }
        [JsonProperty("collection")]
        public Dictionary<string, AutodeskMetadataCollection> Collections { get; set; }
    }
}
