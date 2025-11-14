using B2Net;
using B2Net.Models;
using RodentBase_01.WebAPI.Application.Contracts.Infrastructure.Services;
using RodentBase_01.WebAPI.Infrastructure.Helpers;

namespace RodentBase_01.WebAPI.Infrastructure.Services;

public sealed class BackblazeStorageService : IStorageService
{
    private readonly B2Client _b2Client;

    public BackblazeStorageService(B2Client b2Client)
    {
        _b2Client = b2Client;
    }

    public async Task<string> UploadImageAsync(Stream fileStream, string fileName)
    {
        var processedStream = ImageProcessor.ResizeAndConvertToJpg(fileStream);

        var b2File = await _b2Client.Files.Upload(processedStream, new B2FileUploadContext()
        {
            FileName = fileName,
            B2UploadUrl = await _b2Client.Files.GetUploadUrl()
        });

        return b2File.FileId;
    }

    public async Task<Stream> DownloadFileAsync(string fileId)
    {
        var b2File = await _b2Client.Files.DownloadById(fileId);
        var memoryStream = new MemoryStream(b2File.FileData);
        memoryStream.Position = 0;

        return memoryStream;
    }
}