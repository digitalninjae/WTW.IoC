using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(_repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            _repo.Save(product);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _repo.Save(product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}