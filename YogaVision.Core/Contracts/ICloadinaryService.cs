namespace YogaVision.Core.Contracts
{
    using Microsoft.AspNetCore.Http;
    
    /// <summary>
    /// Interface Cloudinary Service
    /// </summary>
    public interface ICloudinaryService
    {
        /// <summary>
        /// Upload Picture
        /// </summary>
        /// <param name="pictureFile"></param>
        /// <param name="fileName">The name of the file</param>
        /// <returns></returns>
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
