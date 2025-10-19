using B2Net;
using B2Net.Models;
using ConsoleApp1;


var keyId = "0ca375256ed7";
var applicationKey = "00312cdab88bac889bc5ef8e52111c95427cb2ca0d";
var bucketId = "90ecfab357f5f2d5969e0d17";


var options = new B2Options
{
    KeyId = keyId,
    ApplicationKey = applicationKey,
    BucketId = bucketId
};

var b2Client = new B2Client(options, authorizeOnInitialize: true);


var storageService = new BackblazeStorageService(b2Client);

using var testStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("Hello B2Net!"));
var fileName = $"test-{Guid.NewGuid()}.txt";

try
{
    var fileId = await storageService.UploadImageAsync(testStream, fileName);
    Console.WriteLine($"Plik wysłany! FileId: {fileId}");

    var downloadedStream = await storageService.DownloadFileAsync(fileId);
    using var reader = new StreamReader(downloadedStream);
    var content = await reader.ReadToEndAsync();
    Console.WriteLine($"Pobrana zawartość: {content}");
}
catch (Exception ex)
{
    Console.WriteLine($"Błąd: {ex.Message}");
}

Console.WriteLine("Test zakończony.");
Console.ReadLine();
