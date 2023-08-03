using Microsoft.AspNetCore.Mvc;
using NtierCommon.ResponseObjects;

namespace NtierUi.Extensions
{
    public static class ControlExtension
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response,string actionName,string controllerName)
        {
            if(response.ResponseType == ResponseType.NotFound)
               controller.NotFound();
            if(response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.CustomValidationErrorsResponses)
                {
                    controller.ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName, controllerName);
            
        }
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if(response.ResponseType == ResponseType.NotFound)
               return controller.NotFound();
            return controller.View(response.Data);
        }
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName, string controllerName)
        {
            if (response.ResponseType == ResponseType.NotFound)
                controller.NotFound();
            return controller.RedirectToAction(actionName, controllerName);

        }
    }
}
