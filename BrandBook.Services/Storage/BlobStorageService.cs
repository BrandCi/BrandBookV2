using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public BlobStorageService()
        {
            var storageConnectionString = ConfigurationManager.ConnectionStrings["BlobStorageConnection"].ToString();
            var containerName = ConfigurationManager.AppSettings["BlobStorageContainer"];

            _blobServiceClient = new BlobContainerClient(storageConnectionString, containerName);

            _blobServiceClient.CreateIfNotExists();

        }

    }
}
