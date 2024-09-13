namespace BookingSystem.Shared.Services.Base
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? ValidationErrors { get; set; }
    }
    public class ApiResponse
        {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? ValidationErrors { get; set; }
    }
}