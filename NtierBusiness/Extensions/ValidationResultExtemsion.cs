

using FluentValidation.Results;
using NtierCommon.ResponseObjects;

namespace NtierBusiness.Extensions;

public static class ValidationResultExtemsion
{
    public static List<CustomValidationErrorsResponse> ConvertToValidationResult(this ValidationResult validationResult)
    {
        var convertedErrors = new List<CustomValidationErrorsResponse>();
        foreach (var error in validationResult.Errors)
        {
            convertedErrors.Add(new CustomValidationErrorsResponse() { ErrorMessage=error.ErrorMessage,PropertyName=error.PropertyName});
        }
        return convertedErrors;
    }
}
