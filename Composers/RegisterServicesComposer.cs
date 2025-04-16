using NewUmbraco.Services;

using Umbraco.Cms.Core.Composing;

namespace NewUmbraco.Composers;

public class RegisterServicesComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddTransient<ISearchService, SearchService>();
    }
}