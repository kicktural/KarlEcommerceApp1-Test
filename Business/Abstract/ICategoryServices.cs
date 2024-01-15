using Core.Utilities.Abstract;
using Entities.Concreate;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.ProductDTOs;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;
using static Entities.DTOs.ProductDTOs.ProductDTO;

namespace Business.Abstract
{
    public interface ICategoryServices
    {
        IResult AddCategory(CategoryAddDTOs CategoryAddDTs);
        IResult DeleteCategory(Category Category);
        IResult UpdateCategory(Category Category);
        IResultData<List<CategoryHomeListDTO>> GetAllCategories(string langCode);
        List<Category> GetAllNavbarCategories();
        IResultData<List<CategoryAdminListDTO>> GetAllAdminCategories(string langCode);
        IResultData<List<CategoryFeaturedDTO>> GetAllFeaturedCategory(string langCode);

    }
}
