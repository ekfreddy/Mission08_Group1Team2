using mission_08_models_db_setup.Models;

namespace mission_08_models_db_setup.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category? GetCategoryById(int id);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
    void SaveChanges();
}
