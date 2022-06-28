using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BaseController : Controller
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(errors);
            }
            else
            {
                if (next != null)
                {
                    await next();
                }
            }
        }
    }
}
