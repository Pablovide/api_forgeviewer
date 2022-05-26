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
    public class BucketService : IBucketService
    {
        private readonly ITokenService _tokenService;

        public BucketService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<string>> GetAllBucketsAsync()
        {
            var bucketsApi = await GetBucketsApi();
            var result = (AutodeskBucketList)JsonConvert.DeserializeObject<AutodeskBucketList>(JsonConvert.SerializeObject(bucketsApi.GetBuckets()));
            return result.Items.Values.Select(_ => _.BucketKey);

        }

        private async Task<BucketsApi> GetBucketsApi()
        {
            var token = await _tokenService.GetPrivateTokenAsync();
            var config = new Autodesk.Forge.Client.Configuration();
            config.AccessToken = token.AccessToken;
            return new BucketsApi(config);
        }
    }
}
