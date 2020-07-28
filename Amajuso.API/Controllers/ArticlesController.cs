using Amajuso.API.DTO;
using Amajuso.API.Filters;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Amajuso.Domain.Utils;
using Amajuso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Amajuso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private ArticleService _service;

        public ArticlesController(ArticleService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var obj = await _service.Get(id);
                ArticleDTO article = new ArticleDTO(obj);
                return new ObjectResult(article);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] ArticlesFilter filter)
        {
            try
            {
                var pagedItems = await _service.Where(
                    categoryId: filter.CategoryId,
                    filter.Page,
                    filter.PageSize);
                
                List<ArticleDTO> articles = new List<ArticleDTO>();
                if (pagedItems.Items != null)
                    pagedItems.Items.ToList().ForEach(x => articles.Add(new ArticleDTO(x)));

                return new ObjectResult(new PagedCollection<ArticleDTO>(Request.GetDisplayUrl())
                {
                    Items = articles,
                    Count = pagedItems.Count,
                    PageSize = pagedItems.PageSize,
                    CurrentPage = pagedItems.CurrentPage
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Crea una nueva publicación
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer", Roles = Role.Administrator)]
        [Produces("application/json")]
        // [ProducesResponseType(201, Type = typeof(AccountDTO))]
        // [ProducesResponseType(400, Type = typeof(ReturnMessage))]
        public async Task<IActionResult> Post([FromBody] ArticlePostDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Article obj = await _service.Post(item.ToModel(), long.Parse(HttpContext.User.Identity.Name));
                return Ok(obj);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }

        }
    }
}