using System.ComponentModel.DataAnnotations.Schema;

public class Response
{
    public string RequestID => $"{Guid.NewGuid().ToString()}";

    public string ResponseCode { get; set; }

    public string ResponseMessage { get; set; }

    //[NotMapped]
    public object Data { get; set; }
}
