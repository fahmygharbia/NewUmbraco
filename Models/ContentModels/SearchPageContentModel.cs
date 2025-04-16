using NewUmbraco.Models.Search;
using NewUmbraco.Models.ViewModels;

namespace NewUmbraco.Models.ContentModels;

public class SearchPageContentModel(IPublishedContent? content) : ContentModel(content)
{
    public SearchRequestModel? SearchRequest { get; set; }
    public SearchResponseModel? SearchResponse { get; set; }
    public PaginationViewModel Pagination { get; set; }
}