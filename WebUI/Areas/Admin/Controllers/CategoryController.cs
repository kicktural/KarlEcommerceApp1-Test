using Business.Abstract;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var result =  _categoryServices.GetAllAdminCategories("Az");
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(CategoryAddDTOs categoryAddDTOs)
        {
            _categoryServices.AddCategory(categoryAddDTOs);
            return RedirectToAction("Index");
        }
    }
}
