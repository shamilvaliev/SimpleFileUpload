namespace SimpleFileUpload.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SimpleFileUpload.ViewModels.Files;

    /// <summary>
    /// Controller working with files
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class FilesController : ControllerBase
    {
        private static List<FileInfo> savedFiles = new List<FileInfo>();

        private readonly ILogger<FilesController> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger">Logger</param>
        public FilesController(ILogger<FilesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets list of group saved files
        /// </summary>
        /// <returns>List of group files</returns>
        [HttpGet]
        public List<FilesGroup> Get()
        {
            return savedFiles.GroupBy(t => t.Ext).Select(t => new FilesGroup { Name = t.Key, Files = t.ToList() }).ToList();
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

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    savedFiles.Add(new FileInfo { Name = formFile.FileName, Size = formFile.Length, Date = DateTime.Now, UserName = string.Empty, Ext = System.IO.Path.GetExtension(formFile.FileName) });
                    //var filePath = Path.GetTempFileName();

                    //using (var stream = System.IO.File.Create(filePath))
                    //{
                    //    await formFile.CopyToAsync(stream);
                    //}
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }
    }
}
