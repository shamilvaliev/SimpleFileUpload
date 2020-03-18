namespace SimpleFileUpload.Logic.Providers
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using SimpleFileUpload.Domain;
    using SimpleFileUpload.Logic.ViewModels;
    using SimpleFileUpload.Logic.ViewModels.Files;
    using SimpleFileUpload.Logic.Extensions.ModelExtensions;
    using FileInfo = ViewModels.Files.FileInfo;
    using SimpleFileUpload.Domain.Models;

    /// <summary>
    /// Provider working with file storage
    /// </summary>
    public class FileStorageProvider : IFileStorageProvider
    {
        private readonly FileUploadContext context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context">Db context</param>
        public FileStorageProvider(FileUploadContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Save file to storage
        /// </summary>
        /// <param name="bytes">File info witch be saved</param>
        /// <returns>Save result</returns>
        public async Task<OperationResult<FileInfo>> SaveAsync(FileInfo fileInfo, byte[] bytes)
        {
            try
            {
                var file = new FileModel { CreatedOn = DateTime.Now, Ext = fileInfo.Ext, Name = fileInfo.Name, Size = fileInfo.Size, UserId = fileInfo.UserId, Content = new FileContentModel { Bytes = bytes } };
                this.context.Files.Add(file);
                await this.context.SaveChangesAsync();
                return this.SuccessResult();
            }
            catch (Exception ex)
            {
                return new OperationResult<FileInfo>() { Message = ex.Message, OperationResult = OperationResultEnum.Error, Result = fileInfo };
            }
        }

        /// <summary>
        /// Get all group files
        /// </summary>
        /// <returns>List groups</returns>
        public Task<List<FilesGroup>> GetAllFilesAsync()
        {
            return Task.FromResult(context.Files.Include(t => t.User).ToViewModel());
        }

        private OperationResult<FileInfo> SuccessResult()
        {
            return new OperationResult<FileInfo>();
        }
    }
}
