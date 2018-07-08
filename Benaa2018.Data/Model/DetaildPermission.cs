using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Detaild_Permission")]
   public  class DetaildPermission : BaseModel
    {
        [Key]
        public int Detaild_Permission_Id { get; set; }

        public int User_ID { get; set; }


        
        public bool Is_View_All { get; set; }
        public bool Is_Add_All { get; set; }
        public bool Is_Edit_all { get; set; }
        public bool Is_Delete_All { get; set; }

        public bool Is_Job_Info_View { get; set; }
        public bool Is_Job_Info_Add { get; set; }
        public bool Is_Job_Info_Edit { get; set; }
        public bool Is_Job_Info_delete { get; set; }
        public bool Is_View_Owner_Site { get; set; }
        public bool Is_Price_Viewing { get; set; }



        public bool Is_Owner_Payments_View { get; set; }
        public bool Is_Owner_Payments_Add { get; set; }
        public bool Is_Owner_Payments_Edit { get; set; }
        public bool Is_Owner_Payments_Delete { get; set; }


        public bool Is_Leads_View { get; set; }
        public bool Is_Leads_Add { get; set; }
        public bool Is_Leads_Edit { get; set; }
        public bool Is_Leads_Delete { get; set; }

        public bool Is_Leads_Assign_Salesperson { get; set; }
        public bool Is_Leads_View_Other_Salesperson { get; set; }
        public bool Is_Leads_Convert_To_Jobsite { get; set; }
        public bool Is_Leads_Export_To_Excel { get; set; }

        public bool Is_Customer_Contacts_View_ReadOnly { get; set; }
        public bool Is_Customer_Contacts_View { get; set; }
        public bool Is_Customer_Contacts_Add_ReadOnly { get; set; }
        public bool Is_Customer_Contacts_Add { get; set; }
        public bool Is_Customer_Contacts_Edit { get; set; }
        public bool Is_Customer_Contacts_Delete { get; set; }

        public bool Is_View_All_Customer_Contacts_Readonly { get; set; }
        public bool Is_View_All_Customer_Contacts { get; set; }
        public bool Is_Customer_Contacts_Export_To_Excel { get; set; }

        public bool Is_To_Do_View { get; set; }
        public bool Is_To_Do_Add { get; set; }
        public bool Is_To_Do_Edit { get; set; }
        public bool Is_To_Do_Delete { get; set; }
        public bool Is_To_Do_Assign_Users { get; set; }
        public bool Is_To_Do_Global { get; set; }

        public bool Is_Logs_View { get; set; }
        public bool Is_Logs_Add { get; set; }
        public bool Is_Logs_Edit { get; set; }
        public bool Is_Logs_Delete { get; set; }

        public bool Is_Bids_View { get; set; }
        public bool Is_Bids_Add { get; set; }
        public bool Is_Bids_Edit { get; set; }
        public bool Is_Bids_Delete { get; set; }

        public bool Is_Calendar_View { get; set; }
        public bool Is_Calendar_Add { get; set; }
        public bool Is_Calendar_Edit { get; set; }
        public bool Is_Calendar_Delete { get; set; }
        public bool Is_Set_Baseline { get; set; }

        public bool Is_Documents_View { get; set; }
        public bool Is_Documents_Add { get; set; }
        public bool Is_Documents_Edit { get; set; }
        public bool Is_Documents_Delete { get; set; }

        public bool Is_Documents_Access_SubOwner { get; set; }
        public bool Is_Documents_Signature { get; set; }

        public bool Is_Videos_View { get; set; }
        public bool Is_Videos_Add { get; set; }
        public bool Is_Videos_Edit { get; set; }
        public bool Is_Videos_Delete { get; set; }

        public bool Is_Photos_View { get; set; }
        public bool Is_Photos_Add { get; set; }
        public bool Is_Photos_Edit { get; set; }
        public bool Is_Photos_Delete { get; set; }

        public bool Is_Messages_View { get; set; }
        public bool Is_Messages_Add { get; set; }
        public bool Is_Messages_Add_Readonly { get; set; }
        public bool Is_Messages_Edit { get; set; }
        public bool Is_Messages_Edit_Readonly { get; set; }
        public bool Is_Messages_Delete { get; set; }
        public bool Is_Message_Global { get; set; }

        public bool Is_RFI_View { get; set; }
        public bool Is_RFI_Add { get; set; }
        public bool Is_RFI_Edit { get; set; }
        public bool Is_RFI__Delete { get; set; }

        public bool Is_Change_Orders_View { get; set; }
        public bool Is_Change_Orders_Add { get; set; }
        public bool Is_Change_Orders_Edit { get; set; }
        public bool Is_Change_Orders_Delete { get; set; }
        public bool Is_Change_Orders_Cost_Viewing { get; set; }

        public bool Is_Selections_View { get; set; }
        public bool Is_Selections_Add { get; set; }
        public bool Is_Selections_Edit { get; set; }
        public bool Is_Selections_Delete { get; set; }
        public bool Is_Selections_Cost_Viewing { get; set; }

        public bool Is_Bill_View { get; set; }
        public bool Is_Bill_Add { get; set; }
        public bool Is_Bill_Edit { get; set; }
        public bool Is_Bill_Delete { get; set; }
        public bool Is_Bill_Accounting { get; set; }
        public bool Is_Bill_No_Price_Limit { get; set; }
        public bool Is_Bill_Cost_Viewing { get; set; }

        public bool Is_Warranty_View { get; set; }
        public bool Is_Warranty_Add { get; set; }
        public bool Is_Warranty_Edit { get; set; }
        public bool Is_Warranty_Delete { get; set; }

        public bool Is_Time_Clock_View { get; set; }
        public bool Is_Time_Clock_Add { get; set; }
        public bool Is_Time_Clock_Edit { get; set; }
        public bool Is_Time_Clock_Delete { get; set; }
        public bool Is_Time_Clock_View_Other_User { get; set; }
        public bool Is_Time_Clock_Adjust_Other_User { get; set; }
        public bool Is_Time_Clock_Cost_Viewing { get; set; }
        public bool Is_Time_Clock_Review_And_Approve { get; set; }

        public bool Is_Estimate_GI_View { get; set; }
        public bool Is_Estimate_GI_Add { get; set; }
        public bool Is_Estimate_GI_Edit { get; set; }
        public bool Is_Estimate_GI_Delete { get; set; }
        public bool Is_Estimate_GI_Price_Viewing { get; set; }

        public bool Is_Survey_View { get; set; }
        public bool Is_Survey_Add { get; set; }
        public bool Is_Survey_Edit { get; set; }
        public bool Is_Survey_Delete { get; set; }
        public bool Is_Survey_Add_Review_Website { get; set; }

        public bool Is_Subs_View { get; set; }
        public bool Is_Subs_Add { get; set; }
        public bool Is_Subs_Edit { get; set; }
        public bool Is_Subs_Delete { get; set; }

        public bool Is_Admin_View { get; set; }
        public bool Is_Admin_View_Readonly { get; set; }
        public bool Is_Admin_Add { get; set; }
        public bool Is_Admin_Add_Readonly { get; set; }
        public bool Is_Admin_Edit { get; set; }
        public bool Is_Admin_Edit_Readonly { get; set; }
        public bool Is_Admin_Delete { get; set; }
        public bool Is_Admin_Delete_Readonly { get; set; }

        public int Import_Notification_Id { get; set; }
        public bool Is_Email_All { get; set; }
        public bool Is_Text_All { get; set; }
        public bool Is_Push_On { get; set; }
        public bool Is_All_Users { get; set; }

        public bool Is_Owner_Activated_Email { get; set; }

        public bool Is_Owner_Payment_Updated_Email { get; set; }
        public bool Is_Owner_Payment_Updated_Text { get; set; }
        public bool Is_Owner_Payment_Updated_Push { get; set; }

        public bool Is_Owner_Payment_Reminder_Email { get; set; }
        public bool Is_Owner_Payment_Reminder_Text { get; set; }
        public bool Is_Owner_Payment_Reminder_Push { get; set; }


        public bool Is_Owner_Payment_Past_Due_Email { get; set; }
        public bool Is_Owner_Payment_Past_Due_Text { get; set; }
        public bool Is_Owner_Payment_Past_Due_Push { get; set; }


        public bool Is_Owner_Payment_Discussion_Email { get; set; }
        public bool Is_Owner_Payment_Discussion_Text { get; set; }
        public bool Is_Owner_Payment_Discussion_Push { get; set; }

        public bool Is_Owner_Payment_Added_Email { get; set; }
        public bool Is_Owner_Payment_Added_Text { get; set; }
        public bool Is_Owner_Payment_Added_Push { get; set; }

        public bool Is_Other_Employee_Contact_Email { get; set; }
        public bool Is_Other_Employee_Contact_Text { get; set; }

        public bool Is_New_Lead_Email { get; set; }
        public bool Is_New_Lead_Text { get; set; }
        public bool Is_New_Lead_Push { get; set; }

        public bool Is_Lead_Notify_Email { get; set; }
        public bool Is_Lead_Notify_Text { get; set; }
        public bool Is_Lead_Notify_Push { get; set; }
        public bool Is_Activity_Remainder_Email { get; set; }
        public bool Is_Activity_Remainder_Text { get; set; }
        public bool Is_Activity_Remainder_Push { get; set; }
        public bool Is_Activity_Remainder_All_Users { get; set; }

        public bool Is_Email_Quotes_Alert_Email { get; set; }
        public bool Is_Email_Quotes_Alert_Text { get; set; }
        public bool Is_Assigned_To_Lead_Activity_Email { get; set; }
        public bool Is_Assigned_To_Lead_Activity_Text { get; set; }
        public bool Is_Assigned_To_Lead_Activity_Push { get; set; }

        public bool Is_Lead_Proposal_Accepted_Email { get; set; }
        public bool Is_Lead_Proposal_Accepted_Text { get; set; }
        public bool Is_Lead_Proposal_Accepted_Push { get; set; }
        public bool Is_Lead_Proposal_Accepted_All_Users { get; set; }

        public bool Is_Lead_Proposal_Viewed_Email { get; set; }
        public bool Is_Lead_Proposal_Viewed_Text { get; set; }
        public bool Is_Lead_Proposal_Viewed_Push { get; set; }


        public bool Is_Linked_Clicked_By_Lead_Email { get; set; }
        public bool Is_Linked_Clicked_By_Lead_Text { get; set; }

        public bool Is_To_Do_Completed_Email { get; set; }
        public bool Is_To_Do_Completed_Text { get; set; }
        public bool Is_To_Do_Completed_Push { get; set; }
        public bool Is_To_Do_Discussion_Added_Email { get; set; }
        public bool Is_To_Do_Discussion_Added_Text { get; set; }
        public bool Is_To_Do_Discussion_Added_Push { get; set; }

        public bool Is_Daily_Log_Notification_Email { get; set; }
        public bool Is_Daily_Log_Notification_Text { get; set; }
        public bool Is_Daily_Log_Notification_Push { get; set; }
        public bool Is_Daily_Log_Discussion_Added_Email { get; set; }
        public bool Is_Daily_Log_Notification_Added_Text { get; set; }
        public bool Is_Daily_Log_Notification_Added_Push { get; set; }

        public bool Is_Bid_Submitted_Email { get; set; }
        public bool Is_Bid_Submitted_Text { get; set; }
        public bool Is_Bid_Submitted_Push { get; set; }
        public bool Is_Sub_Confirmation_Email { get; set; }
        public bool Is_Sub_Confirmation_Text { get; set; }
        public bool Is_Sub_Confirmation_Push { get; set; }
        public bool Is_Bid_Resubmitted_Email { get; set; }
        public bool Is_Bid_Resubmitted_Text { get; set; }
        public bool Is_Bid_Resubmitted_Push { get; set; }
        public bool Is_Bid_Discussion_Added_Email { get; set; }
        public bool Is_Bid_Discussion_Added_Text { get; set; }
        public bool Is_Bid_Discussion_Added_Push { get; set; }
        public bool Is_Bid_Accepted_Builder_Email { get; set; }
        public bool Is_Bid_Accepted_Builder_Text { get; set; }
        public bool Is_Bid_Accepted_Builder_Push { get; set; }


        public bool Is_User_Need_To_Confirm_Change_Email { get; set; }
        public bool Is_User_Need_To_Confirm_Change_Text { get; set; }
        public bool Is_User_Need_To_Confirm_Change_Push { get; set; }
        public bool Is_User_Confirmed_Change_Email { get; set; }
        public bool Is_User_Confirmed_Change_Text { get; set; }
        public bool Is_User_Confirmed_Change_Push { get; set; }
        public bool Is_User_Declined_Change_Email { get; set; }
        public bool Is_User_Declined_Change_Text { get; set; }
        public bool Is_User_Declined_Change_Push { get; set; }
        public bool Is_Schedule_Item_Discussion_Email { get; set; }
        public bool Is_Schedule_Item_Discussion_Text { get; set; }
        public bool Is_Schedule_Item_Discussion_Push { get; set; }
        public bool Is_Schedule_Item_Discussion_All_Users { get; set; }

        public bool Is_Document_Comment_added_Email { get; set; }
        public bool Is_Document_Comment_added_Text { get; set; }
        public bool Is_Document_Comment_added_Push { get; set; }
        public bool Is_Sub_And_Owner_Uploaded_Email { get; set; }
        public bool Is_Sub_And_Owner_Uploaded_Text { get; set; }
        public bool Is_Sub_And_Owner_Uploaded_Push { get; set; }
        public bool Is_Signature_Request_Signed_Email { get; set; }
        public bool Is_Signature_Request_Signed_Push { get; set; }
        public bool Is_Signature_Request_Past_Due_Email { get; set; }
        public bool Is_Signature_Request_Past_Due_Push { get; set; }

        public bool Is_Video_Comment_Added_Email { get; set; }
        public bool Is_Video_Comment_Added_Text { get; set; }
        public bool Is_Video_Comment_Added_Push { get; set; }
        public bool Is_Photo_Comment_Added_Email { get; set; }
        public bool Is_Photo_Comment_Added_Text { get; set; }
        public bool Is_Photo_Comment_Added_Push { get; set; }

        public bool Is_New_Message_Email { get; set; }
        public bool Is_New_Message_Text { get; set; }
        public bool Is_New_Message_Push { get; set; }
        public bool Is_New_Message_All_Users { get; set; }

        public bool Is_RFI_Added_By_Builder_Email { get; set; }
        public bool Is_RFI_Added_By_Builder_Text { get; set; }
        public bool Is_RFI_Added_By_Builder_Push { get; set; }
        public bool Is_RFI_Response_Added_Email { get; set; }
        public bool Is_RFI_Response_Added_Text { get; set; }
        public bool Is_RFI_Response_Added_Push { get; set; }
        public bool Is_RFI_Added_Email { get; set; }
        public bool Is_RFI_Added_Text { get; set; }
        public bool Is_RFI_Added_Push { get; set; }
        public bool Is_RFI_Completed_Email { get; set; }
        public bool Is_RFI_Completed_Text { get; set; }
        public bool Is_RFI_Completed_Push { get; set; }
        public bool Is_RFI_Past_Due_Email { get; set; }
        public bool Is_RFI_Past_Due_Text { get; set; }


        public bool Is_Change_Order_approved_Email { get; set; }
        public bool Is_Change_Order_approved_Text { get; set; }
        public bool Is_Change_Order_approved_Push { get; set; }
        public bool Is_Change_Order_added_Email { get; set; }
        public bool Is_Change_Order_added_Text { get; set; }
        public bool Is_Change_Order_added_Push { get; set; }
        public bool Is_Change_Order_files_added_Email { get; set; }
        public bool Is_Change_Order_files_added_Text { get; set; }
        public bool Is_Change_Order_files_added_Push { get; set; }
        public bool Is_Change_Order_Discussion_added_Email { get; set; }
        public bool Is_Change_Order_Discussion_added_Text { get; set; }
        public bool Is_Change_Order_Discussion_added_Push { get; set; }
        public bool Is_Change_Order_Discussion_added_All_Users { get; set; }
        public bool Is_Change_Order_Approved_Internally_Email { get; set; }
        public bool Is_Change_Order_Approved_Internally_Text { get; set; }
        public bool Is_Change_Order_Approved_Internally_Push { get; set; }
        public bool Is_Owner_Requested_Change_Order_Email { get; set; }
        public bool Is_Owner_Requested_Change_Order_Text { get; set; }
        public bool Is_Owner_Requested_Change_Order_Push { get; set; }
        public bool Is_Change_Order_Past_Due_Email { get; set; }
        public bool Is_Change_Order_Past_Due_Text { get; set; }

        public bool Is_Selection_Approved_Email { get; set; }
        public bool Is_Selection_Approved_Text { get; set; }
        public bool Is_Selection_Approved_Push { get; set; }
        public bool Is_Selection_Deadline_Reminder_Email { get; set; }
        public bool Is_Selection_Deadline_Reminder_Push { get; set; }
        public bool Is_Selection_Discussion_Added_Email { get; set; }
        public bool Is_Selection_Discussion_Added_Text { get; set; }
        public bool Is_Selection_Discussion_Added_Push { get; set; }
        public bool Is_Selection_Choice_Added_Email { get; set; }
        public bool Is_Selection_Choice_Added_Text { get; set; }
        public bool Is_Selection_Choice_Added_Push { get; set; }
        public bool Is_Selection_Owner_Price_Email { get; set; }
        public bool Is_Selection_Owner_Price_Text { get; set; }
        public bool Is_Selection_Owner_Price_Push { get; set; }
        public bool Is_Selection_Approved_Internally_Email { get; set; }
        public bool Is_Selection_Approved_Internally_Text { get; set; }
        public bool Is_Selection_Approved_Internally_Push { get; set; }
        public bool Is_Selection_Sub_Price_Email { get; set; }
        public bool Is_Selection_Sub_Price_Text { get; set; }
        public bool Is_Selection_Sub_Price_Push { get; set; }

        public bool Is_PO_Approved_Email { get; set; }
        public bool Is_PO_Approved_Text { get; set; }
        public bool Is_PO_Approved_Push { get; set; }
        public bool Is_PO_Payment_Marked_Email { get; set; }
        public bool Is_Lien_Waiver_Accepted_Email { get; set; }
        public bool Is_Lien_Waiver_Accepted_Text { get; set; }
        public bool Is_Lien_Waiver_Declined_Email { get; set; }
        public bool Is_Lien_Waiver_Declined_Text { get; set; }
        public bool Is_PO_Approved_Internally_Email { get; set; }
        public bool Is_PO_Approved_Internally_Text { get; set; }
        public bool Is_PO_Approved_Internally_Push { get; set; }
        public bool Is_PO_Declined_Email { get; set; }
        public bool Is_PO_Declined_Text { get; set; }
        public bool Is_PO_Declined_Push { get; set; }
        public bool Is_PO_Assigned_Internally_Email { get; set; }
        public bool Is_PO_Assigned_Internally_Text { get; set; }
        public bool Is_PO_Inspection_Email { get; set; }
        public bool Is_PO_Inspection_Push { get; set; }
        public bool Is_PO_Work_completed_Email { get; set; }
        public bool Is_PO_Payment_Made_Email { get; set; }
        public bool Is_PO_Discussion_Added_Email { get; set; }
        public bool Is_PO_Discussion_Added_Text { get; set; }
        public bool Is_PO_Discussion_Added_Push { get; set; }
        public bool Is_PO_File_Added_Email { get; set; }
        public bool Is_PO_Inspection_Reminder_Email { get; set; }
        public bool Is_PO_Inspection_Reminder_Text { get; set; }
        public bool Is_PO_Inspection_Reminder_Push { get; set; }
        public bool Is_PO_Work_Complete_Email { get; set; }
        public bool Is_PO_Work_Complete_Text { get; set; }
        public bool Is_PO_Work_Complete_Push { get; set; }
        public bool Is_Bill_Payment_Reminder_Email { get; set; }

        public bool Is_Warranty_Added_Email { get; set; }
        public bool Is_Warranty_Added_Text { get; set; }
        public bool Is_Warranty_Added_Push { get; set; }
        public bool Is_Warranty_Follow_Up_Email { get; set; }
        public bool Is_Warranty_Follow_Up_Text { get; set; }
        public bool Is_Warranty_Follow_Up_All_Users { get; set; }
        public bool Is_Warranty_Updated_Email { get; set; }
        public bool Is_Warranty_Updated_Text { get; set; }
        public bool Is_Warranty_Has_Feedback_Email { get; set; }
        public bool Is_Warranty_Updated_Appt_Email { get; set; }
        public bool Is_Warranty_Updated_Appt_Text { get; set; }
        public bool Is_Warranty_Schedule_Changed_Email { get; set; }
        public bool Is_Warranty_Schedule_Changed_Text { get; set; }
        public bool Is_Warranty_Added_Internally_Email { get; set; }
        public bool Is_Warranty_Added_Internally_Text { get; set; }
        public bool Is_Warranty_Added_Internally_Push { get; set; }
        public bool Is_Warranty_Discussion_Added_Email { get; set; }
        public bool Is_Warranty_Discussion_Added_Text { get; set; }
        public bool Is_Warranty_Discussion_Added_Push { get; set; }
        public bool Is_Warranty_Discussion_Added_All_Users { get; set; }
        public bool Is_Warranty_Service_Internally_Assigned_Email { get; set; }
        public bool Is_Warranty_Service_Internally_Assigned_Text { get; set; }



        public bool Is_Time_Sheet_Adjustment_Email { get; set; }
        public bool Is_Time_Sheet_Adjustment_Text { get; set; }
        public bool Is_Time_Sheet_Adjustment_Push { get; set; }
        public bool Is_Time_Sheet_Adjustment_All_Users { get; set; }
        public bool Is_Over_Time_Reached_Email { get; set; }
        public bool Is_Over_Time_Reached_Text { get; set; }
        public bool Is_Over_Time_Reached_Push { get; set; }
        public bool Is_Over_Time_Reached_All_Users { get; set; }


        public bool Is_Estimate_Accepted_Email { get; set; }
        public bool Is_Estimate_Accepted_Text { get; set; }
        public bool Is_Estimate_Viewed_Email { get; set; }
        public bool Is_Estimate_Viewed_Text { get; set; }


        public bool Is_Owner_Sumitted_Survey_Email { get; set; }
        public bool Is_Owner_Sumitted_Survey_Text { get; set; }

        public bool Is_Sub_Insurance_Remider_Email { get; set; }
        public bool Is_Sub_Activated_Email { get; set; }
        public bool Is_Trade_Agreement_Action_Taken_Email { get; set; }


    }
}
