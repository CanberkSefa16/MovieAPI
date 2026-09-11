using MovieAPI.Data.Entities;
using MovieAPI.Data.Repositories;
using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task AddCategoryAsync(CreateCategoryDto dto)
        {
            Category category = new Category
            {
                Name = dto.Name
            };

            await _repo.AddCategoryAsync(category);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            Category? existed = await _repo.GetCategoryByIdAsync(id);

            if(existed == null)
                return false;

            _repo.DeleteCategoryAsync(existed);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            ICollection<Category> categories = await _repo.GetCategoriesAsync();
            ICollection<CategoryDto> categoryDtos = new List<CategoryDto>();

            foreach(Category item in categories)
            {
                CategoryDto categoryDto = new CategoryDto
                {
                    Id = item.Id,
                    Name = item.Name
                };

                categoryDtos.Add(categoryDto);
            }

            return categoryDtos;
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            Category? existed = await _repo.GetCategoryByIdAsync(id);

            if(existed == null)
                return null;
            
            CategoryDto categoryDto = new CategoryDto
            {
                Id = existed.Id,
                Name = existed.Name
            };

            return categoryDto;
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
        {
            Category? existed = await _repo.GetCategoryByIdAsync(id);

            if(existed == null)
                return false;
            
            existed.Name = dto.Name;
            await _repo.SaveChangesAsync();
            
            return true;
        }
    }
}