using Bulky.DataAcess.Data;
using Bulky.DataAcess.Repository.IRepository;

namespace Bulky.DataAcess.Repository;

public class UnitOfWork : IUnitofWork
{
    private readonly ApplicationDbContext _context;
    public ICategoryRepository Category { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Category = new CategoryRepository(_context);
    }


    public void Save()
    {
            _context.SaveChanges();
    }
        
}