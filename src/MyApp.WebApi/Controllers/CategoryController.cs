using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.CQ_ItemCategory.Queries;
using MyApp.Application.CQRS.CQ_ItemCategory.Commands;

namespace MyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("V1/add")]
        public async Task<IActionResult> Add(AddCategoryCommand command)
        {
            var res = await _mediator.Send(command);

            if (res == 1)
            {
                return Ok(new { Message = "Category already exists!" });
            }
            else
            {
                return Ok(new { Message = "Category added successfully!" });
            }
        }
        [HttpPut("V1/update")]
        public async Task<IActionResult> Update(UpdateAddCategoryCommand command)
        {
            var res = await _mediator.Send(command);
            if (res == 1)
            {
                return Ok(new { Message = "Category already exists!" });
            }
            else
            {
                return Ok(new { Message = "Category Update successfully!" });
            }
        }

        // ✅ GET: api/Category
        [HttpGet("V1/getall")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetAllCategorysQuery());
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);

            if (result == null)
                return NotFound(new { Message = $"Item Category with Id {id} not found." });

            return Ok(result);
        }

    }
}
