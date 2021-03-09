using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BoxApi.Services;

namespace BoxApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("new-box")]
        public async Task<ActionResult> Publish()
        {
            try
            {
                await _boxService.CreateBox();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok();
        }
    }
}