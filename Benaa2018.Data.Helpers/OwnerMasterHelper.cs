using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class OwnerMasterHelper : IOwnerMasterHelper
    {
        private readonly IOwnerMasterRepoisitory _ownerMasterRepoisitory;
        public OwnerMasterHelper(IOwnerMasterRepoisitory ownerMasterRepoisitory)
        {
            _ownerMasterRepoisitory = ownerMasterRepoisitory;
        }

        /// <summary>
        /// Owner Master Model
        /// </summary>
        /// <param name="OwnerMasterModel"></param>
        /// <returns></returns>
        public async Task<int> SaveOwnerMasterAsync(int projectID, OwnerMasterViewModel OwnerMasterModel)
        {
            OwnerMaster ownerMaster = new OwnerMaster
            {
                AccessMethod = OwnerMasterModel.AccessMethod,
                Active = OwnerMasterModel.Active,
                Address = OwnerMasterModel.Address,
                AllowLockedSelections = OwnerMasterModel.AllowLockedSelections,
                AllowOrderRequests = OwnerMasterModel.AllowOrderRequests,
                AllowPaymentsTab = OwnerMasterModel.AllowPaymentsTab,
                AllowWarrantyClaims = OwnerMasterModel.AllowWarrantyClaims,
                City = OwnerMasterModel.City,
                Mobile_No = OwnerMasterModel.MobileNo,
                Org_ID = OwnerMasterModel.OwnerID,
                OwnerActivation = OwnerMasterModel.OwnerActivation,
                OwnerCalendar = OwnerMasterModel.OwnerCalendar,
                OwnerInformation = OwnerMasterModel.OwnerInformation,
                Owner_ID = OwnerMasterModel.OwnerID,
                Owner_Name = OwnerMasterModel.OwnerName,
                //Profile_Picture = OwnerMasterModel.ProfilePicture,
                ShowBudgetPurchaseOrders = OwnerMasterModel.ShowBudgetPurchaseOrders,
                ShowProjectPrice = OwnerMasterModel.ShowProjectPrice,
                Telephone = OwnerMasterModel.Telephone,
                Project_ID = projectID
            };
            var ownerInfo = await _ownerMasterRepoisitory.CreateAsync(ownerMaster);
            return ownerInfo.Owner_ID;
        }

        public async Task<int> UpdateOwnerMaster(int projectID, OwnerMasterViewModel OwnerMasterModel)
        {
            var owner = await _ownerMasterRepoisitory.GetAllAsync();
            var ownerMasterInfo = owner.Where(a => a.Project_ID == projectID).FirstOrDefault();
            //var ownerMasterInfo = await _ownerMasterRepoisitory.GetAllAsync().Result.Where(a => a.Project_ID == projectID).ToList().FirstOrDefault();
            if (ownerMasterInfo == null)
            {
                await SaveOwnerMasterAsync(projectID, OwnerMasterModel);
            }
            ownerMasterInfo.State = OwnerMasterModel.State;
            ownerMasterInfo.Zip = OwnerMasterModel.Zip;
            ownerMasterInfo.Email = OwnerMasterModel.Email;
            ownerMasterInfo.AccessMethod = OwnerMasterModel.AccessMethod;
            ownerMasterInfo.Active = OwnerMasterModel.Active;
            ownerMasterInfo.Address = OwnerMasterModel.Address;
            ownerMasterInfo.AllowLockedSelections = OwnerMasterModel.AllowLockedSelections;
            ownerMasterInfo.AllowOrderRequests = OwnerMasterModel.AllowOrderRequests;
            ownerMasterInfo.AllowPaymentsTab = OwnerMasterModel.AllowPaymentsTab;
            ownerMasterInfo.AllowWarrantyClaims = OwnerMasterModel.AllowWarrantyClaims;
            ownerMasterInfo.City = OwnerMasterModel.City;
            ownerMasterInfo.Mobile_No = OwnerMasterModel.MobileNo;
            ownerMasterInfo.Org_ID = OwnerMasterModel.OwnerID;
            ownerMasterInfo.OwnerActivation = OwnerMasterModel.OwnerActivation;
            ownerMasterInfo.OwnerCalendar = OwnerMasterModel.OwnerCalendar;
            ownerMasterInfo.OwnerInformation = OwnerMasterModel.OwnerInformation;
            ownerMasterInfo.Owner_Name = OwnerMasterModel.OwnerName;
            //ownerMasterInfo.Profile_Picture = OwnerMasterModel.ProfilePicture;
            ownerMasterInfo.ShowBudgetPurchaseOrders = OwnerMasterModel.ShowBudgetPurchaseOrders;
            ownerMasterInfo.ShowProjectPrice = OwnerMasterModel.ShowProjectPrice;
            ownerMasterInfo.Telephone = OwnerMasterModel.Telephone;
            ownerMasterInfo.Project_ID = projectID;
            var ownerInfo = await _ownerMasterRepoisitory.UpdateAsync(ownerMasterInfo);
            return ownerInfo.Owner_ID;
        }

        public async Task<OwnerMasterViewModel> GetOwnerInfoByInfo(int projectID)
        {
            var owner = await _ownerMasterRepoisitory.GetAllAsync().ConfigureAwait(true);
            var ownerInfo = owner.Where(a => a.Project_ID == projectID).FirstOrDefault();
            if (ownerInfo != null)
            {
                OwnerMasterViewModel ownerModel = new OwnerMasterViewModel
                {
                    AccessMethod = ownerInfo.AccessMethod,
                    Active = ownerInfo.Active,
                    Address = ownerInfo.Address,
                    AllowLockedSelections = ownerInfo.AllowLockedSelections,
                    AllowOrderRequests = ownerInfo.AllowOrderRequests,
                    AllowPaymentsTab = ownerInfo.AllowPaymentsTab,
                    AllowWarrantyClaims = ownerInfo.AllowWarrantyClaims,
                    City = ownerInfo.City,
                    Email = ownerInfo.Email,
                    MobileNo = ownerInfo.Mobile_No,
                    OrgID = ownerInfo.Org_ID,
                    OwnerActivation = ownerInfo.OwnerActivation,
                    OwnerCalendar = ownerInfo.OwnerCalendar,
                    OwnerID = ownerInfo.Owner_ID,
                    OwnerInformation = ownerInfo.OwnerInformation,
                    OwnerName = ownerInfo.Owner_Name,
                    //ProfilePicture = ownerInfo.Profile_Picture,
                    ProjectID = ownerInfo.Project_ID,
                    ShowBudgetPurchaseOrders = ownerInfo.ShowBudgetPurchaseOrders,
                    ShowProjectPrice = ownerInfo.ShowProjectPrice,
                    State = ownerInfo.State,
                    Telephone = ownerInfo.Telephone,
                    Zip = ownerInfo.Zip
                };
                return ownerModel;
            }
            return new OwnerMasterViewModel();
        }
    }
}
