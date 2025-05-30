﻿using NewUmbraco.Models.ViewModels;

namespace NewUmbraco.Services;

public interface ISiteService
{
    IEnumerable<MainSidebarModel> GetSideBarChildNodes();
    IEnumerable<MainSidebarModel> GetTabAreas();
    PageContent GetContent(int id);
}
