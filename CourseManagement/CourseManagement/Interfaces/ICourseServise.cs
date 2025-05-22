using CourseManagement.DTO;

namespace CourseManagement.Interfaces
{
    public interface ICourseService
    {
        Task<APIResponse<PagedResponse<CourseResponse>>> GetFilteredAsync(FilterBase filter);

        Task<APIResponse<List<CourseResponse>>> GetAllAsync();
        Task<APIResponse<CourseResponse>> GetByIdAsync(int id);
        Task<APIResponse<CourseResponse>> CreateAsync(CourseRequest request);
        Task<APIResponse<CourseResponse>> UpdateAsync(int id, CourseRequest request);
        Task<APIResponse<bool>> DeleteAsync(int id);
    }

}
