using ForgeViewer.Service.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ForgeViewer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("/token")]
        public async Task<IActionResult> GetPublicTokenAsync()
        {
            try
            {
                var result = await _tokenService.GetPublicTokenAsync();
                return Ok(result);
            } catch(Exception ex)
            {
                Trace.TraceError(string.Empty, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
