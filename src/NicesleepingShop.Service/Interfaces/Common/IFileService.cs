using Microsoft.AspNetCore.Http;

namespace NicesleepingShop.Service.Interfaces.Common;

public interface IFileService
{
    // returns sub path of this image
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);
    
}
