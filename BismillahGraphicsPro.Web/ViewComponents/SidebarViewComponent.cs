using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.ViewComponents
{
    [Authorize]
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IRegistrationCore _registration;

        public SidebarViewComponent(IRegistrationCore registration)
        {
            _registration = registration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _registration.GetSideNavbarAsync(User.Identity.Name);
            return View("Default", model);
        }
    }
}
