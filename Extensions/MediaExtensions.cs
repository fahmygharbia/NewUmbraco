
namespace NewUmbraco.Extensions
{
    public static class MediaExtensions
    {
        public static MediaFileDetails GetFileDetails(this IPublishedContent mediaItem)
        {
            if (mediaItem == null) return null!;

            var sizeBytes = mediaItem.Value<long>("umbracoBytes");
            var format = mediaItem.Value<string>("umbracoExtension");
            var updateDate = mediaItem.UpdateDate;

            return new MediaFileDetails
            {
                SizeMB = Math.Round(sizeBytes / 1024.0 / 1024.0, 1),
                Format = format?.ToUpperInvariant()!,
                UpdatingDate = updateDate
            };
        }
    }



    public class MediaFileDetails
    {
        public double SizeMB { get; set; }
        public string Format { get; set; }
        public DateTime UpdatingDate { get; set; }
    }



}
