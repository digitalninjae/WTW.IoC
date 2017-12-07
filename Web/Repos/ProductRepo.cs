using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web
{
    public class ProductRepo : IProductRepo
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Get(int id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }

        public Product Save(Product product)
        {
            if (product.Id == 0)
            {
                product.Id = _products.Count + 1;
                _products.Add(product);
                return product;
            }

            var update = _products.SingleOrDefault(p => p.Id == product.Id);
            if (update == default(Product))
            {
                _products.Add(product);
                return product;
            }
            update.Description = product.Description;
            update.Name = product.Name;
            update.Price = product.Price;
            return update;
        }

        public void Delete(int id)
        {
            var prod = _products.SingleOrDefault(p => p.Id == id);
            if (prod != default(Product))
                _products.Remove(prod);
        }
    }
}