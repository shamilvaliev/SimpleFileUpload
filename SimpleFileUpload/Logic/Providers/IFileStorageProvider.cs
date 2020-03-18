namespace SimpleFileUpload.Logic.Providers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using SimpleFileUpload.Logic.ViewModels;
    using SimpleFileUpload.Logic.ViewModels.Files;
    using FileInfo = ViewModels.Files.FileInfo;

    /// <summary>
    /// Interface file storage provider
    /// </summary>
    public interface IFileStorageProvider
    {
        /// <summary>
        /// Save file to storage
        /// </summary>
        /// <param name="bytes">File info witch be saved</param>
        /// <returns>Save result</returns>
        Task<OperationResult<FileInfo>> SaveAsync(FileInfo fileInfo, byte[] bytes);

        /// <summary>
        /// Get all group files
        /// </summary>
        /// <returns>List groups</returns>
        Task<List<FilesGroup>> GetAllFilesAsync();
    }
}
