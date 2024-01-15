using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryServices _categoryServices;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, ICategoryServices categoryServices, IProductService productService)
        {
            _logger = logger;
            _categoryServices = categoryServices;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllFeaturedProducts("az-Az");
            var categories = _categoryServices.GetAllFeaturedCategory("Az");
            var result = _productService.GetHomeProducts( "az-Az");
    
            HomeVm homevm = new()
            {
                categoryFeaturedDTOs = categories.Data,
                ProductFeaturedDTOs = products.Data,
                productHomeListDTO = result.Data
            };
            return View(homevm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}