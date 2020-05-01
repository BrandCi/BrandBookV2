using Azure.Storage.Blobs;
using BrandBook.Core.Services.Storage;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BrandBook.Services.Storage
{
    public class BlobStorageService : IStorageService
    {
        #region Fields
        private readonly BlobContainerClient _blobServiceClient;
        #endregion


        /// <summary>
        /// BlobStorageService
        /// Contains Methods for working with Azure Blob Storage
        /// Check Api-Reference: https://docs.microsoft.com/en-us/dotnet/api/azure.storage.blobs.blobcontainerclient?view=azure-dotnet
        /// </summary>
        public BlobStorageService()
        {
            var storageConnectionString = ConfigurationManager.ConnectionStrings["BlobStorageConnection"].ToString();
            var containerName = ConfigurationManager.AppSettings["BlobStorageContainer"];

            _blobServiceClient = new BlobContainerClient(storageConnectionString, containerName);

            _blobServiceClient.CreateIfNotExists();
        }

    }
}
