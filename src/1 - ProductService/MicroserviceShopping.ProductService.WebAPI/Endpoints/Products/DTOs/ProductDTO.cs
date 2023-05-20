using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Endpoints.Products.DTOs
{
   public class ProductDTO
   {
      public int Id { get; set; }
      public string Name { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public ProductImagesDTO Images { get; set; } = new ProductImagesDTO();

      public int ManufacturerId { get; set; }

      public ProductDTO(Product product)
      {
         Id = product.Id;
         Name = product.Name;
         Description = product.Description;
         Images = new ProductImagesDTO(product.Images);
         ManufacturerId = product.ManufacturerId;
      }

      public ProductDTO()
      {
         // nothing to do
      }

      public Product ToDomainObject() => new(Id, Name, Description, Images.ToDomainObject(), ManufacturerId);
   }
}
