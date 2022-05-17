using ForgeViewer.Service.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Contracts.Services
{
    public interface ITokenService
    {
        Task<AutodeskToken> GetPublicTokenAsync();
    }
}
