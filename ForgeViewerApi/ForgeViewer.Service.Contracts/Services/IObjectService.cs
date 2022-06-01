using ForgeViewer.Service.Contracts.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.Services
{
    public interface IObjectService
    {
        Task<IEnumerable<AutodeskItem>> GetFilesByBucketAsync(string bucketKey);
    }
}
