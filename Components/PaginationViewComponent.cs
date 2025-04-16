using Microsoft.AspNetCore.Mvc;

using NewUmbraco.Models.ViewModels;

namespace NewUmbraco.Components;

[ViewComponent(Name = "Pagination")]
public class PaginationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(PaginationViewModel model)
    {
        model ??= new PaginationViewModel();

        return View(model);
    }
}