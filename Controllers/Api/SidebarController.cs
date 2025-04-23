using Microsoft.AspNetCore.Mvc;

using NewUmbraco.Services;

using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

public class SidebarController : UmbracoApiController
{
    private readonly IUmbracoContextFactory _context;
   // private readonly ISiteService _siteService;

    public SidebarController(IUmbracoContextFactory contextFactory )
    {
        _context = contextFactory;
      //  _siteService = siteService;

    }

    //[HttpGet]
    // public IActionResult GetContent(int id)
    //{
    //    var pageContent = _siteService.GetContent(id);

    //    if (pageContent == null)
    //    {
    //        return NotFound();
    //    }

    //    return Json(new
    //    {
    //        isNewPage = pageContent.IsNewPage,
    //        returnUrl = pageContent.ReturnURl
    //    });
    //}

    //[HttpGet]
    //public IActionResult GetContentHtml(int id)
    //{
    //    var pageContent = _siteService.GetContent(id);

    //    if (pageContent == null || pageContent.IsNewPage)
    //    {
    //        return NotFound();
    //    }

    //    return PartialView("~/Views/Partials/_BlockGridContent.cshtml", pageContent.Model);
    //}
}
