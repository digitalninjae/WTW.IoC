using System.Collections.Generic;
using Web.Models;

namespace Web
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Save(Product product);
        void Delete(int id);
    }
}