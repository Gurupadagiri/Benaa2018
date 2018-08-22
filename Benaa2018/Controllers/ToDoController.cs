﻿using Benaa2018.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;
using Benaa2018.Helper.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Benaa2018.Helper.Model;
using System;
using System.Net.Mail;
using System.Net;

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
        private readonly IToDoAssignHelper _toDoAssignHelper;
        private readonly IToDoTagHelper _tagToDoHelper;
        private readonly IToDoCheckListHelper _toDoCheckListHelper;
        private readonly IToDoCheckListDetailsHelper _toDoCheckListDetailsHelper;

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
           IToDoAssignHelper toDoAssignHelper,
           IToDoCheckListHelper toDoCheckListHelper,
           IToDoCheckListDetailsHelper toDoCheckListDetailsHelper,
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
            _toDoAssignHelper = toDoAssignHelper;
            _tagToDoHelper = toDoTagHelper;
            _toDoCheckListHelper = toDoCheckListHelper;
            _toDoCheckListDetailsHelper = toDoCheckListDetailsHelper;


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

            #region populate ToDo
            var toDoDetails = GetAllToDoDetails();
            ViewBag.UserBaseToDoModel = JsonConvert.SerializeObject(toDoDetails.Result);
            // ViewBag.UserBaseToDoModel = toDoDetails.Result;
            #endregion

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
            var objToDoPrimary =await _todoMasterDetailsHelper.SaveToDoMasterDetails(toDoAllView.ToDoDetails);
            //var obj = await _userMasterHelper.SaveUserMaster(userMasterViewModel);
            if (objToDoPrimary.TodoDetailsID > 0)
            {
                if (toDoAllView.TagIds.Length > 0)
                {
                    foreach (var item in toDoAllView.TagIds)
                    {
                        ToDoTagViewModel tagview = new ToDoTagViewModel()
                        {
                            Tagid = (int)item,//objToDoPrimary.Id
                            TodoDetailsID = objToDoPrimary.TodoDetailsID
                        };

                        var objToTagSave = await _tagToDoHelper.SaveToDoTagDetails(tagview);
                    }
                }
                #region Assign user
                ToDoAssignViewModel todoAssignViewModel = new ToDoAssignViewModel
                {
                    TodoDetailsID = objToDoPrimary.TodoDetailsID,
                    ToDoAssignID = 1,
                    ToDoUserAssignTypeId = 1

                };
                //  var objToUserAssign =  _toDoAssignHelper.SaveToDoAssignDetails(todoAssignViewModel);
                var objToUserAssign = await  SaveToDoAssignDetails(todoAssignViewModel);
                #endregion

                #region Checklist
                ToDochecklistViewModel toDoCheckListViewModel = new ToDochecklistViewModel
                {
                    TodoDetailsID = objToDoPrimary.TodoDetailsID,
                    ToDoAssignIsCheckListItem = true,
                    ToDoAssignIFilesCheckListItem = true
                };

                //  var objToDoCheckList = _toDoCheckListHelper.SaveToDochecklistDetails(toDoCheckListViewModel);
                var objToDoCheckList = await SaveToDochecklistDetails(toDoCheckListViewModel);

                ToDochecklistDetailsViewModel toDoCheckListDetailsViewModel = new ToDochecklistDetailsViewModel
                {
                    ToDoCheckListId = objToDoCheckList.ToDoCheckListId ,
                    ToDoIsCheckList = true,
                    ToDoCheckListTitle = "test",
                    ToDoCheckListUserType = 1,
                    ToDoCheckListUserId = 1

                };

                //var objToDoDetailsList = _toDoCheckListDetailsHelper.SaveToDochecklistDetailsDescription(toDoCheckListDetailsViewModel);

                var objToDoDetailsList = await SaveToDochecklistDetailDetails(toDoCheckListDetailsViewModel);
                #endregion


            }
            //string[] selitems = toDoAllView.g
            return Json(result);
        }


        public async Task<IActionResult> SearchToDo(string keywords, string assignedto, int usersAssignedTo, int status, string priority, string tags = "")
        {
            string result = string.Empty;
            //List<ToDoAllViewModel> lstToDoSearchDetails = new List<ToDoAllViewModel>();


            var lstToDoSearchDetails = GetAllToDoDetailsSearch(keywords, status, priority, tags);
            //  ViewBag.ToDoSearchResult = JsonConvert.SerializeObject(lstToDoSearchDetails.Result);
            // ViewBag.UserBaseToDoModel = null;
            ViewBag.UserBaseToDoModel = null;
            ViewBag.UserBaseToDoModel= JsonConvert.SerializeObject(lstToDoSearchDetails.Result);
            // ViewBag.UserBaseToDoModelSearch = JsonConvert.SerializeObject(lstToDoSearchDetails.Result);
            result = "success";
           // return Json(result);
            return Json(JsonConvert.SerializeObject(lstToDoSearchDetails.Result));
        }


        public async Task<ActionResult> DeleteToDo(string ToDoDetailsId)
        {
            string result = string.Empty;

            string[] toDoDetailsListForComplete = ToDoDetailsId.Split(',');
            if (toDoDetailsListForComplete != null)
            {
                foreach (var item in toDoDetailsListForComplete)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        int todoDetailsIdperRow = Convert.ToInt32(item.Split('_')[1]);
                        var deleteToDo = await _todoMasterDetailsHelper.DeleteToDoMasterDetails(Convert.ToString(todoDetailsIdperRow));

                    }
                }
            }
            return Json(result);
        }
        public async Task<IActionResult> CopyToDo(string todoDetailIds)
        {
            string result = string.Empty;

            string[] toDoDetailsListForComplete = todoDetailIds.Split(',');
            if (toDoDetailsListForComplete != null)
            {
                foreach (var item in toDoDetailsListForComplete)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        int todoDetailsIdperRow = Convert.ToInt32(item.Split('_')[1]);
                        List < ToDoAllViewModel> lstToDoModel= new List<ToDoAllViewModel>();
                        lstToDoModel = await GetAllToDoDetails1(todoDetailsIdperRow);
                        
                        if(lstToDoModel.Count>0)
                        {
                            var saveToDoCopy = await SaveToDoCopy(lstToDoModel);
                        }
                    }
                }
            }
            return Json(result);
        }

        public async Task<IActionResult> SaveToDoIsComplete(string ToDoDetailsId = "1002")
        {
            string result = string.Empty;
            string[] toDoDetailsListForComplete = ToDoDetailsId.Split(',');
            if (toDoDetailsListForComplete != null)
            {
                foreach (var item in toDoDetailsListForComplete)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        int todoDetailsIdperRow = Convert.ToInt32(item.Split('_')[1]);

                        var tododetailsId = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsById(todoDetailsIdperRow);
                        if (tododetailsId != null)
                        {
                            var toDoSelectedItemDetails = tododetailsId[0];
                            ToDoMasterDetailsViewModel todoDetails = new ToDoMasterDetailsViewModel()
                            {
                                TodoDetailsID = toDoSelectedItemDetails.TodoDetailsID,
                                Project_ID = toDoSelectedItemDetails.Project_ID,
                                Project_Site = toDoSelectedItemDetails.Project_Site,
                                Title = toDoSelectedItemDetails.Title,
                                Org_ID = toDoSelectedItemDetails.Org_ID,
                                TypeNote = toDoSelectedItemDetails.TypeNote,
                                IsMarkedComplete = true,
                                Priority = toDoSelectedItemDetails.Priority,
                                Duedate = toDoSelectedItemDetails.Duedate,
                                DueDatetime = toDoSelectedItemDetails.DueDatetime,
                                LinkToUnit = toDoSelectedItemDetails.LinkToUnit,
                                LinkToDaysStatus = toDoSelectedItemDetails.LinkToDaysStatus,
                                TillingWorkId = toDoSelectedItemDetails.TillingWorkId,
                                TillingDate = toDoSelectedItemDetails.TillingDate
                            };

                            var objToTagSave =await _todoMasterDetailsHelper.UpdateToDoMasterDetails(todoDetails);
                        }
                    }

                }
            }



            return Json(result);
        }

        public async Task<IActionResult> AssignToDoUser(string userids, string toDoDetailsId)
        {
            string result = string.Empty;
            string[] toDoDetailsListForAssign = toDoDetailsId.Split(',');
            if (toDoDetailsListForAssign != null)
            {
                foreach (var itemAssign in toDoDetailsListForAssign)
                {
                    if (!string.IsNullOrEmpty(itemAssign))
                    {
                        int todoDetailsIdperRow = Convert.ToInt32(itemAssign.Split('_')[1]);


                        var lstUSerAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(Convert.ToInt32(todoDetailsIdperRow));

                        if (lstUSerAssign.Count > 0)
                        {
                            foreach (var item in lstUSerAssign)
                            {

                                if (item.UserID != Convert.ToInt32(userids))
                                {
                                    ToDoAssignViewModel todoAssignViewModel = new ToDoAssignViewModel
                                    {
                                        TodoDetailsID = Convert.ToInt32(item.TodoDetailsID),
                                        UserID = item.UserID,
                                        ToDoUserAssignTypeId = item.ToDoUserAssignTypeId

                                    };
                                    var objToUserAssign = await SaveToDoAssignDetails(todoAssignViewModel);

                                    int userid = item.UserID;
                                    var userDetails = _userMasterHelper.GetUserByUserId(userid);
                                    string userEmail = userDetails.Result.UserEmail;
                                    SendMail(userEmail);
                                }

                            }
                        }
                        else
                        {
                            //ToDoAssignViewModel todoAssignViewModel = new ToDoAssignViewModel
                            //{
                            //    TodoDetailsID = Convert.ToInt32(toDoDetailsId),
                            //    UserID =Convert.ToInt32( userids),
                            //    ToDoUserAssignTypeId = 1

                            //};

                            var saveAssign = await _toDoAssignHelper.SaveToDoAssignDetails1(Convert.ToInt32(userids), Convert.ToInt32(todoDetailsIdperRow));
                        }
                    }
                }
            }
            // var objToTagSave = _todoMasterDetailsHelper.DeleteToDoMasterDetails(ToDoDetailsId);

            //  var objToUserAssign =  _toDoAssignHelper.SaveToDoAssignDetails(todoAssignViewModel);

            return Json(result);
        }

        public async void SendMail(string email)
        {
            try
            {
                //MailMessage mail = new MailMessage();
                //mail.To.Add(email);

                //mail.From = new MailAddress("dream.sumit18@gmail.com");
                //mail.Subject = "Email using Gmail";
                //string Body = "test!!! Welcome to buildernet";
                //mail.Body = Body;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential
                //("dream.sumit18@gmail.com", "swapnasumit");

                ////Or your Smtp Email ID and Password
                //smtp.EnableSsl = true;
                //smtp.Send(mail);

                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com", // set your SMTP server name here
                    Port = 587, // Port 
                    EnableSsl = true,
                    Credentials = new NetworkCredential("dream.sumit18@gmail.com", "swapnasumit")
                };

                using (var message = new MailMessage("dream.sumit18@gmail.com", "sumitganguly1989@gmail.com")
                {
                    Subject = "Subject",
                    Body = "Body"
                })
                {
                    await smtpClient.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {

            }
        }




        public async Task<List<UserOwnerDifferentTypeViewModel>> GetAllDifferentUsers()
        {
            List<UserOwnerDifferentTypeViewModel> lstOwners1 = new List<UserOwnerDifferentTypeViewModel>();
            try
            {
                int index = 0;



                //List<OwnerMasterViewModel> lstOwners = new List<OwnerMasterViewModel>();
                var lstOwners = GetAllOwners();
                var lstInternalUsers = GetAllUsers();
                var lstSubContractors = GetAllSubContractors();
                if (lstOwners.Result.Count > 0)
                {
                    foreach (var item in lstOwners.Result)
                    {
                        UserOwnerDifferentTypeViewModel item1 = new UserOwnerDifferentTypeViewModel()
                        {
                            UserOwnerDifferentTypeId = index + 1,
                            UserOriginalId = item.OwnerID,
                            UserOriginaTypeId = 1,
                            UserOriginaTypeText = "Owners",
                            UserOwnerDifferentTypeValue = item.OwnerName
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
                            UserOwnerDifferentTypeValue = item.FullName
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
                            OwnerID = item.OwnerID,
                            OwnerName = item.OwnerName
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
                            SubContractorID = item.SubContractorID,
                            SubcontractorName = item.SubcontractorName
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


        private async Task<List<ToDoAllViewModel>> GetAllToDoDetails()
        {
            List<ToDoAllViewModel> lstToDos = new List<ToDoAllViewModel>();
            try
            {
                var obj1 = await _todoMasterDetailsHelper.GetAllToDoMasterDetails();


                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        ToDoAllViewModel toDoView = new ToDoAllViewModel();
                        ToDoMasterDetailsViewModel todoMasterDetails = new ToDoMasterDetailsViewModel()
                        {
                            TodoDetailsID = item.TodoDetailsID,
                            Project_ID = item.Project_ID,
                            Project_Site = item.Project_Site,
                            Title = item.Title,
                            Org_ID = item.Org_ID,
                            TypeNote = item.TypeNote,
                            IsMarkedComplete = item.IsMarkedComplete,
                            Priority = item.Priority,
                            Duedate = item.Duedate,
                            DueDatetime = item.DueDatetime,
                            LinkToUnit = item.LinkToUnit,
                            LinkToDaysStatus = item.LinkToDaysStatus,
                            TillingWorkId = item.TillingWorkId,
                            TillingDate = item.TillingDate,
                            TillingTime = item.TillingTime,
                            ReminderId = item.ReminderId,
                            CreatedBy = "Test User"

                        };

                        var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);
                        string AllTagNames = string.Empty;
                        List<TagMasterViewModel> lstTagMasters = new List<TagMasterViewModel>();
                        if (objTags.Count > 0)
                        {
                            TagMasterViewModel TagsDetails = new TagMasterViewModel();

                            foreach (var tag in objTags)
                            {

                                int tagids = tag.Tagid;
                                List<TagMasterViewModel> lstTagMaster = new List<TagMasterViewModel>();
                                lstTagMaster = await _tagMasterHelper.GetAllTagMasterDetails(tagids);
                                if (lstTagMaster.Count > 0)
                                {

                                    string tagName = lstTagMaster[0].TagName.ToString();
                                    TagMasterViewModel tagMaster = new TagMasterViewModel
                                    {
                                        TagId = tagids,
                                        TagName = tagName
                                    };
                                    lstTagMasters.Add(tagMaster);
                                    AllTagNames = AllTagNames + tagName + ", ";
                                }

                            }

                            toDoView.TotalTagCount = objTags.Count;


                        }

                        #region GetAssign
                        string UserDetails = string.Empty;
                        int UserDetailsCount = 0;
                        var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(item.TodoDetailsID);
                        string AllAssignNames = string.Empty;
                        List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                        if (objAssign.Count > 0)
                        {
                            ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                            foreach (var assign in objAssign)
                            {
                                lstAssignModels.Add(new ToDoAssignViewModel()
                                {
                                    ToDoAssignID = assign.ToDoAssignID,
                                    UserID = assign.UserID,
                                    TodoDetailsID = assign.TodoDetailsID,
                                    ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                                });
                            }

                            if (lstAssignModels.Count > 0)
                            {
                                foreach (var itemUser in lstAssignModels)
                                {
                                    var Users = _userMasterHelper.GetUserByUserId(itemUser.UserID);
                                    UserDetails = Users.Result.UserName + " ," + UserDetails;
                                }
                                UserDetailsCount = lstAssignModels.Count - 1;
                            }

                        }
                        #endregion
                        toDoView.ToDoDetails = todoMasterDetails;
                        toDoView.TotalNumberOfMessages = 0;
                        toDoView.lstTags = lstTagMasters;
                        toDoView.TagNames = AllTagNames;
                        toDoView.UserNames = UserDetails;
                        toDoView.TotalUserNameCount = UserDetailsCount;
                        lstToDos.Add(toDoView);

                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstToDos;
        }

        private async Task<List<ToDoAllViewModel>> GetAllToDoDetailsSearch(string title = "", int status = 0, string priority = "", string tags = "")
        {
            List<ToDoAllViewModel> lstToDos = new List<ToDoAllViewModel>();
            try
            {
                List<ToDoMasterDetailsViewModel> lstToDoSearchDetails = new List<ToDoMasterDetailsViewModel>();


                var obj1 = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsByTitle(title, status, priority);


                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        ToDoAllViewModel toDoView = new ToDoAllViewModel();
                        ToDoMasterDetailsViewModel todoMasterDetails = new ToDoMasterDetailsViewModel()
                        {
                            TodoDetailsID = item.TodoDetailsID,
                            Project_ID = item.Project_ID,
                            Project_Site = item.Project_Site,
                            Title = item.Title,
                            Org_ID = item.Org_ID,
                            TypeNote = item.TypeNote,
                            IsMarkedComplete = item.IsMarkedComplete,
                            Priority = item.Priority,
                            Duedate = item.Duedate,
                            DueDatetime = item.DueDatetime,
                            LinkToUnit = item.LinkToUnit,
                            LinkToDaysStatus = item.LinkToDaysStatus,
                            TillingWorkId = item.TillingWorkId,
                            TillingDate = item.TillingDate,
                            TillingTime = item.TillingTime,
                            ReminderId = item.ReminderId,
                            CreatedBy = "Test User"

                        };


                        var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);
                        string AllTagNames = string.Empty;
                        List<TagMasterViewModel> lstTagMasters = new List<TagMasterViewModel>();
                        if (objTags.Count > 0)
                        {
                            TagMasterViewModel TagsDetails = new TagMasterViewModel();

                            foreach (var tag in objTags)
                            {

                                int tagids = tag.Tagid;
                                List<TagMasterViewModel> lstTagMaster = new List<TagMasterViewModel>();
                                lstTagMaster = await _tagMasterHelper.GetAllTagMasterDetails(tagids);
                                if (lstTagMaster.Count > 0)
                                {

                                    string tagName = lstTagMaster[0].TagName.ToString();
                                    TagMasterViewModel tagMaster = new TagMasterViewModel
                                    {
                                        TagId = tagids,
                                        TagName = tagName
                                    };
                                    lstTagMasters.Add(tagMaster);
                                    AllTagNames = AllTagNames + tagName + ", ";
                                }

                            }


                            toDoView.TotalTagCount = objTags.Count;


                        }

                        #region GetAssign
                        string UserDetails = string.Empty;
                        int UserDetailsCount = 0;
                        var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(item.TodoDetailsID);
                        string AllAssignNames = string.Empty;
                        List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                        if (objAssign.Count > 0)
                        {
                            ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                            foreach (var assign in objAssign)
                            {
                                lstAssignModels.Add(new ToDoAssignViewModel()
                                {
                                    ToDoAssignID = assign.ToDoAssignID,
                                    UserID = assign.UserID,
                                    TodoDetailsID = assign.TodoDetailsID,
                                    ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                                });
                            }


                            if (lstAssignModels.Count > 0)
                            {
                                foreach (var itemUser in lstAssignModels)
                                {
                                    var Users = _userMasterHelper.GetUserByUserId(itemUser.UserID);
                                    UserDetails = Users.Result.UserName + " ," + UserDetails;
                                }
                                UserDetailsCount = lstAssignModels.Count - 1;
                            }

                        }
                        #endregion
                        //var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);

                        //if (!string.IsNullOrEmpty(tags))
                        //{
                        //    string[] tagDetails = tags.Split(',');
                        //}


                        toDoView.ToDoDetails = todoMasterDetails;
                        toDoView.TotalNumberOfMessages = 0;
                        toDoView.lstTags = lstTagMasters;
                        toDoView.TagNames = AllTagNames;
                        toDoView.UserNames = UserDetails;
                        toDoView.TotalUserNameCount = UserDetailsCount;
                        lstToDos.Add(toDoView);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lstToDos;
        }

        public async Task<ToDoAssignViewModel> SaveToDoAssignDetails(ToDoAssignViewModel todoAssignViewModel)
        {
            ToDoAssignViewModel toDoAssignView = new ToDoAssignViewModel();
            try
            {
                var item = await _toDoAssignHelper.SaveToDoAssignDetails(todoAssignViewModel);
                if (item.ToDoAssignID > 0)
                {
                    toDoAssignView.ToDoAssignID = item.ToDoAssignID;
                }
            }
            catch (Exception ex)
            {
                toDoAssignView = null;
            }
            return toDoAssignView;
        }

        private async Task<ToDochecklistViewModel> SaveToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel)
        {
            ToDochecklistViewModel toDoCheckListView = new ToDochecklistViewModel();
            try
            {
                var item = await _toDoCheckListHelper.SaveToDochecklistDetails(toDochecklistViewModel);
                if (item.ToDoCheckListId > 0)
                {
                    toDoCheckListView.ToDoCheckListId = item.ToDoCheckListId;
                }
            }
            catch (Exception ex)
            {
                toDoCheckListView = null;
            }
            return toDoCheckListView;
        }


        private async Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailDetails(ToDochecklistDetailsViewModel toDochecklistDetailsViewModel)
        {
            ToDochecklistDetailsViewModel toDochecklistDetailsl = new ToDochecklistDetailsViewModel();
            try
            {
                var item = await _toDoCheckListDetailsHelper.SaveToDochecklistDetailsDescription(toDochecklistDetailsViewModel);
                if (item.ToDochecklistDetailsViewModelId > 0)
                {
                    toDochecklistDetailsl.ToDochecklistDetailsViewModelId = item.ToDochecklistDetailsViewModelId;
                }
            }
            catch (Exception ex)
            {
                toDochecklistDetailsl = null;
            }
            return toDochecklistDetailsl;
        }


        private async Task<List<ToDoAllViewModel>> GetAllToDoDetails1(int todoDetailsId=0)
        {
            List<ToDoAllViewModel> lstToDos = new List<ToDoAllViewModel>();
            try
            {
                // var obj1 = await _todoMasterDetailsHelper.GetAllToDoMasterDetails();
                var obj1 = await _todoMasterDetailsHelper.GetAllToDoMasterDetailsById(todoDetailsId);

                if (obj1.Count > 0)
                {
                    foreach (var item in obj1)
                    {
                        List<ToDoTagViewModel> lstTagMasters = new List<ToDoTagViewModel>();

                        ToDoAllViewModel toDoView = new ToDoAllViewModel();
                        ToDoMasterDetailsViewModel todoMasterDetails = new ToDoMasterDetailsViewModel()
                        {
                           // TodoDetailsID = item.TodoDetailsID,
                            Project_ID = item.Project_ID,
                            Project_Site = item.Project_Site,
                            Title = item.Title,
                            Org_ID = item.Org_ID,
                            TypeNote = item.TypeNote,
                            IsMarkedComplete = item.IsMarkedComplete,
                            Priority = item.Priority,
                            Duedate = item.Duedate,
                            DueDatetime = item.DueDatetime,
                            LinkToUnit = item.LinkToUnit,
                            LinkToDaysStatus = item.LinkToDaysStatus,
                            TillingWorkId = item.TillingWorkId,
                            TillingDate = item.TillingDate,
                            TillingTime = item.TillingTime,
                            ReminderId = item.ReminderId,
                            CreatedBy = "Test User"

                        };

                        #region GetTags
                        //var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);
                        //string AllTagNames = string.Empty;
                        //List<TagMasterViewModel> lstTagMasters = new List<TagMasterViewModel>();
                        //if (objTags.Count > 0)
                        //{
                        //    TagMasterViewModel TagsDetails = new TagMasterViewModel();

                        //    foreach (var tag in objTags)
                        //    {

                        //        int tagids = tag.Tagid;
                        //        List<TagMasterViewModel> lstTagMaster = new List<TagMasterViewModel>();
                        //        lstTagMaster = await _tagMasterHelper.GetAllTagMasterDetails(tagids);
                        //        if (lstTagMaster.Count > 0)
                        //        {

                        //            string tagName = lstTagMaster[0].TagName.ToString();
                        //            TagMasterViewModel tagMaster = new TagMasterViewModel
                        //            {
                        //                TagId = tagids,
                        //                TagName = tagName
                        //            };
                        //            lstTagMasters.Add(tagMaster);
                        //            AllTagNames = AllTagNames + tagName + ", ";
                        //        }

                        //    }

                        //    toDoView.TotalTagCount = objTags.Count;




                        //}

                        var objTags = await _tagToDoHelper.GetAllTags(item.TodoDetailsID);
                        string AllTagNames = string.Empty;
                        //List<ToDoTagViewModel> lstTagMasters = new List<ToDoTagViewModel>();
                        if (objTags.Count > 0)
                        {
                            ToDoTagViewModel TagsDetails = new ToDoTagViewModel();

                            foreach (var tag in objTags)
                            {
                                lstTagMasters.Add(new ToDoTagViewModel()
                                {
                                    TodoDetailsID = tag.TodoDetailsID,
                                    Tagid = tag.Tagid
                                });



                            }

                            toDoView.TotalTagCount = objTags.Count;
                            toDoView.lstToDoDetails = lstTagMasters;



                        }
                        #endregion

                        #region GetAssign

                        var objAssign = await _toDoAssignHelper.GetToDoAssignByToDoDetailsId(item.TodoDetailsID);
                        string AllAssignNames = string.Empty;
                        List<ToDoAssignViewModel> lstAssignModels = new List<ToDoAssignViewModel>();
                        if (objAssign.Count > 0)
                        {
                            ToDoAssignViewModel AssignDetails = new ToDoAssignViewModel();
                            foreach (var assign in objAssign)
                            {
                                lstAssignModels.Add(new ToDoAssignViewModel()
                                {
                                    ToDoAssignID = assign.ToDoAssignID,
                                    UserID = assign.UserID,
                                    TodoDetailsID = assign.TodoDetailsID,
                                    ToDoUserAssignTypeId = assign.ToDoUserAssignTypeId
                                });
                            }
                        }
                        #endregion

                        #region GetCheckList
                        var objCheckList = await _toDoCheckListHelper.GetAllCheclistDetails(item.TodoDetailsID);
                        string AllCheckLists = string.Empty;
                        List<ToDochecklistViewModel> lstChecklistModels = new List<ToDochecklistViewModel>();
                        List<ToDochecklistDetailsViewModel> lstCheckListDetails = new List<ToDochecklistDetailsViewModel>();
                        if (objCheckList.Count > 0)
                        {
                            ToDochecklistViewModel toDoCheckLsit = new ToDochecklistViewModel();

                            foreach (var checkList in objCheckList)
                            {

                                var objCheckListDetails = await _toDoCheckListDetailsHelper.GetAllCheclistDetailsDescription(checkList.ToDoCheckListId);
                                if (objCheckListDetails.Count > 0)
                                {
                                    ToDochecklistDetailsViewModel toCheckListDetails = new ToDochecklistDetailsViewModel();
                                    foreach (var checkListDetails in objCheckListDetails)
                                    {
                                        lstCheckListDetails.Add(new ToDochecklistDetailsViewModel()
                                        {
                                            ToDochecklistDetailsViewModelId = checkListDetails.ToDochecklistDetailsViewModelId,
                                            ToDoCheckListId = checkListDetails.ToDoCheckListId,
                                            ToDoIsCheckList = checkListDetails.ToDoIsCheckList,
                                            ToDoCheckListTitle = checkListDetails.ToDoCheckListTitle,
                                            ToDoCheckListUserType = checkListDetails.ToDoCheckListUserType,
                                            ToDoCheckListUserId = checkListDetails.ToDoCheckListUserId
                                        });
                                    }
                                }

                                lstChecklistModels.Add(new ToDochecklistViewModel()
                                {
                                    ToDoCheckListId = checkList.ToDoCheckListId,
                                    TodoDetailsID = checkList.TodoDetailsID,
                                    ToDoAssignIsCheckListItem = checkList.ToDoAssignIsCheckListItem,
                                    ToDoAssignIFilesCheckListItem = checkList.ToDoAssignIFilesCheckListItem
                                });




                            }
                        }
                        #endregion

                        toDoView.ToDoDetails = todoMasterDetails;
                        toDoView.TotalNumberOfMessages = 1;
                        toDoView.lstToDoDetails = lstTagMasters;
                        toDoView.TagNames = AllTagNames;
                        toDoView.lstAssigns = lstAssignModels;
                        toDoView.lstCheckLists = lstChecklistModels;
                        toDoView.lstCheckListDetails = lstCheckListDetails;
                        lstToDos.Add(toDoView);

                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return lstToDos;
        }


        private async Task<int> SaveToDoCopy(List<ToDoAllViewModel> lstTodoView)
        {
            int result = 0;
            try
            {
                if (lstTodoView.Count > 0)
                {
                    foreach (var toDoItem in lstTodoView)
                    {
                        if (toDoItem.ToDoDetails != null)
                        {
                            var insertToDoDetails = await _todoMasterDetailsHelper.SaveToDoMasterDetails(toDoItem.ToDoDetails);

                            if (insertToDoDetails.TodoDetailsID > 0)
                            {
                                #region SaveTags
                                if (toDoItem.lstToDoDetails != null)
                                {
                                    foreach (var itemTag in toDoItem.lstToDoDetails)
                                    {
                                        ToDoTagViewModel todoTag = new ToDoTagViewModel()
                                        {
                                            TodoDetailsID = insertToDoDetails.TodoDetailsID,
                                            ToDoTagid = itemTag.Tagid
                                        };
                                        var objToTagSave = await _tagToDoHelper.SaveToDoTagDetails(todoTag);


                                    }
                                }
                                #endregion

                                #region SaveAssign
                                if (toDoItem.lstAssigns != null)
                                {
                                    foreach (var itemAssign in toDoItem.lstAssigns)
                                    {
                                        ToDoAssignViewModel toDoAssignView = new ToDoAssignViewModel()
                                        {
                                            UserID = itemAssign.UserID,
                                            TodoDetailsID = insertToDoDetails.TodoDetailsID,
                                            ToDoUserAssignTypeId = itemAssign.ToDoUserAssignTypeId
                                        };
                                        var assignItem = await SaveToDoAssignDetails(toDoAssignView);
                                    }
                                }

                                #endregion

                                #region SaveCheckList
                                if (toDoItem.lstCheckLists != null)
                                {
                                    foreach (var itemAssign in toDoItem.lstCheckLists)
                                    {
                                        ToDochecklistViewModel toDoCheckLsit = new ToDochecklistViewModel()
                                        {
                                            TodoDetailsID = insertToDoDetails.TodoDetailsID,
                                            ToDoAssignIsCheckListItem = itemAssign.ToDoAssignIsCheckListItem,
                                            ToDoAssignIFilesCheckListItem = itemAssign.ToDoAssignIFilesCheckListItem
                                        };

                                        var assignCheckList = await  SaveToDochecklistDetails(toDoCheckLsit);
                                    }
                                }


                                #endregion


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

    }
}