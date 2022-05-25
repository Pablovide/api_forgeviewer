using ForgeViewer.Service.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ForgeViewer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private IMetadataService _metadataService;

        public MetadataController(IMetadataService metadataService)
        {
            _metadataService = metadataService;
        }

        [HttpGet("/metadata/{urn}")]
        public async Task<IActionResult> GetMetadataAsync(string urn)
        {
            try
            {
                var result = await _metadataService.GetModelMetadata(urn);
                return Ok(result);
            } catch(Exception ex)
            {
                Trace.TraceError(string.Empty, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
