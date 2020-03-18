namespace SimpleFileUpload.Logic.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Enum peration results
    /// </summary>
    public enum OperationResultEnum
    {
        /// <summary>
        /// Success
        /// </summary>
        Success = 0,

        /// <summary>
        /// Error
        /// </summary>
        Error = 1,
    }

    /// <summary>
    /// Base class of operation results
    /// </summary>
    public class OpertationResultBase
    {
        /// <summary>
        /// Operation result
        /// </summary>
        public OperationResultEnum OperationResult { get; set; }

        /// <summary>
        /// Returning message
        /// </summary>
        public string Message { get; set; }
    }
}
