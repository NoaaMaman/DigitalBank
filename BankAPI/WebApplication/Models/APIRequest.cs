using static Bank_Utility.DS;

namespace WebApplication.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }
    }
}
