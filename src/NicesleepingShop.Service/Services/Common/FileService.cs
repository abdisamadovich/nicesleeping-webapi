using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NicesleepingShop.Service.Interfaces.Common;

namespace NicesleepingShop.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    //private readonly string AVATARS = "avatars";
    private readonly string ROOTPATH;
    public FileService(IWebHostEnvironment env)
    {
       
    }
    public Task<string> DelateAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> DelateImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }

    Task<bool> IFileService.DelateAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    Task<bool> IFileService.DeleteImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }
}
