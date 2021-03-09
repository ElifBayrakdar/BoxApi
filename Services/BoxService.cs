using System;
using System.Threading.Tasks;
using BoxApi.Controllers;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BoxApi.Services
{
    public class BoxService: IBoxService
    {
        private readonly IPublishEndpoint _endpoint;
        private readonly ILogger<BoxController> _logger;

        public BoxService(IPublishEndpoint endpoint, ILogger<BoxController> logger)
        {
            _endpoint = endpoint;
            _logger = logger;
        }

        public async Task CreateBox()
        {
            try
            {
                BoxCreated msg = new BoxCreated(){Id = new Random(10).Next(), Description = "Box Created."};
                await _endpoint.Publish(msg);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}