using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThangNguyen.GlobalTicket.EventCatalog.Infrastructure.Repositories;
using ThangNguyen.GlobalTicket.EventCatalog.Models;

namespace ThangNguyen.GlobalTicket.EventCatalog.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAsyncCategories()
        {
            var categories= await _categoryRepository.GetCategories();
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }
    }
}
