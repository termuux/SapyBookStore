using System.Linq.Expressions;
using Bulky.DataAcess.Data;
using Bulky.DataAcess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.Models;

namespace Bulky.DataAcess.Repository;

public class ProductRepository: Repository<Product>,IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public void Update(Product obj)
    {
        _context.Products.Update(obj);
    }

    
}