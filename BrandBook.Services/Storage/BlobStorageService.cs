using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using BrandBook.Core.Services.Storage;
using Microsoft.Extensions.Azure;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BrandBook.Services.Storage
{
    public class BlobStorageService : IStorageService
    {
        #region Fields
        private readonly BlobContainerClient _containerClient;
        private readonly string _containerPublicUrl;
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

            _containerClient = new BlobContainerClient(storageConnectionString, containerName);
            _containerPublicUrl = _containerClient.Uri.AbsoluteUri;

            _containerClient.CreateIfNotExists();
        }


        public string GetItemUrlByRelativePath(string relativePath)
        {
            var selectedBlob = _containerClient.GetBlobs(prefix: relativePath).FirstOrDefault();

            if (selectedBlob == null) return "";

            return _containerPublicUrl + relativePath;
        }

    }
}
