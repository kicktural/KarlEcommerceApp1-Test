using Core.DataAccess;
using Core.DataAccess.SQLServer.EntityFrameWork;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete.ErrorResult;
using Core.Utilities.Concrete.SuccessResult;
using Core.Utilities.SeoUrlHelper;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.ProductDTOs.ProductDTO;

namespace DataAccess.Concreate.EntityFremawork
{
    public class EFProductDAL : EFRepositoryBase<Product, AppDbContext>, IProductDAL
    {
        public IResult AddProduct(string userId, ProductAddDTO productAdd)
        {
            try
            {
                using AppDbContext context = new();

                List<Picture> pictureList = new();


                for (int i = 0; i < productAdd.PhotoUrls.Count; i++)
                {
                    pictureList.Add(new Picture { PhotoUrl = productAdd.PhotoUrls[i] });
                }

                Product Product = new()
                {
                    CategoryId = productAdd.CategoryId,
                    Price = productAdd.Price,
                    Quantity = productAdd.Quantity,
                    Discount = productAdd.Discount,
                    IsFeatured = productAdd.IsFeatured,
                    Pictures = pictureList,
                    
                };

                                                       
                context.Products.Add(Product);
                context.SaveChanges();

                for (int i = 0; i < productAdd.ProductName.Count; i++)
                {
                    ProductLanguage productLanguage = new()
                    {
                        ProductId = Product.Id,
                        ProductName = productAdd.ProductName[i],
                        Description = productAdd.Description[i],
                        //SeoUrl = productAdd.ProductName[i].ReplaceInvalidChars(),
                        LangCode = i == 0 ? "az-Az" : i == 1 ? "ru-Ru" : "en-En"
                    };
                    context.ProductLanguages.Add(productLanguage);
                }
                context.SaveChanges();
                return new SuccessResult("Product Added SuccessFully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResultData<List<ProductFeaturedDTO>> GetFeaturedProducts(string langCode)
        {
            using AppDbContext context = new();

            var result = context.Products
                .Include(x =>x.ProductLanguages)
                .Include(x =>x.Pictures)
                .Where(x =>x.IsFeatured == true)
                .Select(x => new ProductFeaturedDTO(x.Id,
                //x.ProductLanguages.FirstOrDefault(X => X.LangCode == langCode).SeoUrl,
                x.ProductLanguages.FirstOrDefault(X =>X.LangCode == langCode).ProductName,
                x.Price,
                x.Discount,
                x.Pictures.FirstOrDefault().PhotoUrl)).ToList();

            return new SuccessDataResult<List<ProductFeaturedDTO>>(result);
        }

        public IResultData<List<ProductAdminListDTO>> GetProductByUser(string userId, string? langCode = "Az")
        {
            try
            {
                using AppDbContext context = new();

                var products = context.Products
                    .Include(x => x.Category)
                    .Include(X => X.CategoryLanguages)
                    .Include(x => x.Pictures)
                    .Include(x => x.ProductLanguages)
                    .Select(x => new ProductAdminListDTO
                    {
                        ProductName = x.ProductLanguages.FirstOrDefault(x => x.LangCode == langCode).ProductName,
                        Id = x.Id,
                        Price = x.Price,
                        Discount = x.Discount,
                        CategoryName = x.Category.CategoryLanguages.FirstOrDefault(x => x.LangCode == "Az").CategoryName,
                        PhotoUrl = x.Pictures.FirstOrDefault().PhotoUrl,
                    }).ToList();
                return new SuccessDataResult<List<ProductAdminListDTO>>(products, "Products were deliverd successFully");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<ProductAdminListDTO>>(ex.Message);

            }

        }
        public IResultData<List<ProductHomeListDTO>> GetProductBy(string? langCode = "Az")
        {
            try
            {
                using AppDbContext context = new();

                var products = context.Products
                    .Include(x => x.Category)
                    .Include(X => X.CategoryLanguages)
                    .Include(x => x.Pictures)
                    .Include(x => x.ProductLanguages)
                    .Select(x => new ProductHomeListDTO
                    {
                        ProductName = x.ProductLanguages.FirstOrDefault(x => x.LangCode == langCode).ProductName,
                        Price = x.Price,
                        Discount = x.Discount,
                        CategoryName = x.Category.CategoryLanguages.FirstOrDefault(x => x.LangCode == "Az").CategoryName,
                        PhotoUrls = x.Pictures.FirstOrDefault().PhotoUrl,
                    }).ToList();
                return new SuccessDataResult<List<ProductHomeListDTO>>(products, "Products were deliverd successFully");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<ProductHomeListDTO>>(ex.Message);

            }

        }

        public ProductDetailDTO GetProductDetail(int id, string langCode)
        {
            using AppDbContext context = new();

            var products = context.Products.
                Select(x => new ProductDetailDTO
                {
                   Id = x.Id,
                   ProductName = x.ProductLanguages.FirstOrDefault(x =>x.LangCode == langCode).ProductName,
                   Description =x.ProductLanguages.FirstOrDefault(x =>x.LangCode == langCode).Description,              
                    Price = x.Price,
                   Discount=x.Discount,
                   Quantity = x.Quantity,
                   PhotoUrls = x.Pictures.Where(X =>X.ProductId == id).Select(x =>x.PhotoUrl).ToList(),
                }).FirstOrDefault(x => x.Id == id);

            return products;
        }
    }
}
