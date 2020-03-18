namespace SimpleFileUpload.Domain.Models
{
    /// <summary>
    /// File entity
    /// </summary>
    public class FileModel : ModelBase
    {
        /// <summary>
        /// File size in bytes
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// File name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Extension
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// File upload user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// File upload user
        /// </summary>
        public virtual UserModel User { get; set; }

        /// <summary>
        /// Conent of file
        /// </summary>
        public virtual FileContentModel Content { get; set; }
    }
}
