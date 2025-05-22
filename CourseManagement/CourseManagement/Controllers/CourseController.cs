using CourseManagement.DTO;
using CourseManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _courseService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await _courseService.GetByIdAsync(id));

        [HttpPost("filter")]
        public async Task<IActionResult> Filter([FromBody] FilterBase filter)
            => Ok(await _courseService.GetFilteredAsync(filter));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseRequest request)
            => Ok(await _courseService.CreateAsync(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseRequest request)
            => Ok(await _courseService.UpdateAsync(id, request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _courseService.DeleteAsync(id));
    }

}
