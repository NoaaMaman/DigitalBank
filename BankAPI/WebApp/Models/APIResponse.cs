namespace WebApp.Models
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessage { get; internal set; }
    }
}
