using BismillahGraphicsPro.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BismillahGraphicsPro.Web.ViewComponents
{
    [Authorize]
    public class ProfileViewComponent : ViewComponent
    {
        private readonly IRegistrationCore _registration;

        public ProfileViewComponent(IRegistrationCore registration)
        {
            _registration = registration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _registration.GetUserAsync(User.Identity.Name);
            return View("Default", model.Data);
        }
    }
}
