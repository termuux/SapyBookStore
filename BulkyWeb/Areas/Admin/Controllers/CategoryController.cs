using Bulky.DataAcess.Repository.IRepository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers;
[Area("Admin")]

public class CategoryController : Controller
{
    // GET
    private readonly IUnitofWork _unitofWork;

    public CategoryController(IUnitofWork unitOfWork)
    {
        _unitofWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Category> objCategoriesList = _unitofWork.Category.GetAll().ToList();
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
            _unitofWork.Category.Add(obj);
            TempData["Success"] = "Category created successfully";
            _unitofWork.Save();
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
        Category? obj = _unitofWork.Category.Get(x => x.Id == id);
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
            _unitofWork.Category.Update(obj);
            TempData["Success"] = "Category created successfully";
            _unitofWork.Save();
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

            Category? obj = _unitofWork.Category.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost, ActionName("Delete")] 
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _unitofWork.Category.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitofWork.Category.Remove(obj);
            TempData["Success"] = "Category deleted";
            _unitofWork.Save();
            return RedirectToAction("Index", "Category");

        }

    }
    
