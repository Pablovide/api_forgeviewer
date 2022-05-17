using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.Configuration
{
    public interface IForgeViewerConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
