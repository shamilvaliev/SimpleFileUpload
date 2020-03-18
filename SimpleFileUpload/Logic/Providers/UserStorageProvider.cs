namespace SimpleFileUpload.Logic.Providers
{
    using Microsoft.EntityFrameworkCore;
    using SimpleFileUpload.Domain;
    using SimpleFileUpload.Logic.Extensions.ModelExtensions;
    using SimpleFileUpload.Logic.ViewModels.Users;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Users storage provider
    /// </summary>
    public class UserStorageProvider : IUserStorageProvider
    {
        private readonly FileUploadContext context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context">Db context</param>
        public UserStorageProvider(FileUploadContext context)
        {
            this.context = context;
        }

        public async Task AddUser(UserViewModel user)
        {
            this.context.Users.Add(new Domain.Models.UserModel { CreatedOn = DateTime.Now, Name = user.Name, Token = user.Token });
            await this.context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUserByName(string name)
        {
            return (await this.context.Users.FirstOrDefaultAsync(t => t.Name == name)).ToViewModel();
        }

        public async Task<UserViewModel> GetUserByToken(string token)
        {
            return (await this.context.Users.FirstOrDefaultAsync(t => t.Token == token)).ToViewModel();
        }
    }
}
