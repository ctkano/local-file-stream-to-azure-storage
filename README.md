# Local File Stream To Azure Storage
Local file stream to azure storage is a class library to help automating the upload local files stream to Azure Storage. 

Files extracted from sources (such as from data base) and stored in a local computer, can be uploaded to Azure Storage dinamically and automated, by referencing this class library in an automate project.

## What is the difference by implementing an automated project to stream files to Azure Blob Storage and using the MS Azure Storage Explorer?
You can create an automated project that collects files from a variety of sources that stores them locally and use this library to help your project to upload them to a container. You do not need to wait until the automated project finishes the processing to upload the extracted files to a container. This library could help your project to upload extrated files on demand. After the file is extracted and locally stored your automated project could get this file, use the library to stream it to a blob storage and then your automated project could delete it in order to make room in your disk space.

## Azure storage upload option available in this class
* Azure Blob Storage

## Project Type
* Class library

## Language
* C#

## Platform and Version
* .NET Framework 4.8
