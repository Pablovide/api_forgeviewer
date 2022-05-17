using ForgeViewer.Service.Contracts.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Impl.Configuration
{
    public class ForgeViewerConfiguration : IForgeViewerConfiguration
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        
        public ForgeViewerConfiguration(IConfiguration jsonSettings)
        {
            ClientId = jsonSettings.GetSection("ForgeSettings").GetSection("Client_Id").Value;
            ClientSecret = jsonSettings.GetSection("ForgeSettings").GetSection("Client_Secret").Value;
        }
    }
}
