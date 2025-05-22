using AutoMapper;
using AutoMapper.QueryableExtensions;
using CourseManagement.Data;
using CourseManagement.DTO;
using CourseManagement.Entity;
using CourseManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<APIResponse<PagedResponse<CourseResponse>>> GetFilteredAsync(FilterBase filter)
        {
            var query = _context.Courses
                .Where(c => !c.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(c => c.Title.Contains(filter.Search));
            }

            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                query = filter.SortDesc
                    ? query.OrderByDescending(e => EF.Property<object>(e, filter.SortBy))
                    : query.OrderBy(e => EF.Property<object>(e, filter.SortBy));
            }

            var total = await query.CountAsync();

            var items = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ProjectTo<CourseResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return APIResponse<PagedResponse<CourseResponse>>.Ok(new PagedResponse<CourseResponse>
            {
                Items = items,
                TotalCount = total
            });
        }


        public async Task<APIResponse<List<CourseResponse>>> GetAllAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            var result = _mapper.Map<List<CourseResponse>>(courses);
            return APIResponse<List<CourseResponse>>.Ok(result);
        }

        public async Task<APIResponse<CourseResponse>> GetByIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return APIResponse<CourseResponse>.Fail("Course not found");

            var result = _mapper.Map<CourseResponse>(course);
            return APIResponse<CourseResponse>.Ok(result);
        }

        public async Task<APIResponse<CourseResponse>> CreateAsync(CourseRequest request)
        {
            var course = _mapper.Map<Course>(request);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<CourseResponse>(course);
            return APIResponse<CourseResponse>.Ok(result, "Course created successfully");
        }

        public async Task<APIResponse<CourseResponse>> UpdateAsync(int id, CourseRequest request)
        {
            var existing = await _context.Courses.FindAsync(id);
            if (existing == null) return APIResponse<CourseResponse>.Fail("Course not found");

            _mapper.Map(request, existing);
            existing.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<CourseResponse>(existing);
            return APIResponse<CourseResponse>.Ok(result, "Course updated successfully");
        }

        public async Task<APIResponse<bool>> DeleteAsync(int id)
        {
            var existing = await _context.Courses.FindAsync(id);
            if (existing == null || existing.IsDeleted)
                return APIResponse<bool>.Fail("Course not found");

            existing.IsDeleted = true;
            existing.DeletedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return APIResponse<bool>.Ok(true, "Course soft-deleted");
        }

    }

}
