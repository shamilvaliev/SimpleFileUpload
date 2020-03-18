namespace SimpleFileUpload.Domain.Models
{
    using System;

    /// <summary>
    /// Base model
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Entity save date and time
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
