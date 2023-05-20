using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Endpoints.Products.DTOs
{
   public class ProductWithoutIdDTO
   {
      public string Name { get; set; }
      public string Description { get; set; }
      public ProductImagesDTO Images { get; set; }

      public int ManufacturerId { get; set; }

      public ProductWithoutIdDTO(Product product)
      {
         Name = product.Name;
         Description = product.Description;
         Images = new ProductImagesDTO(product.Images);
         ManufacturerId = product.ManufacturerId;
      }

      public Product ToDomainObject() => new(id: 0, Name, Description, Images.ToDomainObject(), ManufacturerId);
   }
}
