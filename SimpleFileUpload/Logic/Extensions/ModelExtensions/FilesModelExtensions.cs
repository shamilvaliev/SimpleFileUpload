namespace SimpleFileUpload.Logic.Extensions.ModelExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SimpleFileUpload.Domain.Models;
    using SimpleFileUpload.Logic.ViewModels.Files;

    /// <summary>
    /// Extensions to map models to viewmodels
    /// </summary>
    public static class FilesModelExtensions
    {
        /// <summary>
        /// Map model to viewmodel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<FilesGroup> ToViewModel(this IEnumerable<FileModel> model)
        {
            return model.GroupBy(t => t.Ext).Select(t => new FilesGroup { Name = t.Key, Files = t.ToFileViewModel() }).ToList();
        }

        public static List<FileInfo> ToFileViewModel(this IEnumerable<FileModel> model)
        {
            return model.Select(t => t.ToViewModel()).ToList();
        }

        public static FileInfo ToViewModel(this FileModel model)
        {
            return new FileInfo
            {
                Date = model.CreatedOn,
                Ext = model.Ext,
                Name = model.Name,
                Size = model.Size,
                UserName = model.User.Name
            };
        }
    }
}
