using Business.Abstract;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete.ErrorResult;
using Core.Utilities.Concrete.SuccessResult;
using DataAccess.Abstract;
using Entities.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.ProductDTOs.ProductDTO;

namespace Business.Concreate
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
            
        }

        public IResult AddProductAdmin(string userId, ProductAddDTO productAdd)
        {
           var result = _productDAL.AddProduct(userId, productAdd);
            if (result.Success)
            {
                return new SuccessResult(result.Message);
            }
            return new ErrorResult(result.Message);
        }

        public IResultData<List<ProductFeaturedDTO>> GetAllFeaturedProducts(string langCode)
        {
            var result = _productDAL.GetFeaturedProducts(langCode);
            return new SuccessDataResult<List<ProductFeaturedDTO>>(result.Data);
        }

        public IResultData<List<ProductAdminListDTO>> GetDashboardProducts(string userid, string langCode)
        {
            var result = _productDAL.GetProductByUser(userid, langCode);

            if (result.Success)
            {
                return new SuccessDataResult<List<ProductAdminListDTO>>(result.Data);
            }
            return new ErrorDataResult<List<ProductAdminListDTO>>(result.Message);
        }
        public IResultData<List<ProductHomeListDTO>> GetHomeProducts(string langCode)
        {
            var result = _productDAL.GetProductBy( langCode);

            if (result.Success)
            {
                return new SuccessDataResult<List<ProductHomeListDTO>>(result.Data);
            }
            return new ErrorDataResult<List<ProductHomeListDTO>>(result.Message);
        }

        public IResultData<ProductDetailDTO> GetProductById(int id, string langCode)
        {
            var result = _productDAL.GetProductDetail( id, langCode);

            return new SuccessDataResult<ProductDetailDTO>(result);
        }
    }
}