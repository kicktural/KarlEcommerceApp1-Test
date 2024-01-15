using Core.DataAccess.SQLServer.EntityFrameWork;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete.ErrorResult;
using Core.Utilities.Concrete.SuccessResult;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.CategoryDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.CategoryDTOs.CategoryDTO;

namespace DataAccess.Concreate.EntityFremawork
{
    public class EFCategoryDAL : EFRepositoryBase<Category, AppDbContext>, ICategoryDAL
    {
        public async Task<bool> AddCategoryByLanguages(CategoryAddDTOs categoryAddDTOs)
        {
            try
            {
                using var context = new AppDbContext();
                Category category = new()
                {
                    PhotoUrl = "//",
                    IsFeatured = false,
                };
                 
              await  context.Categoryes.AddAsync(category);
              await   context.SaveChangesAsync();

                for (int i = 0; i < categoryAddDTOs.CategoryName.Count; i++)
                {
                    CategoryLanguage categoryLanguage = new()
                    {
                        CategoryName = categoryAddDTOs.CategoryName[i],
                        CategoryId = category.Id,
                        LangCode = categoryAddDTOs.LangCode[i],
                        SeoUrl = "//",
                    };
                   await context.CategoryLanguages.AddAsync(categoryLanguage);
                }
               await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            };
        }

        public  IResultData<List<CategoryAdminListDTO>> GetAdminAllCategoeyLanguages(string langCode)
        {
             using AppDbContext context = new();
            try
            {
                var result = context.Categoryes.Select(x => new CategoryAdminListDTO
                {
                    CategoryName = x.CategoryLanguages.FirstOrDefault(x => x.LangCode == langCode).CategoryName,
                    PhotoUrl = "/",
                    IsFeatured  = x.IsFeatured,
                    Id = x.Id,
                    ProductCount = 0
                }).ToList();


                return new SuccessDataResult<List<CategoryAdminListDTO>>(result);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<CategoryAdminListDTO>>(ex.Message);
            }
        }

        public List<CategoryHomeListDTO> GetAllCategoriesLanguages(string langCode)
        {
            using var context = new AppDbContext();
             return context.CategoryLanguages
            .Where(x => x.LangCode == langCode)
              .Include(x => x.Category)
              .Select(x => new CategoryHomeListDTO
              {
                  Id = x.Category.Id,
                  CategoryName = x.CategoryName,
                  SeoUrl = x.SeoUrl,
                  PhotoUrl = x.Category.PhotoUrl,
                  ProductCount = 0
              }).ToList();

        }

        public IResultData<List<CategoryFeaturedDTO>> GetFeaturedCategory(string langCode)
        {
            using AppDbContext context = new();
            var result = context.Categoryes
                .Include(x =>x.CategoryLanguages)
                .Where(x =>x.IsFeatured == true)
                .Select(x => new CategoryFeaturedDTO(x.Id, x.CategoryLanguages.FirstOrDefault(X =>X.LangCode == langCode)
                .CategoryName, x.PhotoUrl, x.CategoryLanguages.FirstOrDefault(X => X.LangCode == langCode)
                .SeoUrl, 0)).ToList();

            return new SuccessDataResult<List<CategoryFeaturedDTO>>(result);
        }
    }
}
