using Business.Abstract;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Core.Utilities.Concrete.ErrorResult;
using Core.Utilities.Concrete.SuccessResult;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace Business.Concreate
{
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public IResult AddCategory(CategoryAddDTOs CategoryAddDTOs)
        {
            try
            {
               _categoryDAL.AddCategoryByLanguages(CategoryAddDTOs);
                return new SuccessResult("Product Added SuccessFully");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }

            
        }

        public IResult DeleteCategory(Category Category)
        {
            throw new NotImplementedException();
        }

        public IResultData<List<CategoryAdminListDTO>> GetAllAdminCategories(string langCode)
        {
            var result =  _categoryDAL.GetAdminAllCategoeyLanguages(langCode);
            if (result.Success)
            {
                return new SuccessDataResult<List<CategoryAdminListDTO>>(result.Data);
            }
            return new ErrorDataResult<List<CategoryAdminListDTO>>(result.Message);
        }

        public IResultData<List<CategoryHomeListDTO>> GetAllCategories(string langCode)
        {
           var result = _categoryDAL.GetAllCategoriesLanguages(langCode);
            return new SuccessDataResult<List<CategoryHomeListDTO>>(result, "All Categories");
        }

        public IResultData<List<CategoryFeaturedDTO>> GetAllFeaturedCategory(string langCode)
        {
            var result = _categoryDAL.GetFeaturedCategory(langCode);
            return new SuccessDataResult<List<CategoryFeaturedDTO>>(result.Data);
        }

        public List<Category> GetAllNavbarCategories()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateCategory(Category Category)
        {
            throw new NotImplementedException();
        }
    }
}
