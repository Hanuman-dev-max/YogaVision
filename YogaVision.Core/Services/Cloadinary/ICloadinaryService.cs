


namespace YogaVision.Core.Services.Cloadinary
{
    using Microsoft.AspNetCore.Http;
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
