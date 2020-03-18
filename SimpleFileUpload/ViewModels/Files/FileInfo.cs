namespace SimpleFileUpload.ViewModels.Files
{
    using System;

    /// <summary>
    /// Uploaded file info
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        /// File name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File size
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Upload date and time
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Upload user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// File extension
        /// </summary>
        public string Ext { get; set; }
    }
}
