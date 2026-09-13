using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data.Entities;
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

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto dto)
        {
            CategoryDto createdCategory = await _service.AddCategoryAsync(dto);

            return CreatedAtAction(
                nameof(GetCategoryById),
                new { id = createdCategory.Id },
                createdCategory
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool deleted = await _service.DeleteCategoryAsync(id);

            if(deleted)
                return NoContent();
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto dto, int id)
        {
            bool updated = await _service.UpdateCategoryAsync(id, dto);

            if(!updated)
                return NotFound();

            return NoContent();
        }


    }
}