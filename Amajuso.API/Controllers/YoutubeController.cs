using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amajuso.API.Filters;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amajuso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        IYoutubeService<Youtube> _service;
        public YoutubeController(IYoutubeService<Youtube> service)
        {
            _service = service;
        }
        public async Task<PagedCollection<Youtube>> GetVideos([FromQuery] BaseFilter filter) {
            var listVideos = await _service.Where(null, filter.Page, filter.PageSize);
            return listVideos;
        }
    }
}