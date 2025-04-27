using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace NewUmbraco.Controllers.Api;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using System.IO;
using System.Threading.Tasks;

public class ViewRenderer
{
    private readonly ICompositeViewEngine _viewEngine;
    private readonly ITempDataProvider _tempDataProvider;

    public ViewRenderer(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider)
    {
        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
    }

    public async Task<string> RenderViewToStringAsync(ControllerContext controllerContext, string viewName, object model)
    {
        var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), controllerContext.ModelState)
        {
            Model = model
        };

        var tempData = new TempDataDictionary(controllerContext.HttpContext, _tempDataProvider);

        using (var writer = new StringWriter())
        {
            var viewResult = _viewEngine.FindView(controllerContext, viewName, false);

            if (!viewResult.Success)
            {
                throw new Exception($"A view with the name {viewName} could not be found");
            }

            var viewContext = new ViewContext(
                controllerContext,
                viewResult.View,
                viewData,
                tempData,
                writer,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return writer.ToString();
        }
    }
}
