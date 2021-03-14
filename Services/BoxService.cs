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
                //Insert Box to DB
                await Task.Delay(5000);

                //Publish BoxCreated event
                int id = new Random().Next(1000);
                BoxCreated msg = new BoxCreated(){Id = id, Description = "Box Created."};
                await _endpoint.Publish(msg);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}