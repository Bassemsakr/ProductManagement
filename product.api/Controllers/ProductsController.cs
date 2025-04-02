
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Products.Commands.Create;
using ProductManagement.Application.Products.Commands.Delete;
using ProductManagement.Application.Products.Commands.Update;
using ProductManagement.Application.Products.Queries.GetAll;
using ProductManagement.Application.Products.Queries.GetById;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _mediator.Send(new GetallProductQuery());
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = productId }, productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
