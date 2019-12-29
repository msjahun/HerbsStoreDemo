using System.Collections.Generic;

namespace HerbsStore.Libraries.HS.Services.ImageServices
{
    public interface IImageService
    {
        string UploadProductImage();
        string ImageSplitter(string imageUrl, string imagePostfix);
        List<string> ImageSplitterList(List<string> imageUrls, string imagePostfix);
    }
}