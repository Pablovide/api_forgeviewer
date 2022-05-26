using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.Services
{
    public interface IBucketService
    {
        Task<IEnumerable<string>> GetAllBucketsAsync();
    }
}
