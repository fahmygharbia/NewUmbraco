using Microsoft.AspNetCore.Mvc;

using NewUmbraco.Models.Search;

namespace NewUmbraco.Components;

[ViewComponent(Name = "SearchResults")]
public class SearchResultsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(SearchResponseModel model)
    {
        return View(model);
    }
}