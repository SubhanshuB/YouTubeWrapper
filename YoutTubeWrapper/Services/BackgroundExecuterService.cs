using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace YoutTubeWrapper.Services
{
    public class BackgroundExecuterService: IHostedService
    {
        private readonly YoutubeService _youtubeService;
        private readonly ILogger _logger;

        public BackgroundExecuterService(ILogger<BackgroundExecuterService> logger, YoutubeService youtubeService)
        {
            this._youtubeService = youtubeService;
            this._logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _youtubeService.getUpdatedResult(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

