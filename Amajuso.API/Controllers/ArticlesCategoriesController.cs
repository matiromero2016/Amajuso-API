using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amajuso.API.DTO;
using Amajuso.API.Filters;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Amajuso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace amajuso_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesCategoriesController : ControllerBase
    {
        private ArticleCategoriesService _service;

        public ArticlesCategoriesController(ArticleCategoriesService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var category = await _service.Get(id);

                return new ObjectResult(new ArticleCategoriesDTO(category));
            }
            catch(ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromQuery] ArticleCategoriesFilter filter)
        {
            try
            {
                var pagedItems = await _service.Where(
                    filter.Active,
                    filter.Page,
                    filter.PageSize);

                List<ArticleCategoriesDTO> articles = new List<ArticleCategoriesDTO>();
                if (pagedItems.Items != null)
                    pagedItems.Items.ToList().ForEach(x => articles.Add(new ArticleCategoriesDTO(x)));

                return new ObjectResult(new PagedCollection<ArticleCategoriesDTO>(Request.GetDisplayUrl())
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
        /// Crea una nueva categoría de artículos
        /// /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        [Produces("application/json")]
        // [ProducesResponseType(201, Type = typeof(AccountDTO))]
        // [ProducesResponseType(400, Type = typeof(ReturnMessage))]
        public async Task<IActionResult> Post([FromBody] ArticleCategoriesPostDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ArticleCategories obj = await _service.Post(item.ToModel());
                return Ok(new ArticleCategoriesDTO(obj));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }

        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Put(long id, [FromBody] ArticleCategoriesPutDTO item)
        { 
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }
                await _service.Put(item.ToModel());
            }

            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
            return NoContent();
        }
    }
}