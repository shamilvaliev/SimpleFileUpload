namespace SimpleFileUpload.Logic.Providers
{
    using SimpleFileUpload.Logic.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Users storage provider interface
    /// </summary>
    public interface IUserStorageProvider
    {
        Task<UserViewModel> GetUserByName(string name);
        Task<UserViewModel> GetUserByToken(string token);

        Task AddUser(UserViewModel user);
    }
}
