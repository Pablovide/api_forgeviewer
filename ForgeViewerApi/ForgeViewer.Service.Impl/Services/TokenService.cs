using Autodesk.Forge;
using ForgeViewer.Service.Contracts.Configuration;
using ForgeViewer.Service.Contracts.DTO;
using ForgeViewer.Service.Contracts.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Impl.Services
{
    public class TokenService : ITokenService
    {
        private readonly IForgeViewerConfiguration _configuration;
        
        public TokenService(IForgeViewerConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AutodeskToken> GetPublicTokenAsync()
        {
            var token = await Get2LeggedTokenAsync(new Scope[] { Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, Scope.DataCreate});
            return token;
        }

        public async Task<AutodeskToken> GetPrivateTokenAsync()
        {
            var token = await Get2LeggedTokenAsync(new Scope[] { Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, Scope.DataCreate, Scope.ViewablesRead, Scope.BucketDelete, Scope.DataWrite });
            return token;
        }

        private async Task<AutodeskToken> Get2LeggedTokenAsync(Scope[] scopes)
        {
            TwoLeggedApi oauth = new TwoLeggedApi();
            string grantType = "client_credentials";
            var a = await oauth.AuthenticateAsync(
                _configuration.ClientId,
                _configuration.ClientSecret,
                grantType,
                scopes);
            var tokenJson = JsonConvert.SerializeObject(a);
            var token = JsonConvert.DeserializeObject<AutodeskToken>(tokenJson);
            return token;
        }
    }
}
