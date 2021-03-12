# Local File Stream To Azure Storage
Local file stream to azure storage is a class library to help automating the upload local files stream to Azure Storage. 

Files extracted from sources (such as from data base) and stored in a local computer, can be uploaded to Azure Storage dinamically and automated, by referencing this class library in an automate project.

## What is the difference by implementing an automated project to stream files to Azure Blob Storage and using the MS Azure Storage Explorer?
You can create an automated project that collects files from a variety of sources that stores them locally and use this library to help your project to upload them to a container. You do not need to wait until the automated project finishes the processing to upload the extracted files to a container. This library could help your project to upload extrated files on demand. After the file is extracted and locally stored your automated project could get this file, use the library to stream it to a blob storage and then your automated project could delete it in order to make room in your disk space.

## Azure storage covered in this project
* Azure Blob Storage

## Project Type
* Class library

## Language
* C#

## Platform and Version
* .NET Framework 4.8

## Example of Usage
To upload file stream to Azure Blob Container using Shared Access Signature URI (SAS URI):
```C#
//Shared Access Signature URI (SAS URI).
string sas_uri = "<sas_uri>";

//File Name and/or Path with Virtual Directory and File Name with Extension, that will be created in the Blob Container.
string blob_path = "sample-blob/sample-file.txt";

//Local File Path with File Name and Extension.
string file_path = "C:\\Main_Directory\\File_Directory\\sample-file.txt";

//Flag to indicate if it is allowed the file overwrite in case of existance in the blob storage.
//When false, if a blob_path alread exists in the blob storage, it will return the following Status: 409 (The specified blob already exists.) and ErrorCode: BlobAlreadyExists.
//When true, the existing blob_path will be overwritten in the blob storage and no error is returned.
bool allow_overwrite = true;

//If successful it will return true. If not, an error will be thrown.
bool return = AzureStreamer.BlobStorageUploadFileStream.SharedAccessSignatureURI(sas_uri, blob_path, file_path, allow_overwrite);
```

To upload file stream to Azure Blob Container using Storage Account's Connection String:
```C#
//Storage Account's Connection String.
string connection_string = "<connection_string>";

//Azure Blob Container Name.
string blob_container_name = "blob_container_name";

//File Name and/or Path with Virtual Directory and File Name with Extension, that will be created in the Blob Container.
string blob_path = "sample-blob/sample-file.txt";

//Local File Path with File Name and Extension.
string file_path = "C:\\Main_Directory\\File_Directory\\sample-file.txt";

//Flag to indicate if it is allowed the file overwrite in case of existance in the blob storage.
//When false, if a blob_path alread exists in the blob storage, it will return the following Status: 409 (The specified blob already exists.) and ErrorCode: BlobAlreadyExists.
//When true, the existing blob_path will be overwritten in the blob storage and no error is returned.
bool allow_overwrite = true;

//If successful it will return true. If not, an error will be thrown.
bool return = AzureStreamer.BlobStorageUploadFileStream.ConnectionString(connection_string, blob_container_name, blob_path, file_path, allow_overwrite);
```

## Useful information
For more detail and information, please refer :point_right:: [Azure Storage Blobs client library for .NET](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs)
