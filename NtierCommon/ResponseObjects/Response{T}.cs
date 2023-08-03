
namespace NtierCommon.ResponseObjects;

public class Response<T> : Response, IResponse<T>
{
	public T Data { get; set; }
	public List<CustomValidationErrorsResponse> CustomValidationErrorsResponses { get; set; }
    public Response(ResponseType responseType) : base(responseType)
    {
        
    }
    public Response(ResponseType responseType,T data) : base(responseType)
	{
		Data = data; 
	}
	public Response(ResponseType responseType, string message) : base(responseType,message)
	{

	}
	public Response(ResponseType responseType,T data, List<CustomValidationErrorsResponse> customValidationErrorsResponses) : base(responseType)
	{
		Data= data;
		customValidationErrorsResponses = CustomValidationErrorsResponses;
	}
}
