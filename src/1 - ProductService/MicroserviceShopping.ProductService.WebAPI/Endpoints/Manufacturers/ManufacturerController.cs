using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Upsert;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers
{
   [Route("api/v1/manufacturers")]
   [ApiController]
   public class ManufacturerController : ControllerBase
   {
      private readonly IMediator mediator;

      public ManufacturerController(IMediator mediator)
      {
         this.mediator = mediator;
      }

      [HttpGet]
      [Route("{Id}", Name = "GetById")]
      [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ManufacturerDTO))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      [SwaggerResponse((int)HttpStatusCode.NotFound)]
      public async Task<IActionResult> GetByIdAsync([FromRoute] GetManufacturerByIdQuery query, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(query, cancellationToken);

         if (result.WasFound)
            return Ok(result.Manufacturer);

         return NotFound();
      }

      [HttpPost]
      [Route("", Name = "Add")]
      [SwaggerResponse((int)HttpStatusCode.Created, type: typeof(ManufacturerDTO))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      public async Task<IActionResult> AddAsync([FromBody] AddManufacturerCommand command, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(command, cancellationToken);
         return GetCreatedResult(result.Manufacturer);
      }

      [HttpPut]
      [Route("{Id}", Name = "Upsert")]
      [SwaggerResponse((int)HttpStatusCode.Created, type: typeof(ManufacturerDTO))]
      [SwaggerResponse((int)HttpStatusCode.NoContent)]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      public async Task<IActionResult> UpsertAsync([FromBody] UpsertManufacturerCommand command, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(command, cancellationToken);

         if (result.WasAdded)
            return GetCreatedResult(result.Manufacturer);

         return NoContent();
      }

      private CreatedResult GetCreatedResult(ManufacturerDTO dto)
         => Created(Url.RouteUrl("GetById", new GetManufacturerByIdQuery() { Id = dto.Id }) ?? string.Empty, dto);
   }
}