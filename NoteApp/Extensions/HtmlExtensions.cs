using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NoteApp.Extensions
{
    public class NoController : Controller
    {
    }

    public static class HtmlExtensions
    {
        public static IHtmlContent CustomValidationSummary(this IHtmlHelper htmlHelper)
        {
            return htmlHelper.Partial("ValidationMessage", htmlHelper.ViewData.ModelState);
        }
    }
}
