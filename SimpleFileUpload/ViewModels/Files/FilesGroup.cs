namespace SimpleFileUpload.ViewModels.Files
{
    using System.Collections.Generic;

    /// <summary>
    /// Files group
    /// </summary>
    public class FilesGroup
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List files in group
        /// </summary>
        public List<FileInfo> Files { get; set; }
    }
}
