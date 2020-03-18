namespace SimpleFileUpload.Logic.ViewModels
{
    /// <summary>
    /// Generic operaton result
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    public class OperationResult<TResult>: OpertationResultBase
    {
        /// <summary>
        /// Result
        /// </summary>
        public TResult Result { get; set; }
    }
}
