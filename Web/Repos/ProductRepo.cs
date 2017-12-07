using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web
{
    public class ProductRepo : IProductRepo
    {
        private static readonly List<Product> Products = new List<Product>();

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public Product Get(int id)
        {
            return Products.SingleOrDefault(p => p.Id == id);
        }

        public Product Save(Product product)
        {
            if (product.Id == 0)
            {
                product.Id = Products.Count + 1;
                Products.Add(product);
                return product;
            }

            var update = Products.SingleOrDefault(p => p.Id == product.Id);
            if (update == default(Product))
            {
                Products.Add(product);
                return product;
            }
            update.Description = product.Description;
            update.Name = product.Name;
            update.Price = product.Price;
            return update;
        }

        public void Delete(int id)
        {
            var prod = Products.SingleOrDefault(p => p.Id == id);
            if (prod != default(Product))
                Products.Remove(prod);
        }
    }
}