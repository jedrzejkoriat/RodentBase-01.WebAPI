namespace RodentBase_01.WebAPI.Application.Contracts.Infrastructure;

public interface IStorageService
{
    Task<string> UploadImageAsync(Stream fileStream, string fileName);
    Task<Stream> DownloadFileAsync(string fileId);
}
