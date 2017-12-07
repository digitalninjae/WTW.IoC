using System.Collections.Generic;

namespace Web.Models
{
    public class UserProducts
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}