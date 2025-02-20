using ApiMovies.Models;
using ApiMovies.Models.Dtos;
using ApiMovies.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var listCategories = _ctRepo.GetCategories();
            var listCategoriesDto = new List<CategoryDto>();
            foreach (var category in listCategories)
            {
                listCategoriesDto.Add(_mapper.Map<CategoryDto>(category));
            }
            return Ok(listCategoriesDto);
        }

        [HttpGet("{categoryId:int}", Name ="GetCategory")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory(int categoryId)
        {
            var itemCategory = _ctRepo.GetCategory(categoryId);
            if(itemCategory == null)
            {
                return NotFound();
            }
            var itemCategoryDto = _mapper.Map<CategoryDto>(itemCategory);
            return Ok(itemCategoryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        { 
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(createCategoryDto == null)
            {
                return BadRequest(ModelState);
            }

            if(_ctRepo.ExistCategory(createCategoryDto.Name))
            {
                ModelState.AddModelError("", "Category alredy exist");
                return StatusCode(404, ModelState);
            }
            var category = _mapper.Map<Category>(createCategoryDto);
            if(!_ctRepo.CreateCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong with saving category {category.Name}");
                return StatusCode(404, ModelState);
            }
            return CreatedAtRoute("GetCategory", new { categoryId = category.Id }, category);
        }
    }
}
