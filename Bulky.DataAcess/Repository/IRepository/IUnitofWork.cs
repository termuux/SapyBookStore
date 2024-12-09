namespace Bulky.DataAcess.Repository.IRepository;

public interface IUnitofWork
{
    ICategoryRepository Category { get; }
    void Save();
    IProductRepository Product { get; }
    
}