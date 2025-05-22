namespace CourseManagement.DTO
{
    public class CourseRequest
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Instructor { get; set; } = null!;

        public bool IsCompleted { get; set; }
    }

}
