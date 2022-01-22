using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.ViewComponents
{
    [Authorize]
    public class BranchInfoViewComponent : ViewComponent
    {
        private readonly IRegistrationCore _registration;

        public BranchInfoViewComponent(IRegistrationCore registration)
        {
            _registration = registration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string filter)
        {
            var model = await _registration.GetAsync(User.Identity.Name);
            return View("Default", model.Data);
        }
    }
}
