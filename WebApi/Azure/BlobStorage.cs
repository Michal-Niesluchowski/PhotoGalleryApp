using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi;


namespace WebApi.Azure
{
    public class BlobStorage
    {
        private IConfiguration _configuration;
        private readonly string CONTAINER_NAME = "photogallery-images";

        public BlobStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string AddImmageToBlob(string filePath, Guid fileId)
        {
            string connectionString = _configuration.GetConnectionString("StorageConnectionString");

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, CONTAINER_NAME);

            blobContainerClient.CreateIfNotExists(PublicAccessType.Blob);

            string fileExtension = Path.GetExtension(filePath);

            BlobClient blobClient = blobContainerClient.GetBlobClient(fileId.ToString() + fileExtension);

            blobClient.Upload(filePath);

            Debug.WriteLine(blobClient.Uri);

            return fileExtension;
        }
    }
}
