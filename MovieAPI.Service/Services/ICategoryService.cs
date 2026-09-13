using MovieAPI.Data.Entities;
using MovieAPI.Service.DTOs;

namespace MovieAPI.Service.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryDto> AddCategoryAsync(CreateCategoryDto dto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto dto);
    }
}