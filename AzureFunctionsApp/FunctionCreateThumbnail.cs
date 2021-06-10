using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace AzureFunctionsApp
{
    public static class FunctionCreateThumbnail
    {
        private static readonly int _imageHeight = 200;
        private static readonly int _imageWidth = 200;

        [FunctionName("FunctionCreateThumbnail")]
        public static void Run([BlobTrigger("photogallery-images/{name}", Connection = "")]
            Stream myBlob, string name, TraceWriter log)
        {
            using (Image image = Image.Load(myBlob))
            {
                image.Mutate(x => x.Resize(_imageWidth, _imageHeight));
                
                log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n  Size: {myBlob.Length} Bytes");
            }
        }
    }
}
