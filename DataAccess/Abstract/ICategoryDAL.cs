using Core.DataAccess;
using Core.Utilities.Abstract;
using Entities.Concreate;
using Entities.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace DataAccess.Abstract
{
    public interface ICategoryDAL : IReposItoryBase<Category>
    {
        List<CategoryHomeListDTO> GetAllCategoriesLanguages(string langCode);
        Task<bool> AddCategoryByLanguages(CategoryAddDTOs categoryAddDTOs);
        IResultData<List<CategoryAdminListDTO>> GetAdminAllCategoeyLanguages(string langCode);
        IResultData<List<CategoryFeaturedDTO>> GetFeaturedCategory(string langCode);
    }
}
