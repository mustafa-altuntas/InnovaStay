namespace InnovaStay.Dto.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public bool Successful { get; set; }

        public static ResponseDto<T> CreateInstance()
            => new ResponseDto<T>();

        public static ResponseDto<T> Success(T data, int statusCode)
        => new ResponseDto<T> { Data = data, StatusCode = statusCode, Successful = true };

        public static ResponseDto<NoDataDto> SuccessNoData(int statusCode)
            => new ResponseDto<NoDataDto> { StatusCode = statusCode, Successful = true };

        public static ResponseDto<NoDataDto> Fail(List<string> errors, int statusCode)
            => new ResponseDto<NoDataDto> { Errors = errors, StatusCode = statusCode, Successful = false };

        public static ResponseDto<NoDataDto> Fail(string error, int statusCode)
            => new ResponseDto<NoDataDto> { Errors = new List<string> { error }, StatusCode = statusCode, Successful = false };
    }
}
