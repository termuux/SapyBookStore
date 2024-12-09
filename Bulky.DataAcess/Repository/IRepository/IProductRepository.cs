using Bulky.Models;
using BulkyWeb.Models;

namespace Bulky.DataAcess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
}