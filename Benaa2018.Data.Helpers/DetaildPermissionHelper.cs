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

        public async Task<List<DetaildPermissionViewModel>> GetUserDetailsInfoByInfo(int UserId, int caseSet)
        {
            List<DetaildPermissionViewModel> lstUserDetailedPermissionsModel = new List<DetaildPermissionViewModel>();
            IEnumerable<DetaildPermission> lstUserPermissions = null;
            lstUserPermissions = await _detaildPermissionRepository.GetAllAsync();
            lstUserPermissions = lstUserPermissions.Where(a => a.User_ID == UserId).ToList();
            if (lstUserPermissions != null)
            {
                foreach (var item in lstUserPermissions)
                {
                    if (caseSet == 1)
                    {
                        lstUserDetailedPermissionsModel.Add(new DetaildPermissionViewModel
                        {
                            IsViewAll = item.Is_View_All,
                            IsAddAll = item.Is_Add_All,
                            IsEditall = item.Is_Edit_all,
                            IsDeleteAll = item.Is_Delete_All,

                            IsJobInfoView = item.Is_Job_Info_View,
                            IsJobInfoAdd = item.Is_Job_Info_Add,
                            IsJobInfoEdit = item.Is_Job_Info_Edit,
                            IsJobInfodelete = item.Is_Job_Info_delete,
                            IsViewOwnerSite = item.Is_View_Owner_Site,
                            IsPriceViewing = item.Is_Price_Viewing,

                            IsOwnerPaymentsView = item.Is_Owner_Payments_View,
                            IsOwnerPaymentsAdd = item.Is_Owner_Payments_Add,
                            IsOwnerPaymentsEdit = item.Is_Owner_Payments_Edit,
                            IsOwnerPaymentsDelete = item.Is_Owner_Payments_Delete,

                            IsLeadsView = item.Is_Leads_View,
                            IsLeadsAdd = item.Is_Leads_Add,
                            IsLeadsEdit = item.Is_Leads_Edit,
                            IsLeadsDelete = item.Is_Leads_Delete,

                            IsLeadsAssignSalesperson = item.Is_Leads_Assign_Salesperson,
                            IsLeadsViewOtherSalesperson = item.Is_Leads_View_Other_Salesperson,
                            IsLeadsConvertToJobsite = item.Is_Leads_Convert_To_Jobsite,
                            IsLeadsExportToExcel = item.Is_Leads_Export_To_Excel,

                            IsCustomerContactsViewReadOnly = item.Is_Customer_Contacts_View_ReadOnly,
                            IsCustomerContactsView = item.Is_Customer_Contacts_View,
                            IsCustomerContactsAddReadOnly = item.Is_Customer_Contacts_Add_ReadOnly,
                            IsCustomerContactsAdd = item.Is_Customer_Contacts_Add,
                            IsCustomerContactsEdit = item.Is_Customer_Contacts_Edit,
                            IsCustomerContactsDelete = item.Is_Customer_Contacts_Delete,

                            IsViewAllCustomerContactsReadonly = item.Is_View_All_Customer_Contacts_Readonly,
                            IsViewAllCustomerContacts = item.Is_View_All_Customer_Contacts,
                            IsCustomerContactsExportToExcel = item.Is_Customer_Contacts_Export_To_Excel,

                            IsToDoView = item.Is_To_Do_View,
                            IsToDoAdd = item.Is_To_Do_Add,
                            IsToDoEdit = item.Is_To_Do_Edit,
                            IsToDoDelete = item.Is_To_Do_Delete,
                            IsToDoAssignUsers = item.Is_To_Do_Assign_Users,
                            IsToDoGlobal = item.Is_To_Do_Global,

                            IsLogsView = item.Is_Logs_View,
                            IsLogsAdd = item.Is_Logs_Add,
                            IsLogsEdit = item.Is_Logs_Edit,
                            IsLogsDelete = item.Is_Logs_Delete,

                            IsBidsView = item.Is_Bids_View,
                            IsBidsAdd = item.Is_Bids_Add,
                            IsBidsEdit = item.Is_Bids_Edit,
                            IsBidsDelete = item.Is_Bids_Delete,

                            IsCalendarView = item.Is_Calendar_View,
                            IsCalendarAdd = item.Is_Calendar_Add,
                            IsCalendarEdit = item.Is_Calendar_Edit,
                            IsCalendarDelete = item.Is_Calendar_Delete,
                            IsSetBaseline = item.Is_Set_Baseline,

                            IsDocumentsView = item.Is_Documents_View,
                            IsDocumentsAdd = item.Is_Documents_Add,
                            IsDocumentsEdit = item.Is_Documents_Edit,
                            IsDocumentsDelete = item.Is_Documents_Delete,

                            IsDocumentsAccessSubOwner = item.Is_Documents_Access_SubOwner,
                            IsDocumentsSignature = item.Is_Documents_Signature,

                            IsVideosView = item.Is_Videos_View,
                            IsVideosAdd = item.Is_Videos_Add,
                            IsVideosEdit = item.Is_Videos_Edit,
                            IsVideosDelete = item.Is_Videos_Delete,

                            IsPhotosView = item.Is_Photos_View,
                            IsPhotosAdd = item.Is_Photos_Add,
                            IsPhotosEdit = item.Is_Photos_Edit,
                            IsPhotosDelete = item.Is_Photos_Delete,

                            IsMessagesView = item.Is_Messages_View,
                            IsMessagesAdd = item.Is_Messages_Add,
                            IsMessagesAddReadonly = item.Is_Messages_Add_Readonly,
                            IsMessagesEdit = item.Is_Messages_Edit,
                            IsMessagesEditReadonly = item.Is_Messages_Edit_Readonly,
                            IsMessagesDelete = item.Is_Messages_Delete,
                            IsMessageGlobal = item.Is_Message_Global,

                            IsRFIView = item.Is_RFI_View,
                            IsRFIAdd = item.Is_RFI_Add,
                            IsRFIEdit = item.Is_RFI_Edit,
                            IsRFIDelete = item.Is_RFI__Delete,

                            IsChangeOrdersView = item.Is_Change_Orders_View,
                            IsChangeOrdersAdd = item.Is_Change_Orders_Add,
                            IsChangeOrdersEdit = item.Is_Change_Orders_Edit,
                            IsChangeOrdersDelete = item.Is_Change_Orders_Delete,
                            IsChangeOrdersCostViewing = item.Is_Change_Orders_Cost_Viewing,

                            IsSelectionsView = item.Is_Selections_View,
                            IsSelectionsAdd = item.Is_Selections_Add,
                            IsSelectionsEdit = item.Is_Selections_Edit,
                            IsSelectionsDelete = item.Is_Selections_Delete,
                            IsSelectionsCostViewing = item.Is_Selections_Cost_Viewing,

                            IsBillView = item.Is_Bill_View,
                            IsBillAdd = item.Is_Bill_Add,
                            IsBillEdit = item.Is_Bill_Edit,
                            IsBillDelete = item.Is_Bill_Delete,
                            IsBillAccounting = item.Is_Bill_Accounting,
                            IsBillNoPriceLimit = item.Is_Bill_No_Price_Limit,
                            IsBillCostViewing = item.Is_Bill_Cost_Viewing,

                            IsWarrantyView = item.Is_Warranty_View,
                            IsWarrantyAdd = item.Is_Warranty_Add,
                            IsWarrantyEdit = item.Is_Warranty_Edit,
                            IsWarrantyDelete = item.Is_Warranty_Delete,

                            IsTimeClockView = item.Is_Time_Clock_View,
                            IsTimeClockAdd = item.Is_Time_Clock_Add,
                            IsTimeClockEdit = item.Is_Time_Clock_Edit,
                            IsTimeClockDelete = item.Is_Time_Clock_Delete,
                            IsTimeClockViewOtherUser = item.Is_Time_Clock_View_Other_User,
                            IsTimeClockAdjustOtherUser = item.Is_Time_Clock_Adjust_Other_User,
                            IsTimeClockCostViewing = item.Is_Time_Clock_Cost_Viewing,
                            IsTimeClockReviewAndApprove = item.Is_Time_Clock_Review_And_Approve,

                            IsEstimateGIView = item.Is_Estimate_GI_View,
                            IsEstimateGIAdd = item.Is_Estimate_GI_Add,
                            IsEstimateGIEdit = item.Is_Estimate_GI_Edit,
                            IsEstimateGIDelete = item.Is_Estimate_GI_Delete,
                            IsEstimateGIPriceViewing = item.Is_Estimate_GI_Price_Viewing,

                            IsSurveyView = item.Is_Survey_View,
                            IsSurveyAdd = item.Is_Survey_Add,
                            IsSurveyEdit = item.Is_Survey_Edit,
                            IsSurveyDelete = item.Is_Survey_Delete,
                            IsSurveyAddReviewWebsite = item.Is_Survey_Add_Review_Website,

                            IsSubsView = item.Is_Subs_View,
                            IsSubsAdd = item.Is_Subs_Add,
                            IsSubsEdit = item.Is_Subs_Edit,
                            IsSubsDelete = item.Is_Subs_Delete,

                            IsAdminView = item.Is_Admin_View,
                            IsAdminViewReadonly = item.Is_Admin_View_Readonly,
                            IsAdminAdd = item.Is_Admin_Add,
                            IsAdminAddReadonly = item.Is_Admin_Add_Readonly,
                            IsAdminEdit = item.Is_Admin_Edit,
                            IsAdminEditReadonly = item.Is_Admin_Edit_Readonly,
                            IsAdminDelete = item.Is_Admin_Delete,
                            IsAdminDeleteReadonly = item.Is_Admin_Delete_Readonly
                        });
                    }
                    else
                    {
                        lstUserDetailedPermissionsModel.Add(new DetaildPermissionViewModel
                        {
                            ImportNotificationId = item.Import_Notification_Id,
                            IsEmailAll = item.Is_Email_All,
                            IsTextAll = item.Is_Text_All,
                            IsPushOn = item.Is_Push_On,
                            IsAllUsers = item.Is_All_Users,

                            IsOwnerActivatedEmail = item.Is_Owner_Activated_Email,

                            IsOwnerPaymentUpdatedEmail = item.Is_Owner_Payment_Updated_Email,
                            IsOwnerPaymentUpdatedText = item.Is_Owner_Payment_Updated_Text,
                            IsOwnerPaymentUpdatedPush = item.Is_Owner_Payment_Updated_Push,

                            IsOwnerPaymentReminderEmail = item.Is_Owner_Payment_Reminder_Email,
                            IsOwnerPaymentReminderText = item.Is_Owner_Payment_Reminder_Text,
                            IsOwnerPaymentReminderPush = item.Is_Owner_Payment_Reminder_Push,


                            IsOwnerPaymentPastDueEmail = item.Is_Owner_Payment_Past_Due_Email,
                            IsOwnerPaymentPastDueText = item.Is_Owner_Payment_Past_Due_Text,
                            IsOwnerPaymentPastDuePush = item.Is_Owner_Payment_Past_Due_Push,


                            IsOwnerPaymentDiscussionEmail = item.Is_Owner_Payment_Discussion_Email,
                            IsOwnerPaymentDiscussionText = item.Is_Owner_Payment_Discussion_Text,
                            IsOwnerPaymentDiscussionPush = item.Is_Owner_Payment_Discussion_Push,

                            IsOwnerPaymentAddedEmail = item.Is_Owner_Payment_Added_Email,
                            IsOwnerPaymentAddedText = item.Is_Owner_Payment_Added_Text,
                            IsOwnerPaymentAddedPush = item.Is_Owner_Payment_Added_Push,

                            IsOtherEmployeeContactEmail = item.Is_Other_Employee_Contact_Email,
                            IsOtherEmployeeContactText = item.Is_Other_Employee_Contact_Text,

                            IsNewLeadEmail = item.Is_New_Lead_Email,
                            IsNewLeadText = item.Is_New_Lead_Text,
                            IsNewLeadPush = item.Is_New_Lead_Push,

                            IsLeadNotifyEmail = item.Is_Lead_Notify_Email,
                            IsLeadNotifyText = item.Is_Lead_Notify_Text,
                            IsLeadNotifyPush = item.Is_Lead_Notify_Push,
                            IsActivityRemainderEmail = item.Is_Activity_Remainder_Email,
                            IsActivityRemainderText = item.Is_Activity_Remainder_Text,
                            IsActivityRemainderPush = item.Is_Activity_Remainder_Push,
                            IsActivityRemainderAllUsers = item.Is_Activity_Remainder_All_Users,

                            IsEmailQuotesAlertEmail = item.Is_Email_Quotes_Alert_Email,
                            IsEmailQuotesAlertText = item.Is_Email_Quotes_Alert_Text,
                            IsAssignedToLeadActivityEmail = item.Is_Assigned_To_Lead_Activity_Email,
                            IsAssignedToLeadActivityText = item.Is_Assigned_To_Lead_Activity_Text,
                            IsAssignedToLeadActivityPush = item.Is_Assigned_To_Lead_Activity_Push,

                            IsLeadProposalAcceptedEmail = item.Is_Lead_Proposal_Accepted_Email,
                            IsLeadProposalAcceptedText = item.Is_Lead_Proposal_Accepted_Text,
                            IsLeadProposalAcceptedPush = item.Is_Lead_Proposal_Accepted_Push,
                            IsLeadProposalAcceptedAllUsers = item.Is_Lead_Proposal_Accepted_All_Users,

                            IsLeadProposalViewedEmail = item.Is_Lead_Proposal_Viewed_Email,
                            IsLeadProposalViewedText = item.Is_Lead_Proposal_Viewed_Text,
                            IsLeadProposalViewedPush = item.Is_Lead_Proposal_Viewed_Push,


                            IsLinkedClickedByLeadEmail = item.Is_Linked_Clicked_By_Lead_Email,
                            IsLinkedClickedByLeadText = item.Is_Linked_Clicked_By_Lead_Text,

                            IsToDoCompletedEmail = item.Is_To_Do_Completed_Email,
                            IsToDoCompletedText = item.Is_To_Do_Completed_Text,
                            IsToDoCompletedPush = item.Is_To_Do_Completed_Push,
                            IsToDoDiscussionAddedEmail = item.Is_To_Do_Discussion_Added_Email,
                            IsToDoDiscussionAddedText = item.Is_To_Do_Discussion_Added_Text,
                            IsToDoDiscussionAddedPush = item.Is_To_Do_Discussion_Added_Push,

                            IsDailyLogNotificationEmail = item.Is_Daily_Log_Notification_Email,
                            IsDailyLogNotificationText = item.Is_Daily_Log_Notification_Text,
                            IsDailyLogNotificationPush = item.Is_Daily_Log_Notification_Push,
                            IsDailyLogDiscussionAddedEmail = item.Is_Daily_Log_Discussion_Added_Email,
                            IsDailyLogNotificationAddedText = item.Is_Daily_Log_Notification_Added_Text,
                            IsDailyLogNotificationAddedPush = item.Is_Daily_Log_Notification_Added_Push,

                            IsBidSubmittedEmail = item.Is_Bid_Submitted_Email,
                            IsBidSubmittedText = item.Is_Bid_Submitted_Text,
                            IsBidSubmittedPush = item.Is_Bid_Submitted_Push,
                            IsSubConfirmationEmail = item.Is_Sub_Confirmation_Email,
                            IsSubConfirmationText = item.Is_Sub_Confirmation_Text,
                            IsSubConfirmationPush = item.Is_Sub_Confirmation_Push,
                            IsBidResubmittedEmail = item.Is_Bid_Resubmitted_Email,
                            IsBidResubmittedText = item.Is_Bid_Resubmitted_Text,
                            IsBidResubmittedPush = item.Is_Bid_Resubmitted_Push,
                            IsBidDiscussionAddedEmail = item.Is_Bid_Discussion_Added_Email,
                            IsBidDiscussionAddedText = item.Is_Bid_Discussion_Added_Text,
                            IsBidDiscussionAddedPush = item.Is_Bid_Discussion_Added_Push,
                            IsBidAcceptedBuilderEmail = item.Is_Bid_Accepted_Builder_Email,
                            IsBidAcceptedBuilderText = item.Is_Bid_Accepted_Builder_Text,
                            IsBidAcceptedBuilderPush = item.Is_Bid_Accepted_Builder_Push,


                            IsUserNeedToConfirmChangeEmail = item.Is_User_Need_To_Confirm_Change_Email,
                            IsUserNeedToConfirmChangeText = item.Is_User_Need_To_Confirm_Change_Text,
                            IsUserNeedToConfirmChangePush = item.Is_User_Need_To_Confirm_Change_Push,
                            IsUserConfirmedChangeEmail = item.Is_User_Confirmed_Change_Email,
                            IsUserConfirmedChangeText = item.Is_User_Confirmed_Change_Text,
                            IsUserConfirmedChangePush = item.Is_User_Confirmed_Change_Push,
                            IsUserDeclinedChangeEmail = item.Is_User_Declined_Change_Email,
                            IsUserDeclinedChangeText = item.Is_User_Declined_Change_Text,
                            IsUserDeclinedChangePush = item.Is_User_Declined_Change_Push,
                            IsScheduleItemDiscussionEmail = item.Is_Schedule_Item_Discussion_Email,
                            IsScheduleItemDiscussionText = item.Is_Schedule_Item_Discussion_Text,
                            IsScheduleItemDiscussionPush = item.Is_Schedule_Item_Discussion_Push,
                            IsScheduleItemDiscussionAllUsers = item.Is_Schedule_Item_Discussion_All_Users,

                            IsDocumentCommentaddedEmail = item.Is_Document_Comment_added_Email,
                            IsDocumentCommentaddedText = item.Is_Document_Comment_added_Text,
                            IsDocumentCommentaddedPush = item.Is_Document_Comment_added_Push,
                            IsSubAndOwnerUploadedEmail = item.Is_Sub_And_Owner_Uploaded_Email,
                            IsSubAndOwnerUploadedText = item.Is_Sub_And_Owner_Uploaded_Text,
                            IsSubAndOwnerUploadedPush = item.Is_Sub_And_Owner_Uploaded_Push,
                            IsSignatureRequestSignedEmail = item.Is_Signature_Request_Signed_Email,
                            IsSignatureRequestSignedPush = item.Is_Signature_Request_Signed_Push,
                            IsSignatureRequestPastDueEmail = item.Is_Signature_Request_Past_Due_Email,
                            IsSignatureRequestPastDuePush = item.Is_Signature_Request_Past_Due_Push,

                            IsVideoCommentAddedEmail = item.Is_Video_Comment_Added_Email,
                            IsVideoCommentAddedText = item.Is_Video_Comment_Added_Text,
                            IsVideoCommentAddedPush = item.Is_Video_Comment_Added_Push,
                            IsPhotoCommentAddedEmail = item.Is_Photo_Comment_Added_Email,
                            IsPhotoCommentAddedText = item.Is_Photo_Comment_Added_Text,
                            IsPhotoCommentAddedPush = item.Is_Photo_Comment_Added_Push,

                            IsNewMessageEmail = item.Is_New_Message_Email,
                            IsNewMessageText = item.Is_New_Message_Text,
                            IsNewMessagePush = item.Is_New_Message_Push,
                            IsNewMessageAllUsers = item.Is_New_Message_All_Users,

                            IsRFIAddedByBuilderEmail = item.Is_RFI_Added_By_Builder_Email,
                            IsRFIAddedByBuilderText = item.Is_RFI_Added_By_Builder_Text,
                            IsRFIAddedByBuilderPush = item.Is_RFI_Added_By_Builder_Push,
                            IsRFIResponseAddedEmail = item.Is_RFI_Response_Added_Email,
                            IsRFIResponseAddedText = item.Is_RFI_Response_Added_Text,
                            IsRFIResponseAddedPush = item.Is_RFI_Response_Added_Push,
                            IsRFIAddedEmail = item.Is_RFI_Added_Email,
                            IsRFIAddedText = item.Is_RFI_Added_Text,
                            IsRFIAddedPush = item.Is_RFI_Added_Push,
                            IsRFICompletedEmail = item.Is_RFI_Completed_Email,
                            IsRFICompletedText = item.Is_RFI_Completed_Text,
                            IsRFICompletedPush = item.Is_RFI_Completed_Push,
                            IsRFIPastDueEmail = item.Is_RFI_Past_Due_Email,
                            IsRFIPastDueText = item.Is_RFI_Past_Due_Text,


                            IsChangeOrderapprovedEmail = item.Is_Change_Order_approved_Email,
                            IsChangeOrderapprovedText = item.Is_Change_Order_approved_Text,
                            IsChangeOrderapprovedPush = item.Is_Change_Order_approved_Push,
                            IsChangeOrderaddedEmail = item.Is_Change_Order_added_Email,
                            IsChangeOrderaddedText = item.Is_Change_Order_added_Text,
                            IsChangeOrderaddedPush = item.Is_Change_Order_added_Push,
                            IsChangeOrderfilesaddedEmail = item.Is_Change_Order_files_added_Email,
                            IsChangeOrderfilesaddedText = item.Is_Change_Order_files_added_Text,
                            IsChangeOrderfilesaddedPush = item.Is_Change_Order_files_added_Push,
                            IsChangeOrderDiscussionaddedEmail = item.Is_Change_Order_Discussion_added_Email,
                            IsChangeOrderDiscussionaddedText = item.Is_Change_Order_Discussion_added_Text,
                            IsChangeOrderDiscussionaddedPush = item.Is_Change_Order_Discussion_added_Push,
                            IsChangeOrderDiscussionaddedAllUsers = item.Is_Change_Order_Discussion_added_All_Users,
                            IsOwnerRequestedChangeOrderEmail = item.Is_Owner_Requested_Change_Order_Email,
                            IsOwnerRequestedChangeOrderText = item.Is_Owner_Requested_Change_Order_Text,
                            IsOwnerRequestedChangeOrderPush = item.Is_Owner_Requested_Change_Order_Push,
                            IsChangeOrderPastDueEmail = item.Is_Change_Order_Past_Due_Email,
                            IsChangeOrderPastDueText = item.Is_Change_Order_Past_Due_Text,

                            IsSelectionApprovedEmail = item.Is_Selection_Approved_Email,
                            IsSelectionApprovedText = item.Is_Selection_Approved_Text,
                            IsSelectionApprovedPush = item.Is_Selection_Approved_Push,
                            IsSelectionDeadlineReminderEmail = item.Is_Selection_Deadline_Reminder_Email,
                            IsSelectionDeadlineReminderPush = item.Is_Selection_Deadline_Reminder_Push,
                            IsSelectionDiscussionAddedEmail = item.Is_Selection_Discussion_Added_Email,
                            IsSelectionDiscussionAddedText = item.Is_Selection_Discussion_Added_Text,
                            IsSelectionDiscussionAddedPush = item.Is_Selection_Discussion_Added_Push,
                            IsSelectionChoiceAddedEmail = item.Is_Selection_Choice_Added_Email,
                            IsSelectionChoiceAddedText = item.Is_Selection_Choice_Added_Text,
                            IsSelectionChoiceAddedPush = item.Is_Selection_Choice_Added_Push,
                            IsSelectionOwnerPriceEmail = item.Is_Selection_Owner_Price_Email,
                            IsSelectionOwnerPriceText = item.Is_Selection_Owner_Price_Text,
                            IsSelectionOwnerPricePush = item.Is_Selection_Owner_Price_Push,
                            IsSelectionSubPriceEmail = item.Is_Selection_Sub_Price_Email,
                            IsSelectionSubPriceText = item.Is_Selection_Sub_Price_Text,
                            IsSelectionSubPricePush = item.Is_Selection_Sub_Price_Push,

                            IsPOApprovedEmail = item.Is_PO_Approved_Email,
                            IsPOApprovedText = item.Is_PO_Approved_Text,
                            IsPOApprovedPush = item.Is_PO_Approved_Push,
                            IsPOPaymentMarkedEmail = item.Is_PO_Payment_Marked_Email,
                            IsLienWaiverAcceptedEmail = item.Is_Lien_Waiver_Accepted_Email,
                            IsLienWaiverAcceptedText = item.Is_Lien_Waiver_Accepted_Text,
                            IsLienWaiverDeclinedEmail = item.Is_Lien_Waiver_Declined_Email,
                            IsLienWaiverDeclinedText = item.Is_Lien_Waiver_Declined_Text,
                            IsPOApprovedInternallyEmail = item.Is_PO_Approved_Internally_Email,
                            IsPOApprovedInternallyText = item.Is_PO_Approved_Internally_Text,
                            IsPOApprovedInternallyPush = item.Is_PO_Approved_Internally_Push,
                            IsPODeclinedEmail = item.Is_PO_Declined_Email,
                            IsPODeclinedText = item.Is_PO_Declined_Text,
                            IsPODeclinedPush = item.Is_PO_Declined_Push,
                            IsPOAssignedInternallyEmail = item.Is_PO_Assigned_Internally_Email,
                            IsPOAssignedInternallyText = item.Is_PO_Assigned_Internally_Text,
                            IsPOInspectionEmail = item.Is_PO_Inspection_Email,
                            IsPOInspectionPush = item.Is_PO_Inspection_Push,
                            IsPOWorkcompletedEmail = item.Is_PO_Work_completed_Email,
                            IsPOPaymentMadeEmail = item.Is_PO_Payment_Made_Email,
                            IsPODiscussionAddedEmail = item.Is_PO_Discussion_Added_Email,
                            IsPODiscussionAddedText = item.Is_PO_Discussion_Added_Text,
                            IsPODiscussionAddedPush = item.Is_PO_Discussion_Added_Push,
                            IsPOFileAddedEmail = item.Is_PO_File_Added_Email,
                            IsPOInspectionReminderEmail = item.Is_PO_Inspection_Reminder_Email,
                            IsPOInspectionReminderText = item.Is_PO_Inspection_Reminder_Text,
                            IsPOInspectionReminderPush = item.Is_PO_Inspection_Reminder_Push,
                            IsPOWorkCompleteEmail = item.Is_PO_Work_Complete_Email,
                            IsPOWorkCompleteText = item.Is_PO_Work_Complete_Text,
                            IsPOWorkCompletePush = item.Is_PO_Work_Complete_Push,
                            IsBillPaymentReminderEmail = item.Is_Bill_Payment_Reminder_Email,

                            IsWarrantyAddedEmail = item.Is_Warranty_Added_Email,
                            IsWarrantyAddedText = item.Is_Warranty_Added_Text,
                            IsWarrantyAddedPush = item.Is_Warranty_Added_Push,
                            IsWarrantyFollowUpEmail = item.Is_Warranty_Follow_Up_Email,
                            IsWarrantyFollowUpText = item.Is_Warranty_Follow_Up_Text,
                            IsWarrantyFollowUpAllUsers = item.Is_Warranty_Follow_Up_All_Users,
                            IsWarrantyUpdatedEmail = item.Is_Warranty_Updated_Email,
                            IsWarrantyUpdatedText = item.Is_Warranty_Updated_Text,
                            IsWarrantyHasFeedbackEmail = item.Is_Warranty_Has_Feedback_Email,
                            IsWarrantyUpdatedApptEmail = item.Is_Warranty_Updated_Appt_Email,
                            IsWarrantyUpdatedApptText = item.Is_Warranty_Updated_Appt_Text,
                            IsWarrantyScheduleChangedEmail = item.Is_Warranty_Schedule_Changed_Email,
                            IsWarrantyScheduleChangedText = item.Is_Warranty_Schedule_Changed_Text,
                            IsWarrantyAddedInternallyEmail = item.Is_Warranty_Added_Internally_Email,
                            IsWarrantyAddedInternallyText = item.Is_Warranty_Added_Internally_Text,
                            IsWarrantyAddedInternallyPush = item.Is_Warranty_Added_Internally_Push,
                            IsWarrantyDiscussionAddedEmail = item.Is_Warranty_Discussion_Added_Email,
                            IsWarrantyDiscussionAddedText = item.Is_Warranty_Discussion_Added_Text,
                            IsWarrantyDiscussionAddedPush = item.Is_Warranty_Discussion_Added_Push,
                            IsWarrantyDiscussionAddedAllUsers = item.Is_Warranty_Discussion_Added_All_Users,
                            IsWarrantyServiceInternallyAssignedEmail = item.Is_Warranty_Service_Internally_Assigned_Email,
                            IsWarrantyServiceInternallyAssignedText = item.Is_Warranty_Service_Internally_Assigned_Text,



                            IsTimeSheetAdjustmentEmail = item.Is_Time_Sheet_Adjustment_Email,
                            IsTimeSheetAdjustmentText = item.Is_Time_Sheet_Adjustment_Text,
                            IsTimeSheetAdjustmentPush = item.Is_Time_Sheet_Adjustment_Push,
                            IsTimeSheetAdjustmentAllUsers = item.Is_Time_Sheet_Adjustment_All_Users,
                            IsOverTimeReachedEmail = item.Is_Over_Time_Reached_Email,
                            IsOverTimeReachedText = item.Is_Over_Time_Reached_Text,
                            IsOverTimeReachedPush = item.Is_Over_Time_Reached_Push,
                            IsOverTimeReachedAllUsers = item.Is_Over_Time_Reached_All_Users,


                            IsEstimateAcceptedEmail = item.Is_Estimate_Accepted_Email,
                            IsEstimateAcceptedText = item.Is_Estimate_Accepted_Text,
                            IsEstimateViewedEmail = item.Is_Estimate_Viewed_Email,
                            IsEstimateViewedText = item.Is_Estimate_Viewed_Text,


                            IsOwnerSumittedSurveyEmail = item.Is_Owner_Sumitted_Survey_Email,
                            IsOwnerSumittedSurveyText = item.Is_Owner_Sumitted_Survey_Text,

                            IsSubInsuranceRemiderEmail = item.Is_Sub_Insurance_Remider_Email,
                            IsSubActivatedEmail = item.Is_Sub_Activated_Email,
                            IsTradeAgreementActionTakenEmail = item.Is_Trade_Agreement_Action_Taken_Email

                        });
                    }
                }
            }
            return lstUserDetailedPermissionsModel;
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
