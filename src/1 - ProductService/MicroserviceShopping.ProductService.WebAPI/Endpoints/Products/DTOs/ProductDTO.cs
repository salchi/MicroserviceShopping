using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Endpoints.Products.DTOs
{
   public class ProductDTO
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public ProductImagesDTO Images { get; set; }

      public int ManufacturerId { get; set; }

      public ProductDTO(Product product)
      {
         Id = product.Id;
         Name = product.Name;
         Description = product.Description;
         Images = new ProductImagesDTO(product.Images);
         ManufacturerId = product.ManufacturerId;
      }
   }
}
