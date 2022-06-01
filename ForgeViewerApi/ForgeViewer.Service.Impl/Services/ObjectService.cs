using Autodesk.Forge;
using ForgeViewer.Service.Contracts.DTO;
using ForgeViewer.Service.Contracts.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Impl.Services
{
    public class ObjectService : IObjectService
    {
        private readonly ITokenService _tokenService;

        public ObjectService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<AutodeskItem>> GetFilesByBucketAsync(string bucketKey)
        {
            var objectsApi = await GetObjectsApi();
            var objects = await objectsApi.GetObjectsAsync(bucketKey);
            var bucketItems = (AutodeskBucketItems)JsonConvert.DeserializeObject<AutodeskBucketItems>(JsonConvert.SerializeObject(objects));
            return bucketItems.Items.Values.ToList();
        }

        private async Task<ObjectsApi> GetObjectsApi()
        {
            var token = await _tokenService.GetPrivateTokenAsync();
            var config = new Autodesk.Forge.Client.Configuration();
            config.AccessToken = token.AccessToken;
            return new ObjectsApi(config);
        }
    }
}
