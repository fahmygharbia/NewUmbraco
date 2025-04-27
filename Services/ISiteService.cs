using NewUmbraco.Models.ViewModels;

namespace NewUmbraco.Services;

public interface ISiteService
{
    IEnumerable<MainSidebarModel> GetSideBarChildNodes();
    PageContent GetContent(int id);
}
