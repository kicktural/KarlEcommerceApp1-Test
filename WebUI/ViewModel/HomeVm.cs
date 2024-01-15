using Entities.DTOs.ProductDTOs;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;
using static Entities.DTOs.ProductDTOs.ProductDTO;

namespace WebUI.ViewModel
{
    public class HomeVm
    {
        public List<ProductFeaturedDTO> ProductFeaturedDTOs { get; set; }
        public List<CategoryFeaturedDTO> categoryFeaturedDTOs { get; set; }
        public List<ProductHomeListDTO> productHomeListDTO { get; set; }

        
    }
}
