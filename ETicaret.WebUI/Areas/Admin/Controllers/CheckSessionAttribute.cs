using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CheckSessionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var session = context.HttpContext.Session;
        // Örnek: "UserId" diye bir session anahtarına bakıyoruz
        if (string.IsNullOrEmpty(session.GetString("UserId")))
        {
            // Eğer session yoksa giriş sayfasına yönlendir
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
        base.OnActionExecuting(context);
    }
}
