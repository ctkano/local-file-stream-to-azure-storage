# Local File Streaming To Azure
Local file streaming to azure is a library to help automating the transfering from local files to Azure Blob Storage. 

Files extracted from sources such as data base and stored in a local computer, can be streamed to Azure Blob Storage dinamically and automated, by referenicing this library in an automate project.

## What is the difference by implementing an automate project to stream files to Azure Blob Storage and using the MS Azure Storage Explorer?
You can create an automated project that collects files from a variety of sources that stores them locally and use this library to help your project to stream them to a blob container. You do not need to wait until the automated project finishes the processing to upload the extracted files to a blob container. This library helps your project to stream extrated files and stored locally on demand. After the file is extracted and locally stored your automated project could get this file, use the library to stream it to a blob container and then your automated project could delete it in order to make room in your disk space.

## Language
* C#

## Platform and Version
* .NET Framework 4.8

## Project Type
* Class library