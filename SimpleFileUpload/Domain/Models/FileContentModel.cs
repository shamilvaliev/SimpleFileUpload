namespace SimpleFileUpload.Domain.Models
{
    /// <summary>
    /// File content bytes
    /// </summary>
    public class FileContentModel
    {
        /// <summary>
        /// Ref to file
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// Ref to file
        /// </summary>
        public virtual FileModel File { get; set; }
    }
}
