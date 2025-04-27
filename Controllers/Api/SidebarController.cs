using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using NewUmbraco.Services;

using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

[ApiController]
[Route("api/sidebar")]
public class SidebarController : ControllerBase
{
    private readonly ISiteService _siteService;

    public SidebarController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    [HttpGet("content/{nodeId:int}")]
    public IActionResult GetSidebarContent(int nodeId)
    {
        try
        {
            var node = _siteService.GetContent( nodeId);

            if (node == null)
                return NotFound("Node not found");

            // Return HTML or JSON based on your requirements
            return Ok(new { HtmlContent =node.Model });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }




 
    //[HttpGet("content/{nodeId:int}")]
    //public IActionResult GetSidebarContent_2(int nodeId)
    //{
    //    try
    //    {
    //        var node = _siteService.GetContent(nodeId);

    //        if (node == null)
    //            return NotFound("Node not found");

    //        // Use Umbraco's PartialViewRenderer to render Block Grid HTML
    //        string htmlContent = RenderBlockGridHtml(node);

    //        return Ok(new { HtmlContent = htmlContent });
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, $"Error: {ex.Message}");
    //    }
    //}

    //// Helper method to render Block Grid HTML
    //private string RenderBlockGridHtml(IPublishedContent node)
    //{
    //    using (var scope = _context.EnsureUmbracoContext())
    //    {
    //        var htmlHelper = new HtmlHelper(scope.UmbracoContext);

    //        // Render the Block Grid HTML
    //        return htmlHelper.GetBlockGridHtml(node, "mainContent").ToHtmlString();
    //    }
    //}

}



