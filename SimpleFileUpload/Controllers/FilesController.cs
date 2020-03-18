namespace SimpleFileUpload.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SimpleFileUpload.Logic.Providers;
    using SimpleFileUpload.Logic.ViewModels;
    using SimpleFileUpload.Logic.ViewModels.Files;

    /// <summary>
    /// Controller working with files
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class FilesController : ControllerBase
    {
        private readonly ILogger<FilesController> logger;
        private readonly IFileStorageProvider fileStorageProvider;
        private readonly IUserStorageProvider userStorageProvider;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger">Logger</param>
        public FilesController(ILogger<FilesController> logger, IFileStorageProvider fileStorageProvider, IUserStorageProvider userStorageProvider)
        {
            this.logger = logger;
            this.fileStorageProvider = fileStorageProvider;
            this.userStorageProvider = userStorageProvider;
        }

        /// <summary>
        /// Gets list of group saved files
        /// </summary>
        /// <returns>List of group files</returns>
        [HttpGet]
        public async Task<List<FilesGroup>> Get()
        {

            return await this.fileStorageProvider.GetAllFilesAsync();
        }

        /// <summary>
        /// Uploading files
        /// </summary>
        /// <param name="files">List of uploading files</param>
        /// <returns>Upload result</returns>
        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var result = new List<OperationResult<Logic.ViewModels.Files.FileInfo>>();

            // TODO: Implement logic users register/autorize
            var user = await this.userStorageProvider.GetUserByToken(Guid.Empty.ToString());
            if (user == null)
            {
                await this.userStorageProvider.AddUser(new Logic.ViewModels.Users.UserViewModel { Name = "Test user", Token = Guid.Empty.ToString() });
                user = await this.userStorageProvider.GetUserByToken(Guid.Empty.ToString());
            }

            foreach (var formFile in files)
            {
                var fileInfo = new Logic.ViewModels.Files.FileInfo { Name = formFile.FileName, Size = formFile.Length, Date = DateTime.Now, UserName = string.Empty, Ext = Path.GetExtension(formFile.FileName), UserId = user.Id };
                if (formFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(stream);
                        var saveResult = await this.fileStorageProvider.SaveAsync(fileInfo, stream.ToArray());
                        result.Add(saveResult);
                    }
                }
                else
                {
                    result.Add(new OperationResult<Logic.ViewModels.Files.FileInfo> { OperationResult = OperationResultEnum.Error, Message = "Attached zero size file", Result = fileInfo });
                }
            }

            return Ok(result);
        }
    }
}
