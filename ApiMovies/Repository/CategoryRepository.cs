using ApiMovies.Models;
using ApiMovies.Repository.IRepository;

namespace ApiMovies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool ExistCategory(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistCategory(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
