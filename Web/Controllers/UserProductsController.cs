using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserProductsController : Controller
    {
        private readonly IUserRepo _userRepo;

        private readonly IProductRepo _productRepo;

        public UserProductsController(IUserRepo userRepo, IProductRepo productRepo)
        {
            _userRepo = userRepo;
            _productRepo = productRepo;
        }

        // GET
        public ActionResult Index()
        {
            var model = new UserProducts();
            model.Users = _userRepo.GetAll();
            model.Products = _productRepo.GetAll();
            return View(model);
        }
    }
}