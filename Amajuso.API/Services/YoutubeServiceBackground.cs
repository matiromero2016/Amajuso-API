using System;
using Microsoft.Extensions.Hosting;
using Amajuso.Domain.Utils;
using System.Threading;
using System.Threading.Tasks;
using Amajuso.Services;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Amajuso.API.Services
{
    public class YoutubeServiceBackground : BackgroundService, IHostedService
    {
        private Timer _timer;
        //private IYoutubeService<Youtube> _service;
        public IServiceScopeFactory _serviceScopeFactory;


        public YoutubeServiceBackground(IServiceScopeFactory serviceScopeFactory)
        {
            this._serviceScopeFactory = serviceScopeFactory;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(21600));
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scoped = scope.ServiceProvider.GetRequiredService<IYoutubeService<Youtube>>();
                    var listVideos = await scoped.GetLastVideos();
                    foreach (var item in listVideos)
                    {
                        var video = scoped.Get(item.YoutubeId);
                        if (video != null)
                            await scoped.Post(item);
                    }
                }
            }
            catch
            {
            }
        }
        public override void Dispose()
        {
            _timer?.Dispose();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}