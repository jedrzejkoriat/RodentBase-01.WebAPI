using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2Net.Models;
using B2Net;

namespace ConsoleApp1;
public sealed class BackblazeStorageService
{
    private readonly B2Client _b2Client;

    public BackblazeStorageService(B2Client b2Client)
    {
        _b2Client = b2Client;
    }

    public async Task<string> UploadImageAsync(Stream fileStream, string fileName)
    {

        var b2File = await _b2Client.Files.Upload(fileStream, new B2FileUploadContext()
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