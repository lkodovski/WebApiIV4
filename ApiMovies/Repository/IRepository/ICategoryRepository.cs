using ApiMovies.Models;

namespace ApiMovies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int CategoryId);

        bool ExistCategory(int id);
        bool ExistCategory(string name);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
