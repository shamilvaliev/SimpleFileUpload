namespace SimpleFileUpload.Logic.Extensions.ModelExtensions
{
    using SimpleFileUpload.Domain.Models;
    using SimpleFileUpload.Logic.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class UsersModelExtensions
    {
        /// <summary>
        /// Map to view model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>View model</returns>
        public static UserViewModel ToViewModel(this UserModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new UserViewModel { Name = model.Name, Id = model.Id, Token = model.Token };
        }
    }
}
