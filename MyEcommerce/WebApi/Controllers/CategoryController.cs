using Application.Categories.Command;
using Application.Categories.Command.DeleteCategory;
using Application.Categories.Command.UpdateCategory;
using Application.Categories.Queries.GetCategories;
using Application.Categories.Queries.GetCategoryById;
using Application.Products.Queries.GetProductsByCategoryId;
using AutoMapper;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        
        [HttpGet("{CategoryId}/Products")]
        public async Task<IActionResult> GetProductsByCategory(Guid CategoryId)
        {
            var query = new GetProductsByCategoryIdQuery
            {
                CategoryId = CategoryId
            };

            var listOfProducts = await _mediator.Send(query);
            var dtoListOfProducts = _mapper.Map<List<ProductDto>>(listOfProducts);

            return Ok(dtoListOfProducts);
        }
        


        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid categoryId)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = categoryId
            };

            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<CategoryDto>(result);
            return Ok(dtoResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoriesQuery();

            var result = await _mediator.Send(query);
            var dtoResult = _mapper.Map<List<CategoryDto>>(result);
            return Ok(dtoResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto category)
        {
            var command = new CreateCategoryCommand
            {
                Name = category.Name
            };
            var id = await _mediator.Send(command);

            return Created($"/Category/{id}", null);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery { Id = categoryId });
            var command = new DeleteCategoryCommand { Category = category };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(CategoryDto newCategory, Guid categoryId)
        {
           
            var command = new UpdateCategoryCommand
            {
                Name = newCategory.Name,
                Id = categoryId
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
