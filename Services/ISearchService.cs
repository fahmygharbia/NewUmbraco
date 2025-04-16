using NewUmbraco.Models.Search;

namespace NewUmbraco.Services;

public interface ISearchService
{
    public SearchResponseModel Search(SearchRequestModel searchRequest);
}