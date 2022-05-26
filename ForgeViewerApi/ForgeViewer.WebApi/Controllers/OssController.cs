using ForgeViewer.Service.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ForgeViewer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OssController : ControllerBase
    {
        private readonly IBucketService _bucketSetvice;
        public OssController(IBucketService bucketSetvice)
        {
            _bucketSetvice = bucketSetvice;
        }
        
        [HttpGet("/buckets")]
        public async Task<IActionResult> GetAllBucketsAsync()
        {
            try
            {
                var result = await _bucketSetvice.GetAllBucketsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Empty, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
