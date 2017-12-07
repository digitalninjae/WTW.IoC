using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        // GET
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _repo.Save(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_repo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            _repo.Save(user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}