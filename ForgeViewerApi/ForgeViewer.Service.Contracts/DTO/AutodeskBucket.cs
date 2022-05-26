using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.DTO
{
    public class AutodeskBucket
    {
        [JsonProperty("bucketKey")]
        public string BucketKey { get; set; }
        [JsonProperty("createdDate")]
        public long CreatedDate { get; set; }
        [JsonProperty("policyKey")]
        public string PolicyKey { get; set; }
    }
}
