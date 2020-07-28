using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Amajuso.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Amajuso.Services
{
    public class YoutubeService : IYoutubeService<Youtube>
    {
        private IRepository<Youtube> _repository;
        private IHttpClientFactory _httpClient;
        private YoutubeCredentials _youtubeCredentials;
        public YoutubeService(IRepository<Youtube> repository, IHttpClientFactory httpClient, [FromServices] YoutubeCredentials youtubeCredentials) {
            _repository = repository;
            _httpClient = httpClient;
            _youtubeCredentials = youtubeCredentials;
        }

        public async Task<Youtube> Get(long value)
        {
            return await _repository.SelectAsync(value);
        }

        public async Task<Youtube> Get(string youtubeId)
        {
            Youtube video;
            var videos = await _repository.SelectAsync(x => x.YoutubeId == youtubeId, 1, 10);
            video = videos.FirstOrDefault();
            return video;

        }

        public async Task<IEnumerable<Youtube>> GetLastVideos()
        {
            YoutubeResponse objJson = null;
            List<Youtube> listVideos = new List<Youtube>();
            string url = _youtubeCredentials.Url + _youtubeCredentials.UrlLastVideos;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(url, _youtubeCredentials.ApiKey, _youtubeCredentials.ChannelId);
            var client = _httpClient.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(5);
            var response = await client.GetAsync(sb.ToString());
                if (response.IsSuccessStatusCode)
                {
                    objJson = JsonConvert.DeserializeObject<YoutubeResponse>(response.Content.ReadAsStringAsync().Result);
                    foreach (var item in objJson.items)
                        listVideos.Add(new Youtube(item.id.videoId, item.snippet.title, item.snippet.description, item.snippet.thumbnails.Default.url, item.snippet.publishedAt));
                }
                else
                {
                    throw new ArgumentException(response.ReasonPhrase);
                }
            return listVideos;
        }

        public async Task<Youtube> Post(Youtube obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public async Task<PagedCollection<Youtube>> Where(Expression<Func<Youtube, bool>> expression, int page = 1, int pageSize = 10)
        {
            return new PagedCollection<Youtube> {
                Items = await _repository.SelectAsync(null, page, pageSize),
                Count = await _repository.CountAsync(null),
                PageSize = pageSize,
                CurrentPage = page
            };
        }

    }
}
