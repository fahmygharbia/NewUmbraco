using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

public class SidebarController : UmbracoApiController
{
    private readonly IUmbracoContextFactory _context;

    public SidebarController(IUmbracoContextFactory contextFactory)
    {
        _context = contextFactory;
    }

    [HttpGet]
    public IActionResult GetContent(int id)
    {
        using var context = _context.EnsureUmbracoContext();
        var content = context.UmbracoContext.Content?.GetById(id);
        if (content == null) return NotFound();

        return new ViewResult
        {
            ViewName = "~/Views/Partials/_BlockGridContent.cshtml",
            ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IPublishedContent>(
                new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
            {
                Model = content
            }
        };
    }
}
