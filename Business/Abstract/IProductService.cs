using Core.Utilities.Abstract;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.ProductDTOs.ProductDTO;

namespace Business.Abstract
{
    public interface IProductService
    {
       public IResultData<List<ProductAdminListDTO>> GetDashboardProducts(string userid, string langCode);
        public IResultData<List<ProductHomeListDTO>> GetHomeProducts(string langCode);

        IResult AddProductAdmin(string userId, ProductAddDTO productAdd);
        IResultData<List<ProductFeaturedDTO>> GetAllFeaturedProducts(string langCode);
        IResultData<ProductDetailDTO> GetProductById(int id, string langCode);
    }
}
