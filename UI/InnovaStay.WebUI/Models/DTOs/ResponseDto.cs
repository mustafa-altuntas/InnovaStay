namespace InnovaStay.WebUI.Models.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public bool Successful { get; set; }
    }
}
