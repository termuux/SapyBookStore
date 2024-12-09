using System.Linq.Expressions;
using Bulky.DataAcess.Data;
using Bulky.DataAcess.Repository.IRepository;
using BulkyWeb.Models;

namespace Bulky.DataAcess.Repository;

public class CategoryRepository: Repository<Category>,ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public void Update(Category obj)
    {
        _context.Categories.Update(obj);
    }

    
}