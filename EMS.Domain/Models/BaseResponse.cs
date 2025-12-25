namespace EMS.Domain.Models
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static BaseResponse<T> Success(T data, string message = "Success")
        {
            return new BaseResponse<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        public static BaseResponse<T> Error(string message)
        {
            return new BaseResponse<T>
            {
                IsSuccess = false,
                Message = message,
                Data = default
            };
        }
    }

}
