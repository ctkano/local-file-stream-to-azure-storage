using AzureStreamer.Objects;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStreamer
{
    public class Stream
    {
        /// <summary>
        /// Streaming to Azure Blob Container using Shared Access Signature URI (SAS URI)
        /// </summary>
        /// <param name="sas_uri">Shared Access Signature URI (SAS URI)</param>
        /// <param name="blob">Blob Name / Path</param>
        /// <param name="file_path">Local File Path with File Name and Extension</param>
        public static void SharedAccessSignatureURI(string sas_uri, string blob, string file_path)
        {
            //Azure storage access information
            AzureAccessObjects azureAccessObjects = SegretateSASURI(sas_uri);

            ///Storage credentials
            StorageCredentials credentials = new StorageCredentials(azureAccessObjects.Token);

            //Blob container
            CloudBlobContainer container = new CloudBlobContainer(new Uri(azureAccessObjects.URI), credentials);

            //File name and extension or file path for Azure Blob Storage
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blob);

            //Create or overwrite the blob with contents from the local file
            using (var fileStream = System.IO.File.OpenRead(file_path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        /// <summary>
        /// Streaming to Azure Blob Container using Storage Account's Connection String
        /// </summary>
        /// <param name="storage_account">Azure Storage Account Name</param>
        /// <param name="blob_container">Blob Container Name</param>
        /// <param name="blob">Blob Name / Path</param>
        /// <param name="file_path">Local File Path</param>
        public static void ConnectionString(string storage_account, string blob_container, string blob, string file_path)
        {
            //Connection string from the storage account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storage_account);

            //Blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Blob container name
            CloudBlobContainer container = blobClient.GetContainerReference(blob_container);

            //File name and extension or file path for Azure Blob Storage
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blob);

            //Create or overwrite the blob with contents from the local file
            using (var fileStream = System.IO.File.OpenRead(file_path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        /// <summary>
        /// Get Azure storage access information by segregating the Shared Access Signature URI (SAS URI)
        /// </summary>
        /// <param name="sas_uri">Shared Access Signature URI (SAS URI)</param>
        /// <returns>Azure storage access information</returns>
        private static AzureAccessObjects SegretateSASURI(string sas_uri)
        {            
            return new AzureAccessObjects()
            {
                URI = sas_uri.Split('?')[0],
                Token = sas_uri.Split('?')[1]
            };
            //Useful reference: https://docs.microsoft.com/en-us/azure/storage/common/storage-sas-overview#sas-token
        }
    }
}
