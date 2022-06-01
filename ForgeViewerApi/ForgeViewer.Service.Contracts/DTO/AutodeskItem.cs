using Newtonsoft.Json;

namespace ForgeViewer.Service.Contracts.DTO
{
    public class AutodeskItem
    {
        [JsonProperty("bucketKey")]
        public string BucketKey { get; set; }
        [JsonProperty("objectKey")]
        public string ObjectKey { get; set; }
        [JsonProperty("objectId")]
        public string ObjectId { get; set; }
        [JsonProperty("sha1")]
        public string Sha1 { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
    }
}