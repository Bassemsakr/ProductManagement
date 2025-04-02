
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Categories.Commands.Create;
using ProductManagement.Application.Categories.Commands.Delete;
using ProductManagement.Application.Categories.Commands.Update;
using ProductManagement.Application.Categories.Queries.GetAll;
using ProductManagement.Application.Categories.Queries.GetById;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _mediator.Send(new GetAllCategoryQuery() );
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(category);
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = categoryId }, categoryId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
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
            await _mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }
    }
}
