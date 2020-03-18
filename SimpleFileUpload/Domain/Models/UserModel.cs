namespace SimpleFileUpload.Domain.Models
{
    /// <summary>
    /// User entity
    /// </summary>
    public class UserModel : ModelBase
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}
