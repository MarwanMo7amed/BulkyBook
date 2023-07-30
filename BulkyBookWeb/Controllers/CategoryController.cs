using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_db.Categories;
            return View(objCategoryList);
        }
        //get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return View(obj); }
        }
        //get
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
                    return NotFound();
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb==null)
                return NotFound();
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return View(obj); }
        }
    }
}
