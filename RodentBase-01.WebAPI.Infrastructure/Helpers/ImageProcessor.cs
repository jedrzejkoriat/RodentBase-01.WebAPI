using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace RodentBase_01.WebAPI.Infrastructure.Helpers;

internal static class ImageProcessor
{
    public static Stream ResizeAndConvertToJpg(Stream inputStream)
    {
        using var image = Image.Load(inputStream);
        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(800, 800),
            Mode = ResizeMode.Max
        }));

        var outputStream = new MemoryStream();
        image.SaveAsJpeg(outputStream);
        outputStream.Position = 0;
        return outputStream;
    }
}