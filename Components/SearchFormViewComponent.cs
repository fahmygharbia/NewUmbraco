using Microsoft.AspNetCore.Mvc;

using NewUmbraco.Models.Search;

namespace NewUmbraco.Components;

[ViewComponent(Name = "SearchForm")]
public class SearchFormViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(SearchRequestModel model)
    {
        return View(model);
    }
}