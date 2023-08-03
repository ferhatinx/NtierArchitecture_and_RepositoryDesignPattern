

namespace NtierCommon.ResponseObjects;

public class Response : IResponse
{
    public Response(ResponseType responseType)
    {
        responseType = ResponseType;
    }
    public Response(ResponseType responseType, string message) : this(responseType)
    {
        message = Message;
    }


    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }
}
public enum ResponseType
{
    Success,
    ValidationError,
    NotFound

}
