using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Get
        public IActionResult Index()
        {
            IEnumerable<Category> objlist = _db.Category;
            return View(objlist);
        }

        // Create get
        public IActionResult Create()
        {
            return View();
        }
        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return Redirect("Index");
            }
            return View(obj);
        }

        // Edit get
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost] //Edit post
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //  Delete Get 
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost] //Delete post
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOnPost(int? Id)
        {
            var obj = _db.Category.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
