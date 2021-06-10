using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsApp
{
    public static class FunctionCreateThumbnail
    {
        [FunctionName("FunctionCreateThumbnail")]
        public static void Run([BlobTrigger("photogallery-images/{name}", Connection = "")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
