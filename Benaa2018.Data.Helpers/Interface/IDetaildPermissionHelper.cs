using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public interface IDetaildPermissionHelper
    {
        //Task<DetaildPermissionViewModel> GetUserDetailsInfoByInfo(int UserId);
        Task<List<DetaildPermissionViewModel>> GetUserDetailsInfoByInfo(int UserId, int caseSet);

        Task<DetaildPermissionViewModel> SaveUserDetailsAsync(DetaildPermissionViewModel detaildPermissionViewModel);
        Task<int> UpdateUserDetails(int UserId, DetaildPermissionViewModel detaildPermissionViewModel);
    }
}
