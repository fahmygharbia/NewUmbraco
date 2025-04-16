namespace NewUmbraco.Configuration;

public class NewUmbracoConfig
{
    public const string SectionName = "NewUmbraco";
    public EmailSettings? EmailSettings { get; set; }
    public SearchSettings? SearchSettings { get; set; }
}

public class EmailSettings
{
    public string? From { get; set; }
    public string? To { get; set; }
}

public class SearchSettings
{
    public int PageSize { get; set; }
}