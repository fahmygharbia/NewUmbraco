using System.Collections.Generic;
using System.Linq;

using NewUmbraco.Models.ViewModels;


using Umbraco.Cms.Core.Web;

namespace NewUmbraco.Services;


public class SiteService : ISiteService
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public SiteService(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
        _umbracoContextFactory = umbracoContextFactory;
        bool hasUmbracoContext = _umbracoContextAccessor.TryGetUmbracoContext(out _);
    }
    public IEnumerable<MainSidebarModel> GetSideBarChildNodes()
    {
        var sidebarNode = GetSiteSectionRoot(SidebarPage.ModelTypeAlias).SafeCast<SidebarPage>();
        var childNodes = sidebarNode?.Children?
     .Where(x => x.IsPublished())
     .OfType<MainSidebar>()
     .Select(x => new MainSidebarModel(
         Id: x.Id,
         Name: x.Name,
         IsNewPage: x.NewPage,
         ReturnURL: x.NewPage ==true? x.Url() : string.Empty
     ))
     .AsEnumerable();

        return childNodes;
    }
    public PageContent GetContent(int id)
    {
        var content = (MainSidebar)GetContentAsPublishContent(id);
        if (content == null) return null;
        var isNewPage = content.NewPage;


        return new PageContent(IsNewPage: isNewPage, ReturnURl:
            isNewPage ? content.Url() : string.Empty,
            Model: content);
    }
    public MainSidebar GetSideBarContent(int id)
    {
        var content = GetContentAsPublishContent(id);
        if (content == null) return null;
        return content.SafeCast<MainSidebar>();
    }

    public IPublishedContent? GetContentAsPublishContent(int id)
    {
        using var context = _umbracoContextFactory.EnsureUmbracoContext();
        var content = context.UmbracoContext.Content?.GetById(id);
        if (content == null) return null;
        return content;
    }
    private IPublishedContent GetSiteSectionRoot(string ModelTypeAlias)
    {
        using var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext();
        var contentQuery = umbracoContextReference.UmbracoContext.Content;

        var requiredRoot = contentQuery?.GetAtRoot().FirstOrDefault().Children().Where(r => r.ContentType.Alias == ModelTypeAlias).FirstOrDefault();

        return requiredRoot;
    }

}
