namespace YogaVision.Core.Contracts
{
    using Microsoft.AspNetCore.Http;
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
