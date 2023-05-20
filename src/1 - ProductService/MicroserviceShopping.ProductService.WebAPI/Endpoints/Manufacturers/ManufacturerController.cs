using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add;
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
      [Route("", Name = "GetById")]
      [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(GetManufacturerByIdQueryResult))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      public async Task<IActionResult> GetByIdAsync([FromQuery] GetManufacturerByIdQuery query, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(query, cancellationToken);
         return Ok(result);
      }

      [HttpPost]
      [Route("", Name = "Add")]
      [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(AddManufacturerCommandResult))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      public async Task<IActionResult> RegisterAsync([FromBody] AddManufacturerCommand command, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(command, cancellationToken);
         return Created(Url.RouteUrl("GetById", new GetManufacturerByIdQuery() { Id = result.Manufacturer.Id }) ?? string.Empty, result.Manufacturer);
      }
   }
}