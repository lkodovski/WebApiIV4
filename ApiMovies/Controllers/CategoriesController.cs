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
    }
}
