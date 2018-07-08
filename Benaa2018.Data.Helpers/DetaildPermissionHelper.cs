using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Benaa2018.Helper
{
    public class DetaildPermissionHelper : IDetaildPermissionHelper
    {
        private readonly IDetaildPermissionRepository _detaildPermissionRepository;


        public DetaildPermissionHelper(IDetaildPermissionRepository detaildPermissionRepository)
        {
            _detaildPermissionRepository = detaildPermissionRepository;
        }

        public Task<DetaildPermissionViewModel> GetUserDetailsInfoByInfo(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<DetaildPermissionViewModel> SaveUserDetailsAsync(DetaildPermissionViewModel detaildPermissionViewModel)
        {

            DetaildPermission detailedPermission = new DetaildPermission
            {
                //Detaild_Permission_Id = detaildPermissionViewModel.DetaildPermissionId,
                User_ID = detaildPermissionViewModel.UserID,
                Is_View_All = detaildPermissionViewModel.IsViewAll,
                Is_Add_All = detaildPermissionViewModel.IsAddAll,
                Is_Edit_all = detaildPermissionViewModel.IsEditall,
                Is_Delete_All = detaildPermissionViewModel.IsDeleteAll,
                Is_Job_Info_View = detaildPermissionViewModel.IsJobInfoView,
                Is_Job_Info_Add = detaildPermissionViewModel.IsJobInfoAdd,
                Is_Job_Info_Edit = detaildPermissionViewModel.IsJobInfoEdit,
                Is_Job_Info_delete = detaildPermissionViewModel.IsJobInfodelete,
                Is_View_Owner_Site = detaildPermissionViewModel.IsViewOwnerSite,
                Is_Price_Viewing = detaildPermissionViewModel.IsPriceViewing,
                Is_Owner_Payments_View = detaildPermissionViewModel.IsOwnerPaymentsView,
                Is_Owner_Payments_Add = detaildPermissionViewModel.IsOwnerPaymentsAdd,
                Is_Owner_Payments_Edit = detaildPermissionViewModel.IsOwnerPaymentsEdit,
                Is_Owner_Payments_Delete = detaildPermissionViewModel.IsOwnerPaymentsDelete,
                Is_Leads_View = detaildPermissionViewModel.IsLeadsView,
                Is_Leads_Add = detaildPermissionViewModel.IsLeadsAdd,
                Is_Leads_Edit = detaildPermissionViewModel.IsLeadsEdit,
                Is_Leads_Delete = detaildPermissionViewModel.IsLeadsDelete,
                Is_Leads_Assign_Salesperson = detaildPermissionViewModel.IsLeadsAssignSalesperson,
                Is_Leads_View_Other_Salesperson = detaildPermissionViewModel.IsLeadsViewOtherSalesperson,
                Is_Leads_Convert_To_Jobsite = detaildPermissionViewModel.IsLeadsConvertToJobsite,
                Is_Leads_Export_To_Excel = detaildPermissionViewModel.IsLeadsExportToExcel,
                Is_Customer_Contacts_View_ReadOnly = detaildPermissionViewModel.IsCustomerContactsViewReadOnly,
                Is_Customer_Contacts_View = detaildPermissionViewModel.IsCustomerContactsView,
                Is_Customer_Contacts_Add_ReadOnly = detaildPermissionViewModel.IsCustomerContactsAddReadOnly,
                Is_Customer_Contacts_Add = detaildPermissionViewModel.IsCustomerContactsAdd,
                Is_Customer_Contacts_Edit = detaildPermissionViewModel.IsCustomerContactsEdit,
                Is_Customer_Contacts_Delete = detaildPermissionViewModel.IsCustomerContactsDelete,

                Is_View_All_Customer_Contacts_Readonly = detaildPermissionViewModel.IsViewAllCustomerContactsReadonly,
                Is_View_All_Customer_Contacts = detaildPermissionViewModel.IsViewAllCustomerContacts,
                Is_Customer_Contacts_Export_To_Excel = detaildPermissionViewModel.IsCustomerContactsExportToExcel,

                Is_To_Do_View = detaildPermissionViewModel.IsToDoView,
                Is_To_Do_Add = detaildPermissionViewModel.IsToDoAdd,
                Is_To_Do_Edit = detaildPermissionViewModel.IsToDoEdit,
                Is_To_Do_Delete = detaildPermissionViewModel.IsToDoDelete,
                Is_To_Do_Assign_Users = detaildPermissionViewModel.IsToDoAssignUsers,
                Is_To_Do_Global = detaildPermissionViewModel.IsToDoGlobal,

                Is_Logs_View = detaildPermissionViewModel.IsLogsView,
                Is_Logs_Add = detaildPermissionViewModel.IsLogsAdd,
                Is_Logs_Edit = detaildPermissionViewModel.IsLogsEdit,
                Is_Logs_Delete = detaildPermissionViewModel.IsLogsDelete,


                Is_Bids_View = detaildPermissionViewModel.IsBidsView,
                Is_Bids_Add = detaildPermissionViewModel.IsBidsAdd,
                Is_Bids_Edit = detaildPermissionViewModel.IsBidsEdit,
                Is_Bids_Delete = detaildPermissionViewModel.IsBidsDelete,



                Is_Calendar_View = detaildPermissionViewModel.IsCalendarView,
                Is_Calendar_Add = detaildPermissionViewModel.IsCalendarAdd,
                Is_Calendar_Edit = detaildPermissionViewModel.IsCalendarEdit,
                Is_Calendar_Delete = detaildPermissionViewModel.IsCalendarDelete,
                Is_Set_Baseline = detaildPermissionViewModel.IsSetBaseline,


                Is_Documents_View = detaildPermissionViewModel.IsDocumentsView,
                Is_Documents_Add = detaildPermissionViewModel.IsDocumentsAdd,
                Is_Documents_Edit = detaildPermissionViewModel.IsDocumentsEdit,
                Is_Documents_Delete = detaildPermissionViewModel.IsDocumentsDelete,

                Is_Documents_Access_SubOwner = detaildPermissionViewModel.IsDocumentsAccessSubOwner,
                Is_Documents_Signature = detaildPermissionViewModel.IsDocumentsSignature,

                Is_Videos_View = detaildPermissionViewModel.IsVideosView,
                Is_Videos_Add = detaildPermissionViewModel.IsVideosAdd,
                Is_Videos_Edit = detaildPermissionViewModel.IsVideosEdit,
                Is_Videos_Delete = detaildPermissionViewModel.IsVideosDelete,

                Is_Photos_View = detaildPermissionViewModel.IsPhotosView,
                Is_Photos_Add = detaildPermissionViewModel.IsPhotosAdd,
                Is_Photos_Edit = detaildPermissionViewModel.IsPhotosEdit,
                Is_Photos_Delete = detaildPermissionViewModel.IsPhotosDelete,

                Is_Messages_View = detaildPermissionViewModel.IsMessagesView,
                Is_Messages_Add = detaildPermissionViewModel.IsMessagesAdd,
                Is_Messages_Add_Readonly = detaildPermissionViewModel.IsMessagesAddReadonly,
                Is_Messages_Edit = detaildPermissionViewModel.IsMessagesEdit,
                Is_Messages_Edit_Readonly = detaildPermissionViewModel.IsMessagesEditReadonly,
                Is_Messages_Delete = detaildPermissionViewModel.IsMessagesDelete,
                Is_Message_Global = detaildPermissionViewModel.IsMessageGlobal,

                Is_RFI_View = detaildPermissionViewModel.IsRFIView,
                Is_RFI_Add = detaildPermissionViewModel.IsRFIAdd,
                Is_RFI_Edit = detaildPermissionViewModel.IsRFIEdit,
                Is_RFI__Delete = detaildPermissionViewModel.IsRFIDelete,


                Is_Change_Orders_View = detaildPermissionViewModel.IsChangeOrdersView,
                Is_Change_Orders_Add = detaildPermissionViewModel.IsChangeOrdersAdd,
                Is_Change_Orders_Edit = detaildPermissionViewModel.IsChangeOrdersEdit,
                Is_Change_Orders_Delete = detaildPermissionViewModel.IsChangeOrdersDelete,
                Is_Change_Orders_Cost_Viewing = detaildPermissionViewModel.IsChangeOrdersCostViewing,

                Is_Selections_View = detaildPermissionViewModel.IsSelectionsView,
                Is_Selections_Add = detaildPermissionViewModel.IsSelectionsAdd,
                Is_Selections_Edit = detaildPermissionViewModel.IsSelectionsEdit,
                Is_Selections_Delete = detaildPermissionViewModel.IsSelectionsDelete,
                Is_Selections_Cost_Viewing = detaildPermissionViewModel.IsSelectionsCostViewing,

                Is_Bill_View = detaildPermissionViewModel.IsBillView,
                Is_Bill_Add = detaildPermissionViewModel.IsBillAdd,
                Is_Bill_Edit = detaildPermissionViewModel.IsBillEdit,
                Is_Bill_Delete = detaildPermissionViewModel.IsBillDelete,
                Is_Bill_Accounting = detaildPermissionViewModel.IsBillAccounting,
                Is_Bill_No_Price_Limit = detaildPermissionViewModel.IsBillNoPriceLimit,
                Is_Bill_Cost_Viewing = detaildPermissionViewModel.IsBillCostViewing,

                Is_Warranty_View = detaildPermissionViewModel.IsWarrantyView,
                Is_Warranty_Add = detaildPermissionViewModel.IsWarrantyAdd,
                Is_Warranty_Edit = detaildPermissionViewModel.IsWarrantyEdit,
                Is_Warranty_Delete = detaildPermissionViewModel.IsWarrantyDelete,

                Is_Time_Clock_View = detaildPermissionViewModel.IsTimeClockView,
                Is_Time_Clock_Add = detaildPermissionViewModel.IsTimeClockAdd,
                Is_Time_Clock_Edit = detaildPermissionViewModel.IsTimeClockEdit,
                Is_Time_Clock_Delete = detaildPermissionViewModel.IsTimeClockDelete,
                Is_Time_Clock_View_Other_User = detaildPermissionViewModel.IsTimeClockViewOtherUser,
                Is_Time_Clock_Adjust_Other_User = detaildPermissionViewModel.IsTimeClockAdjustOtherUser,
                Is_Time_Clock_Cost_Viewing = detaildPermissionViewModel.IsTimeClockCostViewing,
                Is_Time_Clock_Review_And_Approve = detaildPermissionViewModel.IsTimeClockReviewAndApprove,

                Is_Estimate_GI_View = detaildPermissionViewModel.IsEstimateGIView,
                Is_Estimate_GI_Add = detaildPermissionViewModel.IsEstimateGIAdd,
                Is_Estimate_GI_Edit = detaildPermissionViewModel.IsEstimateGIEdit,
                Is_Estimate_GI_Delete = detaildPermissionViewModel.IsEstimateGIDelete,
                Is_Estimate_GI_Price_Viewing = detaildPermissionViewModel.IsEstimateGIPriceViewing,

                Is_Survey_View = detaildPermissionViewModel.IsSurveyView,
                Is_Survey_Add = detaildPermissionViewModel.IsSurveyAdd,
                Is_Survey_Edit = detaildPermissionViewModel.IsSurveyEdit,
                Is_Survey_Delete = detaildPermissionViewModel.IsSurveyDelete,
                Is_Survey_Add_Review_Website = detaildPermissionViewModel.IsSurveyAddReviewWebsite,

                Is_Subs_View = detaildPermissionViewModel.IsSubsView,
                Is_Subs_Add = detaildPermissionViewModel.IsSubsAdd,
                Is_Subs_Edit = detaildPermissionViewModel.IsSubsEdit,
                Is_Subs_Delete = detaildPermissionViewModel.IsSubsDelete,

                Is_Admin_View = detaildPermissionViewModel.IsAdminView,
                Is_Admin_View_Readonly = detaildPermissionViewModel.IsAdminViewReadonly,
                Is_Admin_Add = detaildPermissionViewModel.IsAdminAdd,
                Is_Admin_Add_Readonly = detaildPermissionViewModel.IsAdminAddReadonly,
                Is_Admin_Edit = detaildPermissionViewModel.IsAdminEdit,
                Is_Admin_Edit_Readonly = detaildPermissionViewModel.IsAdminEditReadonly,
                Is_Admin_Delete = detaildPermissionViewModel.IsAdminDelete,
                Is_Admin_Delete_Readonly = detaildPermissionViewModel.IsAdminDeleteReadonly,

                Import_Notification_Id = detaildPermissionViewModel.ImportNotificationId,
                Is_Email_All = detaildPermissionViewModel.IsEmailAll,
                Is_Text_All = detaildPermissionViewModel.IsTextAll,
                Is_Push_On = detaildPermissionViewModel.IsPushOn,
                Is_All_Users = detaildPermissionViewModel.IsAllUsers,

                Is_Owner_Activated_Email = detaildPermissionViewModel.IsOwnerActivatedEmail,

                Is_Owner_Payment_Updated_Email = detaildPermissionViewModel.IsOwnerPaymentUpdatedEmail,
                Is_Owner_Payment_Updated_Text = detaildPermissionViewModel.IsOwnerPaymentUpdatedText,
                Is_Owner_Payment_Updated_Push = detaildPermissionViewModel.IsOwnerPaymentUpdatedPush,

                Is_Owner_Payment_Reminder_Email = detaildPermissionViewModel.IsOwnerPaymentReminderEmail,
                Is_Owner_Payment_Reminder_Text = detaildPermissionViewModel.IsOwnerPaymentReminderText,
                Is_Owner_Payment_Reminder_Push = detaildPermissionViewModel.IsOwnerPaymentReminderPush,

                Is_Owner_Payment_Past_Due_Email = detaildPermissionViewModel.IsOwnerPaymentPastDueEmail,
                Is_Owner_Payment_Past_Due_Text = detaildPermissionViewModel.IsOwnerPaymentPastDueText,
                Is_Owner_Payment_Past_Due_Push = detaildPermissionViewModel.IsOwnerPaymentPastDuePush,

                Is_Owner_Payment_Discussion_Email = detaildPermissionViewModel.IsOwnerPaymentDiscussionEmail,
                Is_Owner_Payment_Discussion_Text = detaildPermissionViewModel.IsOwnerPaymentDiscussionText,
                Is_Owner_Payment_Discussion_Push = detaildPermissionViewModel.IsOwnerPaymentDiscussionPush,

                Is_Owner_Payment_Added_Email = detaildPermissionViewModel.IsOwnerPaymentAddedEmail,
                Is_Owner_Payment_Added_Text = detaildPermissionViewModel.IsOwnerPaymentAddedText,
                Is_Owner_Payment_Added_Push = detaildPermissionViewModel.IsOwnerPaymentAddedPush,

                Is_Other_Employee_Contact_Email = detaildPermissionViewModel.IsOtherEmployeeContactEmail,
                Is_Other_Employee_Contact_Text = detaildPermissionViewModel.IsOtherEmployeeContactText,

                Is_New_Lead_Email = detaildPermissionViewModel.IsNewLeadEmail,
                Is_New_Lead_Text = detaildPermissionViewModel.IsNewLeadText,
                Is_New_Lead_Push = detaildPermissionViewModel.IsNewLeadPush,

                Is_Lead_Notify_Email = detaildPermissionViewModel.IsLeadNotifyEmail,
                Is_Lead_Notify_Text = detaildPermissionViewModel.IsLeadNotifyText,
                Is_Lead_Notify_Push = detaildPermissionViewModel.IsLeadNotifyPush,
                Is_Activity_Remainder_Email = detaildPermissionViewModel.IsActivityRemainderEmail,
                Is_Activity_Remainder_Text = detaildPermissionViewModel.IsActivityRemainderText,
                Is_Activity_Remainder_Push = detaildPermissionViewModel.IsActivityRemainderPush,
                Is_Activity_Remainder_All_Users = detaildPermissionViewModel.IsActivityRemainderAllUsers,

                Is_Email_Quotes_Alert_Email = detaildPermissionViewModel.IsEmailQuotesAlertEmail,
                Is_Email_Quotes_Alert_Text = detaildPermissionViewModel.IsEmailQuotesAlertText,
                Is_Assigned_To_Lead_Activity_Email = detaildPermissionViewModel.IsAssignedToLeadActivityEmail,
                Is_Assigned_To_Lead_Activity_Text = detaildPermissionViewModel.IsAssignedToLeadActivityText,
                Is_Assigned_To_Lead_Activity_Push = detaildPermissionViewModel.IsAssignedToLeadActivityPush,

                Is_Lead_Proposal_Accepted_Email = detaildPermissionViewModel.IsLeadProposalAcceptedEmail,
                Is_Lead_Proposal_Accepted_Text = detaildPermissionViewModel.IsLeadProposalAcceptedText,
                Is_Lead_Proposal_Accepted_Push = detaildPermissionViewModel.IsLeadProposalAcceptedPush,
                Is_Lead_Proposal_Accepted_All_Users = detaildPermissionViewModel.IsLeadProposalAcceptedAllUsers,

                Is_Lead_Proposal_Viewed_Email = detaildPermissionViewModel.IsLeadProposalViewedEmail,
                Is_Lead_Proposal_Viewed_Text = detaildPermissionViewModel.IsLeadProposalViewedText,
                Is_Lead_Proposal_Viewed_Push = detaildPermissionViewModel.IsLeadProposalViewedPush,

                Is_Linked_Clicked_By_Lead_Email = detaildPermissionViewModel.IsLinkedClickedByLeadEmail,
                Is_Linked_Clicked_By_Lead_Text = detaildPermissionViewModel.IsLinkedClickedByLeadText,

                Is_To_Do_Completed_Email = detaildPermissionViewModel.IsToDoCompletedEmail,
                Is_To_Do_Completed_Text = detaildPermissionViewModel.IsToDoCompletedText,
                Is_To_Do_Completed_Push = detaildPermissionViewModel.IsToDoCompletedPush,
                Is_To_Do_Discussion_Added_Email = detaildPermissionViewModel.IsToDoDiscussionAddedEmail,
                Is_To_Do_Discussion_Added_Text = detaildPermissionViewModel.IsToDoDiscussionAddedText,
                Is_To_Do_Discussion_Added_Push = detaildPermissionViewModel.IsToDoDiscussionAddedPush,

                Is_Daily_Log_Notification_Email = detaildPermissionViewModel.IsDailyLogNotificationEmail,
                Is_Daily_Log_Notification_Text = detaildPermissionViewModel.IsDailyLogNotificationText,
                Is_Daily_Log_Notification_Push = detaildPermissionViewModel.IsDailyLogNotificationPush,
                Is_Daily_Log_Discussion_Added_Email = detaildPermissionViewModel.IsDailyLogDiscussionAddedEmail,
                Is_Daily_Log_Notification_Added_Text = detaildPermissionViewModel.IsDailyLogNotificationAddedText,
                Is_Daily_Log_Notification_Added_Push = detaildPermissionViewModel.IsDailyLogNotificationAddedPush,

                Is_Bid_Submitted_Email = detaildPermissionViewModel.IsBidSubmittedEmail,
                Is_Bid_Submitted_Text = detaildPermissionViewModel.IsBidSubmittedText,
                Is_Bid_Submitted_Push = detaildPermissionViewModel.IsBidSubmittedPush,
                Is_Sub_Confirmation_Email = detaildPermissionViewModel.IsSubConfirmationEmail,
                Is_Sub_Confirmation_Text = detaildPermissionViewModel.IsSubConfirmationText,
                Is_Sub_Confirmation_Push = detaildPermissionViewModel.IsSubConfirmationPush,
                Is_Bid_Resubmitted_Email = detaildPermissionViewModel.IsBidResubmittedEmail,
                Is_Bid_Resubmitted_Text = detaildPermissionViewModel.IsBidResubmittedText,
                Is_Bid_Resubmitted_Push = detaildPermissionViewModel.IsBidResubmittedPush,
                Is_Bid_Discussion_Added_Email = detaildPermissionViewModel.IsBidDiscussionAddedEmail,
                Is_Bid_Discussion_Added_Text = detaildPermissionViewModel.IsBidDiscussionAddedText,
                Is_Bid_Discussion_Added_Push = detaildPermissionViewModel.IsBidDiscussionAddedPush,
                Is_Bid_Accepted_Builder_Email = detaildPermissionViewModel.IsBidAcceptedBuilderEmail,
                Is_Bid_Accepted_Builder_Text = detaildPermissionViewModel.IsBidAcceptedBuilderText,
                Is_Bid_Accepted_Builder_Push = detaildPermissionViewModel.IsBidAcceptedBuilderPush,

                Is_User_Need_To_Confirm_Change_Email = detaildPermissionViewModel.IsUserNeedToConfirmChangeEmail,
                Is_User_Need_To_Confirm_Change_Text = detaildPermissionViewModel.IsUserNeedToConfirmChangeText,
                Is_User_Need_To_Confirm_Change_Push = detaildPermissionViewModel.IsUserNeedToConfirmChangePush,
                Is_User_Confirmed_Change_Email = detaildPermissionViewModel.IsUserConfirmedChangeEmail,
                Is_User_Confirmed_Change_Text = detaildPermissionViewModel.IsUserConfirmedChangeText,
                Is_User_Confirmed_Change_Push = detaildPermissionViewModel.IsUserConfirmedChangePush,
                Is_User_Declined_Change_Email = detaildPermissionViewModel.IsUserDeclinedChangeEmail,
                Is_User_Declined_Change_Text = detaildPermissionViewModel.IsUserDeclinedChangeText,
                Is_User_Declined_Change_Push = detaildPermissionViewModel.IsUserDeclinedChangePush,
                Is_Schedule_Item_Discussion_Email = detaildPermissionViewModel.IsScheduleItemDiscussionEmail,
                Is_Schedule_Item_Discussion_Text = detaildPermissionViewModel.IsScheduleItemDiscussionText,
                Is_Schedule_Item_Discussion_Push = detaildPermissionViewModel.IsScheduleItemDiscussionPush,
                Is_Schedule_Item_Discussion_All_Users = detaildPermissionViewModel.IsScheduleItemDiscussionAllUsers,

                Is_Document_Comment_added_Email = detaildPermissionViewModel.IsDocumentCommentaddedEmail,
                Is_Document_Comment_added_Text = detaildPermissionViewModel.IsDocumentCommentaddedText,
                Is_Document_Comment_added_Push = detaildPermissionViewModel.IsDocumentCommentaddedPush,
                Is_Sub_And_Owner_Uploaded_Email = detaildPermissionViewModel.IsSubAndOwnerUploadedEmail,
                Is_Sub_And_Owner_Uploaded_Text = detaildPermissionViewModel.IsSubAndOwnerUploadedText,
                Is_Sub_And_Owner_Uploaded_Push = detaildPermissionViewModel.IsSubAndOwnerUploadedPush,
                Is_Signature_Request_Signed_Email = detaildPermissionViewModel.IsSignatureRequestSignedEmail,
                Is_Signature_Request_Signed_Push = detaildPermissionViewModel.IsSignatureRequestSignedPush,
                Is_Signature_Request_Past_Due_Email = detaildPermissionViewModel.IsSignatureRequestPastDueEmail,
                Is_Signature_Request_Past_Due_Push = detaildPermissionViewModel.IsSignatureRequestPastDuePush,

                Is_Video_Comment_Added_Email = detaildPermissionViewModel.IsVideoCommentAddedEmail,
                Is_Video_Comment_Added_Text = detaildPermissionViewModel.IsVideoCommentAddedText,
                Is_Video_Comment_Added_Push = detaildPermissionViewModel.IsVideoCommentAddedPush,
                Is_Photo_Comment_Added_Email = detaildPermissionViewModel.IsPhotoCommentAddedEmail,
                Is_Photo_Comment_Added_Text = detaildPermissionViewModel.IsPhotoCommentAddedText,
                Is_Photo_Comment_Added_Push = detaildPermissionViewModel.IsPhotoCommentAddedPush,

                Is_New_Message_Email = detaildPermissionViewModel.IsNewMessageEmail,
                Is_New_Message_Text = detaildPermissionViewModel.IsNewMessageText,
                Is_New_Message_Push = detaildPermissionViewModel.IsNewMessagePush,
                Is_New_Message_All_Users = detaildPermissionViewModel.IsNewMessageAllUsers,

                Is_RFI_Added_By_Builder_Email = detaildPermissionViewModel.IsRFIAddedByBuilderEmail,
                Is_RFI_Added_By_Builder_Text = detaildPermissionViewModel.IsRFIAddedByBuilderText,
                Is_RFI_Added_By_Builder_Push = detaildPermissionViewModel.IsRFIAddedByBuilderPush,
                Is_RFI_Response_Added_Email = detaildPermissionViewModel.IsRFIResponseAddedEmail,
                Is_RFI_Response_Added_Text = detaildPermissionViewModel.IsRFIResponseAddedText,
                Is_RFI_Response_Added_Push = detaildPermissionViewModel.IsRFIResponseAddedPush,
                Is_RFI_Added_Email = detaildPermissionViewModel.IsRFIAddedEmail,
                Is_RFI_Added_Text = detaildPermissionViewModel.IsRFIAddedText,
                Is_RFI_Added_Push = detaildPermissionViewModel.IsRFIAddedPush,
                Is_RFI_Completed_Email = detaildPermissionViewModel.IsRFICompletedEmail,
                Is_RFI_Completed_Text = detaildPermissionViewModel.IsRFICompletedText,
                Is_RFI_Completed_Push = detaildPermissionViewModel.IsRFICompletedPush,
                Is_RFI_Past_Due_Email = detaildPermissionViewModel.IsRFIPastDueEmail,
                Is_RFI_Past_Due_Text = detaildPermissionViewModel.IsRFIPastDueText,

                Is_Change_Order_approved_Email = detaildPermissionViewModel.IsChangeOrderapprovedEmail,
                Is_Change_Order_approved_Text = detaildPermissionViewModel.IsChangeOrderapprovedText,
                Is_Change_Order_approved_Push = detaildPermissionViewModel.IsChangeOrderapprovedPush,
                Is_Change_Order_added_Email = detaildPermissionViewModel.IsChangeOrderaddedEmail,
                Is_Change_Order_added_Text = detaildPermissionViewModel.IsChangeOrderaddedText,
                Is_Change_Order_added_Push = detaildPermissionViewModel.IsChangeOrderaddedPush,
                Is_Change_Order_files_added_Email = detaildPermissionViewModel.IsChangeOrderfilesaddedEmail,
                Is_Change_Order_files_added_Text = detaildPermissionViewModel.IsChangeOrderfilesaddedText,
                Is_Change_Order_files_added_Push = detaildPermissionViewModel.IsChangeOrderfilesaddedPush,
                Is_Change_Order_Discussion_added_Email = detaildPermissionViewModel.IsChangeOrderDiscussionaddedEmail,
                Is_Change_Order_Discussion_added_Text = detaildPermissionViewModel.IsChangeOrderDiscussionaddedText,
                Is_Change_Order_Discussion_added_Push = detaildPermissionViewModel.IsChangeOrderDiscussionaddedPush






            };

            var userPermission = await _detaildPermissionRepository.CreateAsync(detailedPermission);
            DetaildPermissionViewModel detaildPermissionViewModel1 = new DetaildPermissionViewModel
            {
                DetaildPermissionId = userPermission.Detaild_Permission_Id
            };
            return detaildPermissionViewModel1;
            // var userObj = await _userDetailsRepository.CreateAsync(userConfig);
        }

        public Task<int> UpdateUserDetails(int UserId, DetaildPermissionViewModel detaildPermissionViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
