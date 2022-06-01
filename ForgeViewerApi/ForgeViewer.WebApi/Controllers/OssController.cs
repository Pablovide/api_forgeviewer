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
        private readonly IBucketService _bucketService;
        private readonly IObjectService _objectService;
        public OssController(IBucketService bucketSetvice, IObjectService objectService)
        {
            _bucketService = bucketSetvice;
            _objectService = objectService;
        }

        [HttpGet("/buckets")]
        public async Task<IActionResult> GetAllBucketsAsync()
        {
            try
            {
                var result = await _bucketService.GetAllBucketsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Empty, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/files/{bucketKey}")]
        public async Task<IActionResult> GetFilesByBucketAsync(string bucketKey)
        {
            try
            {
                var result = await _objectService.GetFilesByBucketAsync(bucketKey);
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