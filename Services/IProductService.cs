using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_store.Models;

namespace blazor_store.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductDetails(string id);
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);

    }
}