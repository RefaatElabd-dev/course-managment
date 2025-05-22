namespace CourseManagement.DTO
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }

        public static APIResponse<T> Ok(T data, string? message = null) =>
            new() { Success = true, Message = message, Data = data };

        public static APIResponse<T> Fail(string message) =>
            new() { Success = false, Message = message };
    }

}
