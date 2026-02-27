using mission_08_models_db_setup.Data;
using mission_08_models_db_setup.Models;

namespace mission_08_models_db_setup.Repositories;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly QuadrantsContext _context;

    public EFCategoryRepository(QuadrantsContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    public Category? GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
    }

    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
