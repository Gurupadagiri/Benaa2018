using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class GroupMasterHelper : IGroupMasterHelper
    {
        private readonly IGroupMasterRepository _groupMasterDetailsHelper;

        public GroupMasterHelper(IGroupMasterRepository groupMasterRepository)
        {
            _groupMasterDetailsHelper = groupMasterRepository;
        }
        public Task<GroupMasterViewModel> DeleteGroupMasterViewModelDetails(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GroupMasterViewModel>> GetGroupMasterViewModelById(int groupMasterDetailsId)
        {
            List<GroupMasterViewModel> lstgroupMasterModel = new List<GroupMasterViewModel>();
            var grpMasterInfo = await _groupMasterDetailsHelper.GetAllAsync();
            grpMasterInfo = grpMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (groupMasterDetailsId > 1)
            {
                grpMasterInfo = grpMasterInfo.Where(a => a.Group_Id == groupMasterDetailsId).ToList();
            }
            grpMasterInfo.ToList().ForEach(item =>
            {
                lstgroupMasterModel.Add(new GroupMasterViewModel
                {
                    GroupId = item.Group_Id,
                    GroupCode = item.Group_Code,
                    GroupName = item.Group_Name,
                    Sequence = item.Sequence,
                    OrgId = item.Org_Id,
                    Status = item.Status,
                    IsDeleted = item.Is_Deleted,
                    GroupDescription=item.GroupMasterDescription
                });
            });
            return lstgroupMasterModel;
        }

        public Task<List<GroupMasterViewModel>> GetGroupMasterViewModelByParam(string title = "", int status = 0, string priority = "")
        {
            throw new NotImplementedException();
        }

        public async Task<List<GroupMasterViewModel>> GetGroupMasterViewModelDetails(string groupCode = "", int caseStat = 0)
        {
            List<GroupMasterViewModel> lstgroupMasterModel = new List<GroupMasterViewModel>();
            var grpMasterInfo = await _groupMasterDetailsHelper.GetAllAsync();
            grpMasterInfo = grpMasterInfo.Where(a => a.Is_Deleted == false).ToList();
            if (caseStat == 0)
            {
                if (!string.IsNullOrEmpty(groupCode))
                {
                    grpMasterInfo = grpMasterInfo.Where(a => a.Group_Code == groupCode).ToList();
                }
            }
            else
            {
                grpMasterInfo = grpMasterInfo.Where(a => a.Status = true).ToList();
            }
            if (grpMasterInfo?.Count() > 0)
            {


                grpMasterInfo.ToList().ForEach(item =>
                {
                    lstgroupMasterModel.Add(new GroupMasterViewModel
                    {
                        GroupId = item.Group_Id,
                        GroupCode = item.Group_Code,
                        GroupName = item.Group_Name,
                        Sequence = item.Sequence,
                        OrgId = item.Org_Id,
                        Status = item.Status,
                        IsDeleted = item.Is_Deleted,
                        GroupDescription=item.GroupMasterDescription
                    });
                });
            }
            return lstgroupMasterModel;
        }

        public async Task<GroupMasterViewModel> SaveGroupMasterViewModelDetails(GroupMasterViewModel grpMasterViewModel)
        {
            GroupMaster grpMaster = new GroupMaster()
            {
                Group_Code = grpMasterViewModel.GroupCode,
                Group_Name = grpMasterViewModel.GroupName,
                Sequence = grpMasterViewModel.Sequence,
                Org_Id = grpMasterViewModel.OrgId,
                Status = grpMasterViewModel.Status,
                Is_Deleted = grpMasterViewModel.IsDeleted,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today,
                GroupMasterDescription = grpMasterViewModel.GroupDescription
            };

            var grouppMaster = await _groupMasterDetailsHelper.CreateAsync(grpMaster);
            GroupMasterViewModel grpMsterViewModel = new GroupMasterViewModel()
            {
                GroupId = grouppMaster.Group_Id
            };

            return grpMsterViewModel;
        }

        public async Task<GroupMasterViewModel> UpdateGroupMasterViewModelDetails(GroupMasterViewModel grpMasterViewModel)
        {
            GroupMaster grpMaster = new GroupMaster()
            {
                Group_Id = grpMasterViewModel.GroupId,
                Group_Code = grpMasterViewModel.GroupCode,
                Group_Name = grpMasterViewModel.GroupName,
                Sequence = grpMasterViewModel.Sequence,
                Org_Id = grpMasterViewModel.OrgId,
                Status = grpMasterViewModel.Status,
                Is_Deleted = grpMasterViewModel.IsDeleted,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today,
                GroupMasterDescription=grpMasterViewModel.GroupDescription
            };

            var grouppMaster = await _groupMasterDetailsHelper.UpdateAsync(grpMaster);
            GroupMasterViewModel grpMsterViewModel = new GroupMasterViewModel()
            {
                GroupId = grouppMaster.Group_Id
            };

            return grpMsterViewModel;
        }
    }
}
