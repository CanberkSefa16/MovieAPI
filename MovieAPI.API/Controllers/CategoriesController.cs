using Microsoft.AspNetCore.Mvc;
using MovieAPI.Service.DTOs;
using MovieAPI.Service.Services;

namespace MovieAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            ICollection<CategoryDto> categoryDtos = await _service.GetCategoriesAsync();
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            CategoryDto? categoryDto = await _service.GetCategoryByIdAsync(id);
            
            if(categoryDto != null)
                return Ok(categoryDto);
            
            return NotFound();
        }


    }
}