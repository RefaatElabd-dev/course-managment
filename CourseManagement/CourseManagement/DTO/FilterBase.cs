namespace CourseManagement.DTO
{
    public class FilterBase
    {
        public string? Search { get; set; }
        public string? SortBy { get; set; } = "CreatedDate";
        public bool SortDesc { get; set; } = true;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
