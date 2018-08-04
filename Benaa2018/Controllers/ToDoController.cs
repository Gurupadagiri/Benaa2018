using Benaa2018.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Helper.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Benaa2018.Controllers
{
    public class ToDoController : BaseController
    {
        private readonly IMenuMasterHelper _menuMasterHelper;
        private readonly IOwnerMasterHelper _ownerMasterHelper;
        private readonly IProjectColorHelper _projectColorHelper;
        private readonly IProjectGroupHelper _projectGroupHelper;
        private readonly IProjectMasterHelper _projectMasterHelper;
        private readonly IProjectScheduleMasterHelper _projectScheduleMasterHelper;
        private readonly IProjectStatusMasterHelper _projectStatusMasterHelper;
        private readonly ISubContractorHelper _subContractorHelper;
        private readonly IUserMasterHelper _userMasterHelper;
        private readonly ICompanyMasterHelper _companyMasterHelper;
        private readonly IToDoMasterDetailsHelper _todoMasterDetailsHelper;
        private readonly ITagMasterHelper _tagMasterHelper;
       private readonly IToDoTagHelper _tagToDoHelper;
        public ToDoController(IMenuMasterHelper menuMasterHelper,
            IOwnerMasterHelper ownerMasterHelper,
            IProjectColorHelper projectColorHelper,
            IProjectGroupHelper projectGroupHelper,
            IProjectMasterHelper projectMasterHelper,
            IProjectScheduleMasterHelper projectScheduleMasterHelper,
            IProjectStatusMasterHelper projectStatusMasterHelper,
            ISubContractorHelper subContractorHelper,
            IToDoMasterHelper toDoMasterHelper,
            IUserMasterHelper userMasterHelper,
            IWarrentyAlertHelper warrentyAlertHelper,
            IToDoMasterDetailsHelper tomasterDetails,
           ITagMasterHelper tagMasterHelper,
           IToDoTagHelper toDoTagHelper,
            ICompanyMasterHelper companyMasterHelper) : base(menuMasterHelper,
            ownerMasterHelper,
            projectColorHelper,
            projectGroupHelper,
            projectMasterHelper,
            projectScheduleMasterHelper,
            projectStatusMasterHelper,
            subContractorHelper,
            userMasterHelper,
         
            companyMasterHelper)
        {
            _menuMasterHelper = menuMasterHelper;
            _ownerMasterHelper = ownerMasterHelper;
            _projectColorHelper = projectColorHelper;
            _projectGroupHelper = projectGroupHelper;
            _projectMasterHelper = projectMasterHelper;
            _projectScheduleMasterHelper = projectScheduleMasterHelper;
            _projectStatusMasterHelper = projectStatusMasterHelper;
            _subContractorHelper = subContractorHelper;
            _userMasterHelper = userMasterHelper;
            _companyMasterHelper = companyMasterHelper;
            _todoMasterDetailsHelper = tomasterDetails;
           _tagMasterHelper = tagMasterHelper;
            _tagToDoHelper = toDoTagHelper;
        }
        public async Task<IActionResult> Index()
        {
            var tagsList = GetAllTags();
            ViewBag.TagsList = tagsList.Result;
            ViewBag.TotalCheckList = 3;

            //var ownersList = GetAllOwners();
            //ViewBag.OwnersList = ownersList.Result;

            //var subContractorsList = GetAllSubContractors();
            //ViewBag.SubContractorsList = subContractorsList.Result;

            var differentUsersList = GetAllDifferentUsers();
            ViewBag.SubContractorsList = differentUsersList.Result;

           // ViewBag.SubContractorsList1= new SelectList(, "UserOwnerDifferentTypeId", "UserOwnerDifferentTypeValue", "UserOriginaTypeText", 1);
            return View();
        }


        
        //[HttpPost]
        //public async Task<IActionResult> Index(ToDoAllViewModel inputModel)
        //{
        //    return View();
        //}

        [HttpPost]
        //[RequestFormSizeLimit(valueCountLimit: 20000)]
        public async Task<IActionResult> SaveToDo(ToDoAllViewModel toDoAllView)
        {
            string result = string.Empty;
            var objToDoPrimary = _todoMasterDetailsHelper.SaveToDoMasterDetails(toDoAllView.ToDoDetails);
            //var obj = await _userMasterHelper.SaveUserMaster(userMasterViewModel);
            if(objToDoPrimary.Id>0)
            {
                if(toDoAllView.TagIds.Length>0)
                {
                    foreach(var item in toDoAllView.TagIds)
                    {
                        ToDoTagViewModel tagview = new ToDoTagViewModel()
                        {
                            Tagid = (int)item,//objToDoPrimary.Id
                            TodoDetailsID = 1
                        };

                        var objToTagSave = _tagToDoHelper.SaveToDoTagDetails(tagview);
                    }
                }
            }
            //string[] selitems = toDoAllView.g
            return Json(result);
        }



        public async Task<List<UserOwnerDifferentTypeViewModel>> GetAllDifferentUsers()
        {
            List<UserOwnerDifferentTypeViewModel> lstOwners1 = new List<UserOwnerDifferentTypeViewModel>();
            try
            {
                int index = 0;
                


                //List<OwnerMasterViewModel> lstOwners = new List<OwnerMasterViewModel>();
               var  lstOwners=GetAllOwners();
                var lstInternalUsers = GetAllUsers();
                var lstSubContractors = GetAllSubContractors();
                if(lstOwners.Result.Count>0)
                {
                    foreach(var item in lstOwners.Result)
                    {
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel() {
                            UserOwnerDifferentTypeId = index + 1,
                            UserOriginalId = item.OwnerID,
                            UserOriginaTypeId = 1,
                            UserOriginaTypeText = "Owners",
                            UserOwnerDifferentTypeValue =  item.OwnerName
                        };
                        lstOwners1.Add(item1);
                    }
                }
                if (lstInternalUsers.Result.Count > 0)
                {
                    foreach (var item in lstInternalUsers.Result)
                    {
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel()
                        {
                            UserOwnerDifferentTypeId = index + 1,
                            UserOriginalId = item.UserID,
                            UserOriginaTypeId = 2,
                            UserOriginaTypeText = "Internal Users",
                            UserOwnerDifferentTypeValue =  item.FullName
                        };
                        lstOwners1.Add(item1);
                    }
                }
                if (lstSubContractors.Result.Count > 0)
                {
                    foreach (var item in lstSubContractors.Result)
                    {
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel()
                        {
                            UserOwnerDifferentTypeId = index + 1,
                            UserOriginalId = item.SubContractorID,
                            UserOriginaTypeId = 3,
                            UserOriginaTypeText = "Subs",
                            UserOwnerDifferentTypeValue = item.SubcontractorName
                        };
                        lstOwners1.Add(item1);
                    }
                }

            }
            catch (System.Exception ex)
            {

            }
            return lstOwners1;
        }
        private async Task<List<TagMasterViewModel>> GetAllTags()
        {
            List<TagMasterViewModel> lstTags = new List<TagMasterViewModel>();
            try
            {
                var obj1 = await _tagMasterHelper.GetAllTagMasterDetails();
                if (obj1.Count > 0)
                {
                    //    return lstUsers = new List<SelectListUser>
                    //    {
                    //        lstUsers.Add(obj1.SelectMany());
                    //};
                    foreach (var item in obj1)
                    {
                        TagMasterViewModel selectListTag = new TagMasterViewModel
                        {
                            TagId = item.TagId,
                            TagName = item.TagName
                        };
                        lstTags.Add(selectListTag);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstTags;
        }


        public async Task<List<OwnerMasterViewModel>> GetAllOwners()
        {
            List<OwnerMasterViewModel> lstOwners = new List<OwnerMasterViewModel>();
            try
            {
                var obj1 = await _ownerMasterHelper.GetAllOwner();
                if (obj1.Count > 0)
                {
                    //    return lstUsers = new List<SelectListUser>
                    //    {
                    //        lstUsers.Add(obj1.SelectMany());
                    //};
                    foreach (var item in obj1)
                    {
                        OwnerMasterViewModel selectListOwner = new OwnerMasterViewModel
                        {
                            OwnerID=item.OwnerID,
                            OwnerName=item.OwnerName
                        };
                        lstOwners.Add(selectListOwner);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstOwners;
        }


        private async Task<List<ProjectSubcontractorConfigViewModel>> GetAllSubContractors()
        {
            List<ProjectSubcontractorConfigViewModel> lstSubContractors = new List<ProjectSubcontractorConfigViewModel>();
            try
            {
                var obj1 = await _subContractorHelper.GetAllSubContractorByOrg();
                if (obj1.Count > 0)
                {
                    //    return lstUsers = new List<SelectListUser>
                    //    {
                    //        lstUsers.Add(obj1.SelectMany());
                    //};
                    foreach (var item in obj1)
                    {
                        ProjectSubcontractorConfigViewModel selectListOwner = new ProjectSubcontractorConfigViewModel
                        {
                            SubContractorID=item.SubContractorID,
                            SubcontractorName=item.SubcontractorName
                        };
                        lstSubContractors.Add(selectListOwner);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstSubContractors;
        }

        private async Task<List<UserMasterViewModel>> GetAllUsers()
        {
            List<UserMasterViewModel> lstUsers = new List<UserMasterViewModel>();
            try
            {
                var obj1 = await _userMasterHelper.GetFullUserName();
                if (obj1.Count > 0)
                {
                    //    return lstUsers = new List<SelectListUser>
                    //    {
                    //        lstUsers.Add(obj1.SelectMany());
                    //};
                    foreach (var item in obj1)
                    {
                        UserMasterViewModel selectListUser = new UserMasterViewModel
                        {
                            UserID = item.UserID,
                            FullName = item.FullName
                        };
                        lstUsers.Add(selectListUser);
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstUsers;
        }
    }
}