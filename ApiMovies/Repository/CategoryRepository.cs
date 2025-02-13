using ApiMovies.Data;
using ApiMovies.Models;
using ApiMovies.Repository.IRepository;

namespace ApiMovies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            _db.Categories.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _db.Categories.Remove(category);
            return Save();
        }

        public bool ExistCategory(int id)
        {
           return _db.Categories.Any(c => c.Id == id);
        }

        public bool ExistCategory(string name)
        {
            bool value = _db.Categories.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public ICollection<Category> GetCategories()
        {
           return _db.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == CategoryId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            var existingCategory = _db.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                _db.Entry(existingCategory).CurrentValues.SetValues(category);
            } else
            {
                _db.Categories.Update(category);
            }
            return Save();
        }
    }
}
