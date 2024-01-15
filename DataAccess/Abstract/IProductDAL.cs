using Core.DataAccess;
using Core.Utilities.Abstract;
using Entities.Concreate;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.ProductDTOs.ProductDTO;

namespace DataAccess.Abstract
{
    public interface IProductDAL : IReposItoryBase<Product>
    {
        IResultData<List<ProductAdminListDTO>> GetProductByUser(string userId, string? langCode = "Az");
        IResultData<List<ProductHomeListDTO>> GetProductBy( string? langCode = "Az");

        IResult AddProduct(string userId, ProductAddDTO productAddDTO);
        IResultData<List<ProductFeaturedDTO>> GetFeaturedProducts(string langCode);
        ProductDetailDTO GetProductDetail(int id, string langCode);
    }
}
