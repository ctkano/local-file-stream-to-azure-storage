﻿using Azure.Storage.Blobs;
using System;

namespace AzureStreamer
{
    public class BlobStorageUploadFileStream
    {
        /// <summary>
        /// Upload file stream to Azure Blob Container using Shared Access Signature URI (SAS URI)
        /// </summary>
        /// <param name="sas_uri">Shared Access Signature URI (SAS URI).</param>
        /// <param name="blob_path">File Name and/or Path with Virtual Directory and File Name with Extension, that will be created in the Blob Container.</param>
        /// <param name="file_path">Local File Path with File Name and Extension.</param>
        /// <param name="allow_overwrite">Allow file overwrite in case of existance in the blob storage? When false, if a blob_path alread exists in the blob storage, it will return the following Status: 409 (The specified blob already exists.) and ErrorCode: BlobAlreadyExists. When true, the existing blob_path will be overwritten in the blob storage and no error is returned.</param>
        /// <returns>Success Flag</returns>
        public static bool SharedAccessSignatureURI(string sas_uri, string blob_path, string file_path, bool allow_overwrite)
        {
            //Blob container
            BlobContainerClient blobContainer = new BlobContainerClient(new Uri(sas_uri));

            //File Name with extension or Path with Virtual Directory and File Name with Extension, that will be created in the Blob Container
            BlobClient blobClient = blobContainer.GetBlobClient(blob_path);

            //Create or overwrite the blob with contents from the local file
            using (var fileStream = System.IO.File.OpenRead(file_path))
            {
                blobClient.Upload(fileStream, overwrite: allow_overwrite);
            }

            return true;
        }

        /// <summary>
        /// Upload file stream to Azure Blob Container using Storage Account's Connection String
        /// </summary>
        /// <param name="connection_string">Storage Account's Connection String.</param>
        /// <param name="blob_container_name">Azure Blob Container Name.</param>
        /// <param name="blob_path">File Name and/or Path with Virtual Directory and File Name with Extension, that will be created in the Blob Container.</param>
        /// <param name="file_path">Local File Path.</param>
        /// <param name="allow_overwrite">Allow file overwrite in case of existance in the blob storage? When false, if a blob_path alread exists in the blob storage, it will return the following Status: 409 (The specified blob already exists.) and ErrorCode: BlobAlreadyExists. When true, the existing blob_path will be overwritten in the blob storage and no error is returned.</param>
        /// <returns>Success Flag</returns>
        public static bool ConnectionString(string connection_string, string blob_container_name, string blob_path, string file_path, bool allow_overwrite)
        {
            //Blob container
            BlobContainerClient blobContainer = new BlobContainerClient(connection_string, blob_container_name);

            //File Name with extension or Path with Virtual Directory and File Name with Extension, that will be created in the Blob Container
            BlobClient blobClient = blobContainer.GetBlobClient(blob_path);

            //Create or overwrite the blob with contents from the local file
            using (var fileStream = System.IO.File.OpenRead(file_path))
            {
                blobClient.Upload(fileStream, overwrite: allow_overwrite);
            }

            return true;
        }
    }
}
