using AutoMapper;
using CourseManagement.Data;
using CourseManagement.DTO;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Services;
using CourseManagement.Mapper;

namespace CourseServiceTests
{
    public class CourseServiceTests
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly CourseService _service;

        public CourseServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CourseProfile>());
            _mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new ApplicationDbContext(options);
            _service = new CourseService(_context, _mapper);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddCourse()
        {
            var request = new CourseRequest
            {
                Title = "Test Course",
                Description = "Description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(5),
                Instructor = "John",
                IsCompleted = false
            };

            var result = await _service.CreateAsync(request);

            Assert.True(result.Success);
            Assert.Equal("Test Course", result.Data?.Title);
        }
    }

}