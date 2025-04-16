using Microsoft.AspNetCore.Mvc;

using NewUmbraco.Models.ViewModels;

namespace NewUmbraco.Components;

[ViewComponent(Name = "Contact")]
public class ContactViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(ContactViewModel model)
    {
        model ??= new ContactViewModel();

        return View(model);
    }
}