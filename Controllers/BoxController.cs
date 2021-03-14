using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BoxApi.Services;

namespace BoxApi.Controllers
{
    [ApiController]
    [Route("boxes")]
    public class BoxController : ControllerBase
    {
        private readonly IBoxService _boxService;
        private readonly ILogger<BoxController> _logger;

        public BoxController(ILogger<BoxController> logger, IBoxService boxService)
        {
            _boxService = boxService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            try
            {
                await _boxService.CreateBox();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return Ok();
        }
    }
}