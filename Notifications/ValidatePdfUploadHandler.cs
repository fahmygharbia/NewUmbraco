//using Umbraco.Cms.Core.Events;
//using Umbraco.Cms.Core.Notifications;

//public class ValidatePdfUploadHandler : INotificationHandler<MediaSavingNotification>
//{
//    public void Handle(MediaSavingNotification notification)
//    {
//        foreach (var media in notification.SavedEntities)
//        {
//            // تأكد إنه من نوع PDF File Media Type
//            if (media.ContentType.Alias == "pdfFile")
//            {
//                var filePath = media.GetValue<string>("umbracoFile");

//                if (!string.IsNullOrEmpty(filePath) && !filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
//                {
//                    // منع الحفظ برسالة خطأ
//                    notification.CancelOperation(new EventMessage(
//                        "Invalid File",
//                        "You can only upload PDF files.",
//                        EventMessageType.Error
//                    ));
//                }
//            }
//        }
//    }
//}
