using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.Services
{
    public interface IMetadataService
    {
        Task<object> GetModelMetadata(string urn);
    }
}
