using MovieAPI.Data.Entities;

namespace MovieAPI.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        void DeleteCategoryAsync(Category category);
        Task SaveChangesAsync();
    }
}