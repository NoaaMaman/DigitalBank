namespace BankAPI.Models
{
    public class Response
    {
        public string RequestID => $"{Guid.NewGuid().ToString()}";

        public string ResponseCode { get; set; } 
        
        public string ResponseMessage { get; set; } 

        public object Data { get; set; }
    }
}
