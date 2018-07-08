using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Benaa2018.Helper.ViewModels
{
   public class DetaildPermissionViewModel : BaseViewModel
    {

        public int DetaildPermissionId { get; set; }

        public int UserID { get; set; }



        public bool IsViewAll { get; set; }
        public bool IsAddAll { get; set; }
        public bool IsEditall { get; set; }
        public bool IsDeleteAll { get; set; }

        public bool IsJobInfoView { get; set; }
        public bool IsJobInfoAdd { get; set; }
        public bool IsJobInfoEdit { get; set; }
        public bool IsJobInfodelete { get; set; }
        public bool IsViewOwnerSite { get; set; }
        public bool IsPriceViewing { get; set; }



        public bool IsOwnerPaymentsView { get; set; }
        public bool IsOwnerPaymentsAdd { get; set; }
        public bool IsOwnerPaymentsEdit { get; set; }
        public bool IsOwnerPaymentsDelete { get; set; }


        public bool IsLeadsView { get; set; }
        public bool IsLeadsAdd { get; set; }
        public bool IsLeadsEdit { get; set; }
        public bool IsLeadsDelete { get; set; }

        public bool IsLeadsAssignSalesperson { get; set; }
        public bool IsLeadsViewOtherSalesperson { get; set; }
        public bool IsLeadsConvertToJobsite { get; set; }
        public bool IsLeadsExportToExcel { get; set; }

        public bool IsCustomerContactsViewReadOnly { get; set; }
        public bool IsCustomerContactsView { get; set; }
        public bool IsCustomerContactsAddReadOnly { get; set; }
        public bool IsCustomerContactsAdd { get; set; }
        public bool IsCustomerContactsEdit { get; set; }
        public bool IsCustomerContactsDelete { get; set; }

        public bool IsViewAllCustomerContactsReadonly { get; set; }
        public bool IsViewAllCustomerContacts { get; set; }
        public bool IsCustomerContactsExportToExcel { get; set; }

        public bool IsToDoView { get; set; }
        public bool IsToDoAdd { get; set; }
        public bool IsToDoEdit { get; set; }
        public bool IsToDoDelete { get; set; }
        public bool IsToDoAssignUsers { get; set; }
        public bool IsToDoGlobal { get; set; }

        public bool IsLogsView { get; set; }
        public bool IsLogsAdd { get; set; }
        public bool IsLogsEdit { get; set; }
        public bool IsLogsDelete { get; set; }

        public bool IsBidsView { get; set; }
        public bool IsBidsAdd { get; set; }
        public bool IsBidsEdit { get; set; }
        public bool IsBidsDelete { get; set; }

        public bool IsCalendarView { get; set; }
        public bool IsCalendarAdd { get; set; }
        public bool IsCalendarEdit { get; set; }
        public bool IsCalendarDelete { get; set; }
        public bool IsSetBaseline { get; set; }

        public bool IsDocumentsView { get; set; }
        public bool IsDocumentsAdd { get; set; }
        public bool IsDocumentsEdit { get; set; }
        public bool IsDocumentsDelete { get; set; }

        public bool IsDocumentsAccessSubOwner { get; set; }
        public bool IsDocumentsSignature { get; set; }

        public bool IsVideosView { get; set; }
        public bool IsVideosAdd { get; set; }
        public bool IsVideosEdit { get; set; }
        public bool IsVideosDelete { get; set; }

        public bool IsPhotosView { get; set; }
        public bool IsPhotosAdd { get; set; }
        public bool IsPhotosEdit { get; set; }
        public bool IsPhotosDelete { get; set; }

        public bool IsMessagesView { get; set; }
        public bool IsMessagesAdd { get; set; }
        public bool IsMessagesAddReadonly { get; set; }
        public bool IsMessagesEdit { get; set; }
        public bool IsMessagesEditReadonly { get; set; }
        public bool IsMessagesDelete { get; set; }
        public bool IsMessageGlobal { get; set; }

        public bool IsRFIView { get; set; }
        public bool IsRFIAdd { get; set; }
        public bool IsRFIEdit { get; set; }
        public bool IsRFIDelete { get; set; }

        public bool IsChangeOrdersView { get; set; }
        public bool IsChangeOrdersAdd { get; set; }
        public bool IsChangeOrdersEdit { get; set; }
        public bool IsChangeOrdersDelete { get; set; }
        public bool IsChangeOrdersCostViewing { get; set; }

        public bool IsSelectionsView { get; set; }
        public bool IsSelectionsAdd { get; set; }
        public bool IsSelectionsEdit { get; set; }
        public bool IsSelectionsDelete { get; set; }
        public bool IsSelectionsCostViewing { get; set; }

        public bool IsBillView { get; set; }
        public bool IsBillAdd { get; set; }
        public bool IsBillEdit { get; set; }
        public bool IsBillDelete { get; set; }
        public bool IsBillAccounting { get; set; }
        public bool IsBillNoPriceLimit { get; set; }
        public bool IsBillCostViewing { get; set; }

        public bool IsWarrantyView { get; set; }
        public bool IsWarrantyAdd { get; set; }
        public bool IsWarrantyEdit { get; set; }
        public bool IsWarrantyDelete { get; set; }

        public bool IsTimeClockView { get; set; }
        public bool IsTimeClockAdd { get; set; }
        public bool IsTimeClockEdit { get; set; }
        public bool IsTimeClockDelete { get; set; }
        public bool IsTimeClockViewOtherUser { get; set; }
        public bool IsTimeClockAdjustOtherUser { get; set; }
        public bool IsTimeClockCostViewing { get; set; }
        public bool IsTimeClockReviewAndApprove { get; set; }

        public bool IsEstimateGIView { get; set; }
        public bool IsEstimateGIAdd { get; set; }
        public bool IsEstimateGIEdit { get; set; }
        public bool IsEstimateGIDelete { get; set; }
        public bool IsEstimateGIPriceViewing { get; set; }

        public bool IsSurveyView { get; set; }
        public bool IsSurveyAdd { get; set; }
        public bool IsSurveyEdit { get; set; }
        public bool IsSurveyDelete { get; set; }
        public bool IsSurveyAddReviewWebsite { get; set; }

        public bool IsSubsView { get; set; }
        public bool IsSubsAdd { get; set; }
        public bool IsSubsEdit { get; set; }
        public bool IsSubsDelete { get; set; }

        public bool IsAdminView { get; set; }
        public bool IsAdminViewReadonly { get; set; }
        public bool IsAdminAdd { get; set; }
        public bool IsAdminAddReadonly { get; set; }
        public bool IsAdminEdit { get; set; }
        public bool IsAdminEditReadonly { get; set; }
        public bool IsAdminDelete { get; set; }
        public bool IsAdminDeleteReadonly { get; set; }

        public int ImportNotificationId { get; set; }
        public bool IsEmailAll { get; set; }
        public bool IsTextAll { get; set; }
        public bool IsPushOn { get; set; }
        public bool IsAllUsers { get; set; }

        public bool IsOwnerActivatedEmail { get; set; }

        public bool IsOwnerPaymentUpdatedEmail { get; set; }
        public bool IsOwnerPaymentUpdatedText { get; set; }
        public bool IsOwnerPaymentUpdatedPush { get; set; }

        public bool IsOwnerPaymentReminderEmail { get; set; }
        public bool IsOwnerPaymentReminderText { get; set; }
        public bool IsOwnerPaymentReminderPush { get; set; }


        public bool IsOwnerPaymentPastDueEmail { get; set; }
        public bool IsOwnerPaymentPastDueText { get; set; }
        public bool IsOwnerPaymentPastDuePush { get; set; }


        public bool IsOwnerPaymentDiscussionEmail { get; set; }
        public bool IsOwnerPaymentDiscussionText { get; set; }
        public bool IsOwnerPaymentDiscussionPush { get; set; }

        public bool IsOwnerPaymentAddedEmail { get; set; }
        public bool IsOwnerPaymentAddedText { get; set; }
        public bool IsOwnerPaymentAddedPush { get; set; }

        public bool IsOtherEmployeeContactEmail { get; set; }
        public bool IsOtherEmployeeContactText { get; set; }

        public bool IsNewLeadEmail { get; set; }
        public bool IsNewLeadText { get; set; }
        public bool IsNewLeadPush { get; set; }

        public bool IsLeadNotifyEmail { get; set; }
        public bool IsLeadNotifyText { get; set; }
        public bool IsLeadNotifyPush { get; set; }
        public bool IsActivityRemainderEmail { get; set; }
        public bool IsActivityRemainderText { get; set; }
        public bool IsActivityRemainderPush { get; set; }
        public bool IsActivityRemainderAllUsers { get; set; }

        public bool IsEmailQuotesAlertEmail { get; set; }
        public bool IsEmailQuotesAlertText { get; set; }
        public bool IsAssignedToLeadActivityEmail { get; set; }
        public bool IsAssignedToLeadActivityText { get; set; }
        public bool IsAssignedToLeadActivityPush { get; set; }

        public bool IsLeadProposalAcceptedEmail { get; set; }
        public bool IsLeadProposalAcceptedText { get; set; }
        public bool IsLeadProposalAcceptedPush { get; set; }
        public bool IsLeadProposalAcceptedAllUsers { get; set; }

        public bool IsLeadProposalViewedEmail { get; set; }
        public bool IsLeadProposalViewedText { get; set; }
        public bool IsLeadProposalViewedPush { get; set; }


        public bool IsLinkedClickedByLeadEmail { get; set; }
        public bool IsLinkedClickedByLeadText { get; set; }

        public bool IsToDoCompletedEmail { get; set; }
        public bool IsToDoCompletedText { get; set; }
        public bool IsToDoCompletedPush { get; set; }
        public bool IsToDoDiscussionAddedEmail { get; set; }
        public bool IsToDoDiscussionAddedText { get; set; }
        public bool IsToDoDiscussionAddedPush { get; set; }

        public bool IsDailyLogNotificationEmail { get; set; }
        public bool IsDailyLogNotificationText { get; set; }
        public bool IsDailyLogNotificationPush { get; set; }
        public bool IsDailyLogDiscussionAddedEmail { get; set; }
        public bool IsDailyLogNotificationAddedText { get; set; }
        public bool IsDailyLogNotificationAddedPush { get; set; }

        public bool IsBidSubmittedEmail { get; set; }
        public bool IsBidSubmittedText { get; set; }
        public bool IsBidSubmittedPush { get; set; }
        public bool IsSubConfirmationEmail { get; set; }
        public bool IsSubConfirmationText { get; set; }
        public bool IsSubConfirmationPush { get; set; }
        public bool IsBidResubmittedEmail { get; set; }
        public bool IsBidResubmittedText { get; set; }
        public bool IsBidResubmittedPush { get; set; }
        public bool IsBidDiscussionAddedEmail { get; set; }
        public bool IsBidDiscussionAddedText { get; set; }
        public bool IsBidDiscussionAddedPush { get; set; }
        public bool IsBidAcceptedBuilderEmail { get; set; }
        public bool IsBidAcceptedBuilderText { get; set; }
        public bool IsBidAcceptedBuilderPush { get; set; }


        public bool IsUserNeedToConfirmChangeEmail { get; set; }
        public bool IsUserNeedToConfirmChangeText { get; set; }
        public bool IsUserNeedToConfirmChangePush { get; set; }
        public bool IsUserConfirmedChangeEmail { get; set; }
        public bool IsUserConfirmedChangeText { get; set; }
        public bool IsUserConfirmedChangePush { get; set; }
        public bool IsUserDeclinedChangeEmail { get; set; }
        public bool IsUserDeclinedChangeText { get; set; }
        public bool IsUserDeclinedChangePush { get; set; }
        public bool IsScheduleItemDiscussionEmail { get; set; }
        public bool IsScheduleItemDiscussionText { get; set; }
        public bool IsScheduleItemDiscussionPush { get; set; }
        public bool IsScheduleItemDiscussionAllUsers { get; set; }

        public bool IsDocumentCommentaddedEmail { get; set; }
        public bool IsDocumentCommentaddedText { get; set; }
        public bool IsDocumentCommentaddedPush { get; set; }
        public bool IsSubAndOwnerUploadedEmail { get; set; }
        public bool IsSubAndOwnerUploadedText { get; set; }
        public bool IsSubAndOwnerUploadedPush { get; set; }
        public bool IsSignatureRequestSignedEmail { get; set; }
        public bool IsSignatureRequestSignedPush { get; set; }
        public bool IsSignatureRequestPastDueEmail { get; set; }
        public bool IsSignatureRequestPastDuePush { get; set; }

        public bool IsVideoCommentAddedEmail { get; set; }
        public bool IsVideoCommentAddedText { get; set; }
        public bool IsVideoCommentAddedPush { get; set; }
        public bool IsPhotoCommentAddedEmail { get; set; }
        public bool IsPhotoCommentAddedText { get; set; }
        public bool IsPhotoCommentAddedPush { get; set; }

        public bool IsNewMessageEmail { get; set; }
        public bool IsNewMessageText { get; set; }
        public bool IsNewMessagePush { get; set; }
        public bool IsNewMessageAllUsers { get; set; }

        public bool IsRFIAddedByBuilderEmail { get; set; }
        public bool IsRFIAddedByBuilderText { get; set; }
        public bool IsRFIAddedByBuilderPush { get; set; }
        public bool IsRFIResponseAddedEmail { get; set; }
        public bool IsRFIResponseAddedText { get; set; }
        public bool IsRFIResponseAddedPush { get; set; }
        public bool IsRFIAddedEmail { get; set; }
        public bool IsRFIAddedText { get; set; }
        public bool IsRFIAddedPush { get; set; }
        public bool IsRFICompletedEmail { get; set; }
        public bool IsRFICompletedText { get; set; }
        public bool IsRFICompletedPush { get; set; }
        public bool IsRFIPastDueEmail { get; set; }
        public bool IsRFIPastDueText { get; set; }


        public bool IsChangeOrderapprovedEmail { get; set; }
        public bool IsChangeOrderapprovedText { get; set; }
        public bool IsChangeOrderapprovedPush { get; set; }
        public bool IsChangeOrderaddedEmail { get; set; }
        public bool IsChangeOrderaddedText { get; set; }
        public bool IsChangeOrderaddedPush { get; set; }
        public bool IsChangeOrderfilesaddedEmail { get; set; }
        public bool IsChangeOrderfilesaddedText { get; set; }
        public bool IsChangeOrderfilesaddedPush { get; set; }
        public bool IsChangeOrderDiscussionaddedEmail { get; set; }
        public bool IsChangeOrderDiscussionaddedText { get; set; }
        public bool IsChangeOrderDiscussionaddedPush { get; set; }
        public bool IsChangeOrderDiscussionaddedAllUsers { get; set; }
        public bool IsChangeOrderApprovedInternallyEmail { get; set; }
        public bool IsChangeOrderApprovedInternallyText { get; set; }
        public bool IsChangeOrderApprovedInternallyPush { get; set; }
        public bool IsOwnerRequestedChangeOrderEmail { get; set; }
        public bool IsOwnerRequestedChangeOrderText { get; set; }
        public bool IsOwnerRequestedChangeOrderPush { get; set; }
        public bool IsChangeOrderPastDueEmail { get; set; }
        public bool IsChangeOrderPastDueText { get; set; }

        public bool IsSelectionApprovedEmail { get; set; }
        public bool IsSelectionApprovedText { get; set; }
        public bool IsSelectionApprovedPush { get; set; }
        public bool IsSelectionDeadlineReminderEmail { get; set; }
        public bool IsSelectionDeadlineReminderPush { get; set; }
        public bool IsSelectionDiscussionAddedEmail { get; set; }
        public bool IsSelectionDiscussionAddedText { get; set; }
        public bool IsSelectionDiscussionAddedPush { get; set; }
        public bool IsSelectionChoiceAddedEmail { get; set; }
        public bool IsSelectionChoiceAddedText { get; set; }
        public bool IsSelectionChoiceAddedPush { get; set; }
        public bool IsSelectionOwnerPriceEmail { get; set; }
        public bool IsSelectionOwnerPriceText { get; set; }
        public bool IsSelectionOwnerPricePush { get; set; }
        public bool IsSelectionApprovedInternallyEmail { get; set; }
        public bool IsSelectionApprovedInternallyText { get; set; }
        public bool IsSelectionApprovedInternallyPush { get; set; }
        public bool IsSelectionSubPriceEmail { get; set; }
        public bool IsSelectionSubPriceText { get; set; }
        public bool IsSelectionSubPricePush { get; set; }

        public bool IsPOApprovedEmail { get; set; }
        public bool IsPOApprovedText { get; set; }
        public bool IsPOApprovedPush { get; set; }
        public bool IsPOPaymentMarkedEmail { get; set; }
        public bool IsLienWaiverAcceptedEmail { get; set; }
        public bool IsLienWaiverAcceptedText { get; set; }
        public bool IsLienWaiverDeclinedEmail { get; set; }
        public bool IsLienWaiverDeclinedText { get; set; }
        public bool IsPOApprovedInternallyEmail { get; set; }
        public bool IsPOApprovedInternallyText { get; set; }
        public bool IsPOApprovedInternallyPush { get; set; }
        public bool IsPODeclinedEmail { get; set; }
        public bool IsPODeclinedText { get; set; }
        public bool IsPODeclinedPush { get; set; }
        public bool IsPOAssignedInternallyEmail { get; set; }
        public bool IsPOAssignedInternallyText { get; set; }
        public bool IsPOInspectionEmail { get; set; }
        public bool IsPOInspectionPush { get; set; }
        public bool IsPOWorkcompletedEmail { get; set; }
        public bool IsPOPaymentMadeEmail { get; set; }
        public bool IsPODiscussionAddedEmail { get; set; }
        public bool IsPODiscussionAddedText { get; set; }
        public bool IsPODiscussionAddedPush { get; set; }
        public bool IsPOFileAddedEmail { get; set; }
        public bool IsPOInspectionReminderEmail { get; set; }
        public bool IsPOInspectionReminderText { get; set; }
        public bool IsPOInspectionReminderPush { get; set; }
        public bool IsPOWorkCompleteEmail { get; set; }
        public bool IsPOWorkCompleteText { get; set; }
        public bool IsPOWorkCompletePush { get; set; }
        public bool IsBillPaymentReminderEmail { get; set; }

        public bool IsWarrantyAddedEmail { get; set; }
        public bool IsWarrantyAddedText { get; set; }
        public bool IsWarrantyAddedPush { get; set; }
        public bool IsWarrantyFollowUpEmail { get; set; }
        public bool IsWarrantyFollowUpText { get; set; }
        public bool IsWarrantyFollowUpAllUsers { get; set; }
        public bool IsWarrantyUpdatedEmail { get; set; }
        public bool IsWarrantyUpdatedText { get; set; }
        public bool IsWarrantyHasFeedbackEmail { get; set; }
        public bool IsWarrantyUpdatedApptEmail { get; set; }
        public bool IsWarrantyUpdatedApptText { get; set; }
        public bool IsWarrantyScheduleChangedEmail { get; set; }
        public bool IsWarrantyScheduleChangedText { get; set; }
        public bool IsWarrantyAddedInternallyEmail { get; set; }
        public bool IsWarrantyAddedInternallyText { get; set; }
        public bool IsWarrantyAddedInternallyPush { get; set; }
        public bool IsWarrantyDiscussionAddedEmail { get; set; }
        public bool IsWarrantyDiscussionAddedText { get; set; }
        public bool IsWarrantyDiscussionAddedPush { get; set; }
        public bool IsWarrantyDiscussionAddedAllUsers { get; set; }
        public bool IsWarrantyServiceInternallyAssignedEmail { get; set; }
        public bool IsWarrantyServiceInternallyAssignedText { get; set; }



        public bool IsTimeSheetAdjustmentEmail { get; set; }
        public bool IsTimeSheetAdjustmentText { get; set; }
        public bool IsTimeSheetAdjustmentPush { get; set; }
        public bool IsTimeSheetAdjustmentAllUsers { get; set; }
        public bool IsOverTimeReachedEmail { get; set; }
        public bool IsOverTimeReachedText { get; set; }
        public bool IsOverTimeReachedPush { get; set; }
        public bool IsOverTimeReachedAllUsers { get; set; }


        public bool IsEstimateAcceptedEmail { get; set; }
        public bool IsEstimateAcceptedText { get; set; }
        public bool IsEstimateViewedEmail { get; set; }
        public bool IsEstimateViewedText { get; set; }


        public bool IsOwnerSumittedSurveyEmail { get; set; }
        public bool IsOwnerSumittedSurveyText { get; set; }

        public bool IsSubInsuranceRemiderEmail { get; set; }
        public bool IsSubActivatedEmail { get; set; }
        public bool IsTradeAgreementActionTakenEmail { get; set; }

    }
}
