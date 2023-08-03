

namespace NtierCommon.ResponseObjects;
public interface IResponse<T> : IResponse
{
    T Data { get; set; }
    List<CustomValidationErrorsResponse> CustomValidationErrorsResponses { get; set; }
}
