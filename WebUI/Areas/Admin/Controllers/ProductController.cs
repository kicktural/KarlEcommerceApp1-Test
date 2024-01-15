using Business.Abstract;
using Entities.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WebUI.Areas.Admin.Controllers
{

     [Area(nameof(Admin))]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICategoryServices _categoryServices;
        public ProductController(IProductService productService, IHttpContextAccessor contextAccessor, ICategoryServices CategoryServices)
        {
            _productService = productService;
            _contextAccessor = contextAccessor;
            _categoryServices = CategoryServices;
        }

        public IActionResult Index()
        {
            var userid = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _productService.GetDashboardProducts(userid, "az-Az");
            return View(result.Data);

        }


        public IActionResult Create()
        {
            var categories =  _categoryServices.GetAllCategories("Eng");
            ViewBag.Categories = new SelectList(categories.Data, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductAddDTO productAdd)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = _productService.AddProductAdmin(userId, productAdd);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
