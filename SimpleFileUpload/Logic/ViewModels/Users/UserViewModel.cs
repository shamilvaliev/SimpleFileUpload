namespace SimpleFileUpload.Logic.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserViewModel
    {
        public int Id { get; set; }

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
