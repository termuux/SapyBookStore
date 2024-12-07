using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;

public class CategoryController : Controller
{
    // GET
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> objCategoriesList = _db.Categories.ToList();
        return View(objCategoriesList);
    }

    public IActionResult Create()
    {
        return View();
        
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == "test")
        {
            ModelState.AddModelError("", "test is a error input value");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            TempData["Success"] = "Category created successfully";
            _db.SaveChanges();
            return RedirectToAction("Index","Category");

        }
        return View();

        
    }
    
    public IActionResult Edit(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }
        Category? obj = _db.Categories.FirstOrDefault(x => x.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        return View(obj);
        
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            TempData["Success"] = "Category updated successfully";
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");

        }

        return View();
    }

    //the code below is used for deleting from the database
    public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? obj = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost, ActionName("Delete")] 
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            TempData["Success"] = "Category deleted";
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");

        }

    }
    
