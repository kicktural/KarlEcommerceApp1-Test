using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public record ProductFeaturedDTO(int id, /*string SeoUrl,*/ string ProductName, decimal Price, decimal Discount, string PhotoUrl);
        public record ProductRecentDTO(int id,  string ProductName, decimal Price, decimal Discount, string PhotoUrl);
    }
}
