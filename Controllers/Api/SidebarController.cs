using Microsoft.AspNetCore.Mvc;

using NewUmbraco.Controllers.Api;
using NewUmbraco.Services;
using Umbraco.Cms.Core.Web;

[ApiController]
[Route("api/sidebar")]
public class SidebarController : ControllerBase
{
    private readonly ISiteService _siteService;
    private readonly IUmbracoContextFactory _context;

    public SidebarController(ISiteService siteService, IUmbracoContextFactory context)
    {
        _siteService = siteService;
        _context = context;
    }

    [HttpGet("content/{nodeId:int}")]
     public async Task<IActionResult> GetSidebarContent(int nodeId, [FromServices] ViewRenderer viewRenderer)
    {
        try
        {
            var content = _siteService.GetSideBarContent(nodeId);
            if (content == null)
                return NotFound("Node not found");

            var html = await viewRenderer.RenderViewToStringAsync(
                ControllerContext,
                "_SidebarPageContent",
                content
            );

            return Content(html, "text/html");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }   

}



