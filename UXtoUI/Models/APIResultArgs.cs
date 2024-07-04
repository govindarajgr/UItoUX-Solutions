namespace UItoUX.Models
{
    public class APIResultArgs
    {
        public long StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public object? ResultData { get; set; }
    }
}
