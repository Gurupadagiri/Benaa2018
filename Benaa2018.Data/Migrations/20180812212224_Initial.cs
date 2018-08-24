using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Benaa2018.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendar_Phase",
                columns: table => new
                {
                    PhaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    PhaseName = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar_Phase", x => x.PhaseId);
                });

            migrationBuilder.CreateTable(
                name: "Calendar_Scheduled_Item",
                columns: table => new
                {
                    ScheduledItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedTo = table.Column<string>(nullable: true),
                    ColorCode = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<string>(nullable: true),
                    Hourly = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Reminder = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar_Scheduled_Item", x => x.ScheduledItemId);
                });

            migrationBuilder.CreateTable(
                name: "Calendar_Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    TagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Company_Master",
                columns: table => new
                {
                    Org_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company_Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Master", x => x.Org_ID);
                });

            migrationBuilder.CreateTable(
                name: "Detaild_Permission",
                columns: table => new
                {
                    Detaild_Permission_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Import_Notification_Id = table.Column<int>(nullable: false),
                    Is_Activity_Remainder_All_Users = table.Column<bool>(nullable: false),
                    Is_Activity_Remainder_Email = table.Column<bool>(nullable: false),
                    Is_Activity_Remainder_Push = table.Column<bool>(nullable: false),
                    Is_Activity_Remainder_Text = table.Column<bool>(nullable: false),
                    Is_Add_All = table.Column<bool>(nullable: false),
                    Is_Admin_Add = table.Column<bool>(nullable: false),
                    Is_Admin_Add_Readonly = table.Column<bool>(nullable: false),
                    Is_Admin_Delete = table.Column<bool>(nullable: false),
                    Is_Admin_Delete_Readonly = table.Column<bool>(nullable: false),
                    Is_Admin_Edit = table.Column<bool>(nullable: false),
                    Is_Admin_Edit_Readonly = table.Column<bool>(nullable: false),
                    Is_Admin_View = table.Column<bool>(nullable: false),
                    Is_Admin_View_Readonly = table.Column<bool>(nullable: false),
                    Is_All_Users = table.Column<bool>(nullable: false),
                    Is_Assigned_To_Lead_Activity_Email = table.Column<bool>(nullable: false),
                    Is_Assigned_To_Lead_Activity_Push = table.Column<bool>(nullable: false),
                    Is_Assigned_To_Lead_Activity_Text = table.Column<bool>(nullable: false),
                    Is_Bid_Accepted_Builder_Email = table.Column<bool>(nullable: false),
                    Is_Bid_Accepted_Builder_Push = table.Column<bool>(nullable: false),
                    Is_Bid_Accepted_Builder_Text = table.Column<bool>(nullable: false),
                    Is_Bid_Discussion_Added_Email = table.Column<bool>(nullable: false),
                    Is_Bid_Discussion_Added_Push = table.Column<bool>(nullable: false),
                    Is_Bid_Discussion_Added_Text = table.Column<bool>(nullable: false),
                    Is_Bid_Resubmitted_Email = table.Column<bool>(nullable: false),
                    Is_Bid_Resubmitted_Push = table.Column<bool>(nullable: false),
                    Is_Bid_Resubmitted_Text = table.Column<bool>(nullable: false),
                    Is_Bid_Submitted_Email = table.Column<bool>(nullable: false),
                    Is_Bid_Submitted_Push = table.Column<bool>(nullable: false),
                    Is_Bid_Submitted_Text = table.Column<bool>(nullable: false),
                    Is_Bids_Add = table.Column<bool>(nullable: false),
                    Is_Bids_Delete = table.Column<bool>(nullable: false),
                    Is_Bids_Edit = table.Column<bool>(nullable: false),
                    Is_Bids_View = table.Column<bool>(nullable: false),
                    Is_Bill_Accounting = table.Column<bool>(nullable: false),
                    Is_Bill_Add = table.Column<bool>(nullable: false),
                    Is_Bill_Cost_Viewing = table.Column<bool>(nullable: false),
                    Is_Bill_Delete = table.Column<bool>(nullable: false),
                    Is_Bill_Edit = table.Column<bool>(nullable: false),
                    Is_Bill_No_Price_Limit = table.Column<bool>(nullable: false),
                    Is_Bill_Payment_Reminder_Email = table.Column<bool>(nullable: false),
                    Is_Bill_View = table.Column<bool>(nullable: false),
                    Is_Calendar_Add = table.Column<bool>(nullable: false),
                    Is_Calendar_Delete = table.Column<bool>(nullable: false),
                    Is_Calendar_Edit = table.Column<bool>(nullable: false),
                    Is_Calendar_View = table.Column<bool>(nullable: false),
                    Is_Change_Order_Approved_Internally_Email = table.Column<bool>(nullable: false),
                    Is_Change_Order_Approved_Internally_Push = table.Column<bool>(nullable: false),
                    Is_Change_Order_Approved_Internally_Text = table.Column<bool>(nullable: false),
                    Is_Change_Order_Discussion_added_All_Users = table.Column<bool>(nullable: false),
                    Is_Change_Order_Discussion_added_Email = table.Column<bool>(nullable: false),
                    Is_Change_Order_Discussion_added_Push = table.Column<bool>(nullable: false),
                    Is_Change_Order_Discussion_added_Text = table.Column<bool>(nullable: false),
                    Is_Change_Order_Past_Due_Email = table.Column<bool>(nullable: false),
                    Is_Change_Order_Past_Due_Text = table.Column<bool>(nullable: false),
                    Is_Change_Order_added_Email = table.Column<bool>(nullable: false),
                    Is_Change_Order_added_Push = table.Column<bool>(nullable: false),
                    Is_Change_Order_added_Text = table.Column<bool>(nullable: false),
                    Is_Change_Order_approved_Email = table.Column<bool>(nullable: false),
                    Is_Change_Order_approved_Push = table.Column<bool>(nullable: false),
                    Is_Change_Order_approved_Text = table.Column<bool>(nullable: false),
                    Is_Change_Order_files_added_Email = table.Column<bool>(nullable: false),
                    Is_Change_Order_files_added_Push = table.Column<bool>(nullable: false),
                    Is_Change_Order_files_added_Text = table.Column<bool>(nullable: false),
                    Is_Change_Orders_Add = table.Column<bool>(nullable: false),
                    Is_Change_Orders_Cost_Viewing = table.Column<bool>(nullable: false),
                    Is_Change_Orders_Delete = table.Column<bool>(nullable: false),
                    Is_Change_Orders_Edit = table.Column<bool>(nullable: false),
                    Is_Change_Orders_View = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_Add = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_Add_ReadOnly = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_Delete = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_Edit = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_Export_To_Excel = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_View = table.Column<bool>(nullable: false),
                    Is_Customer_Contacts_View_ReadOnly = table.Column<bool>(nullable: false),
                    Is_Daily_Log_Discussion_Added_Email = table.Column<bool>(nullable: false),
                    Is_Daily_Log_Notification_Added_Push = table.Column<bool>(nullable: false),
                    Is_Daily_Log_Notification_Added_Text = table.Column<bool>(nullable: false),
                    Is_Daily_Log_Notification_Email = table.Column<bool>(nullable: false),
                    Is_Daily_Log_Notification_Push = table.Column<bool>(nullable: false),
                    Is_Daily_Log_Notification_Text = table.Column<bool>(nullable: false),
                    Is_Delete_All = table.Column<bool>(nullable: false),
                    Is_Document_Comment_added_Email = table.Column<bool>(nullable: false),
                    Is_Document_Comment_added_Push = table.Column<bool>(nullable: false),
                    Is_Document_Comment_added_Text = table.Column<bool>(nullable: false),
                    Is_Documents_Access_SubOwner = table.Column<bool>(nullable: false),
                    Is_Documents_Add = table.Column<bool>(nullable: false),
                    Is_Documents_Delete = table.Column<bool>(nullable: false),
                    Is_Documents_Edit = table.Column<bool>(nullable: false),
                    Is_Documents_Signature = table.Column<bool>(nullable: false),
                    Is_Documents_View = table.Column<bool>(nullable: false),
                    Is_Edit_all = table.Column<bool>(nullable: false),
                    Is_Email_All = table.Column<bool>(nullable: false),
                    Is_Email_Quotes_Alert_Email = table.Column<bool>(nullable: false),
                    Is_Email_Quotes_Alert_Text = table.Column<bool>(nullable: false),
                    Is_Estimate_Accepted_Email = table.Column<bool>(nullable: false),
                    Is_Estimate_Accepted_Text = table.Column<bool>(nullable: false),
                    Is_Estimate_GI_Add = table.Column<bool>(nullable: false),
                    Is_Estimate_GI_Delete = table.Column<bool>(nullable: false),
                    Is_Estimate_GI_Edit = table.Column<bool>(nullable: false),
                    Is_Estimate_GI_Price_Viewing = table.Column<bool>(nullable: false),
                    Is_Estimate_GI_View = table.Column<bool>(nullable: false),
                    Is_Estimate_Viewed_Email = table.Column<bool>(nullable: false),
                    Is_Estimate_Viewed_Text = table.Column<bool>(nullable: false),
                    Is_Job_Info_Add = table.Column<bool>(nullable: false),
                    Is_Job_Info_Edit = table.Column<bool>(nullable: false),
                    Is_Job_Info_View = table.Column<bool>(nullable: false),
                    Is_Job_Info_delete = table.Column<bool>(nullable: false),
                    Is_Lead_Notify_Email = table.Column<bool>(nullable: false),
                    Is_Lead_Notify_Push = table.Column<bool>(nullable: false),
                    Is_Lead_Notify_Text = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Accepted_All_Users = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Accepted_Email = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Accepted_Push = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Accepted_Text = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Viewed_Email = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Viewed_Push = table.Column<bool>(nullable: false),
                    Is_Lead_Proposal_Viewed_Text = table.Column<bool>(nullable: false),
                    Is_Leads_Add = table.Column<bool>(nullable: false),
                    Is_Leads_Assign_Salesperson = table.Column<bool>(nullable: false),
                    Is_Leads_Convert_To_Jobsite = table.Column<bool>(nullable: false),
                    Is_Leads_Delete = table.Column<bool>(nullable: false),
                    Is_Leads_Edit = table.Column<bool>(nullable: false),
                    Is_Leads_Export_To_Excel = table.Column<bool>(nullable: false),
                    Is_Leads_View = table.Column<bool>(nullable: false),
                    Is_Leads_View_Other_Salesperson = table.Column<bool>(nullable: false),
                    Is_Lien_Waiver_Accepted_Email = table.Column<bool>(nullable: false),
                    Is_Lien_Waiver_Accepted_Text = table.Column<bool>(nullable: false),
                    Is_Lien_Waiver_Declined_Email = table.Column<bool>(nullable: false),
                    Is_Lien_Waiver_Declined_Text = table.Column<bool>(nullable: false),
                    Is_Linked_Clicked_By_Lead_Email = table.Column<bool>(nullable: false),
                    Is_Linked_Clicked_By_Lead_Text = table.Column<bool>(nullable: false),
                    Is_Logs_Add = table.Column<bool>(nullable: false),
                    Is_Logs_Delete = table.Column<bool>(nullable: false),
                    Is_Logs_Edit = table.Column<bool>(nullable: false),
                    Is_Logs_View = table.Column<bool>(nullable: false),
                    Is_Message_Global = table.Column<bool>(nullable: false),
                    Is_Messages_Add = table.Column<bool>(nullable: false),
                    Is_Messages_Add_Readonly = table.Column<bool>(nullable: false),
                    Is_Messages_Delete = table.Column<bool>(nullable: false),
                    Is_Messages_Edit = table.Column<bool>(nullable: false),
                    Is_Messages_Edit_Readonly = table.Column<bool>(nullable: false),
                    Is_Messages_View = table.Column<bool>(nullable: false),
                    Is_New_Lead_Email = table.Column<bool>(nullable: false),
                    Is_New_Lead_Push = table.Column<bool>(nullable: false),
                    Is_New_Lead_Text = table.Column<bool>(nullable: false),
                    Is_New_Message_All_Users = table.Column<bool>(nullable: false),
                    Is_New_Message_Email = table.Column<bool>(nullable: false),
                    Is_New_Message_Push = table.Column<bool>(nullable: false),
                    Is_New_Message_Text = table.Column<bool>(nullable: false),
                    Is_Other_Employee_Contact_Email = table.Column<bool>(nullable: false),
                    Is_Other_Employee_Contact_Text = table.Column<bool>(nullable: false),
                    Is_Over_Time_Reached_All_Users = table.Column<bool>(nullable: false),
                    Is_Over_Time_Reached_Email = table.Column<bool>(nullable: false),
                    Is_Over_Time_Reached_Push = table.Column<bool>(nullable: false),
                    Is_Over_Time_Reached_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Activated_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Added_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Added_Push = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Added_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Discussion_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Discussion_Push = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Discussion_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Past_Due_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Past_Due_Push = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Past_Due_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Reminder_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Reminder_Push = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Reminder_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Updated_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Updated_Push = table.Column<bool>(nullable: false),
                    Is_Owner_Payment_Updated_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Payments_Add = table.Column<bool>(nullable: false),
                    Is_Owner_Payments_Delete = table.Column<bool>(nullable: false),
                    Is_Owner_Payments_Edit = table.Column<bool>(nullable: false),
                    Is_Owner_Payments_View = table.Column<bool>(nullable: false),
                    Is_Owner_Requested_Change_Order_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Requested_Change_Order_Push = table.Column<bool>(nullable: false),
                    Is_Owner_Requested_Change_Order_Text = table.Column<bool>(nullable: false),
                    Is_Owner_Sumitted_Survey_Email = table.Column<bool>(nullable: false),
                    Is_Owner_Sumitted_Survey_Text = table.Column<bool>(nullable: false),
                    Is_PO_Approved_Email = table.Column<bool>(nullable: false),
                    Is_PO_Approved_Internally_Email = table.Column<bool>(nullable: false),
                    Is_PO_Approved_Internally_Push = table.Column<bool>(nullable: false),
                    Is_PO_Approved_Internally_Text = table.Column<bool>(nullable: false),
                    Is_PO_Approved_Push = table.Column<bool>(nullable: false),
                    Is_PO_Approved_Text = table.Column<bool>(nullable: false),
                    Is_PO_Assigned_Internally_Email = table.Column<bool>(nullable: false),
                    Is_PO_Assigned_Internally_Text = table.Column<bool>(nullable: false),
                    Is_PO_Declined_Email = table.Column<bool>(nullable: false),
                    Is_PO_Declined_Push = table.Column<bool>(nullable: false),
                    Is_PO_Declined_Text = table.Column<bool>(nullable: false),
                    Is_PO_Discussion_Added_Email = table.Column<bool>(nullable: false),
                    Is_PO_Discussion_Added_Push = table.Column<bool>(nullable: false),
                    Is_PO_Discussion_Added_Text = table.Column<bool>(nullable: false),
                    Is_PO_File_Added_Email = table.Column<bool>(nullable: false),
                    Is_PO_Inspection_Email = table.Column<bool>(nullable: false),
                    Is_PO_Inspection_Push = table.Column<bool>(nullable: false),
                    Is_PO_Inspection_Reminder_Email = table.Column<bool>(nullable: false),
                    Is_PO_Inspection_Reminder_Push = table.Column<bool>(nullable: false),
                    Is_PO_Inspection_Reminder_Text = table.Column<bool>(nullable: false),
                    Is_PO_Payment_Made_Email = table.Column<bool>(nullable: false),
                    Is_PO_Payment_Marked_Email = table.Column<bool>(nullable: false),
                    Is_PO_Work_Complete_Email = table.Column<bool>(nullable: false),
                    Is_PO_Work_Complete_Push = table.Column<bool>(nullable: false),
                    Is_PO_Work_Complete_Text = table.Column<bool>(nullable: false),
                    Is_PO_Work_completed_Email = table.Column<bool>(nullable: false),
                    Is_Photo_Comment_Added_Email = table.Column<bool>(nullable: false),
                    Is_Photo_Comment_Added_Push = table.Column<bool>(nullable: false),
                    Is_Photo_Comment_Added_Text = table.Column<bool>(nullable: false),
                    Is_Photos_Add = table.Column<bool>(nullable: false),
                    Is_Photos_Delete = table.Column<bool>(nullable: false),
                    Is_Photos_Edit = table.Column<bool>(nullable: false),
                    Is_Photos_View = table.Column<bool>(nullable: false),
                    Is_Price_Viewing = table.Column<bool>(nullable: false),
                    Is_Push_On = table.Column<bool>(nullable: false),
                    Is_RFI_Add = table.Column<bool>(nullable: false),
                    Is_RFI_Added_By_Builder_Email = table.Column<bool>(nullable: false),
                    Is_RFI_Added_By_Builder_Push = table.Column<bool>(nullable: false),
                    Is_RFI_Added_By_Builder_Text = table.Column<bool>(nullable: false),
                    Is_RFI_Added_Email = table.Column<bool>(nullable: false),
                    Is_RFI_Added_Push = table.Column<bool>(nullable: false),
                    Is_RFI_Added_Text = table.Column<bool>(nullable: false),
                    Is_RFI_Completed_Email = table.Column<bool>(nullable: false),
                    Is_RFI_Completed_Push = table.Column<bool>(nullable: false),
                    Is_RFI_Completed_Text = table.Column<bool>(nullable: false),
                    Is_RFI_Edit = table.Column<bool>(nullable: false),
                    Is_RFI_Past_Due_Email = table.Column<bool>(nullable: false),
                    Is_RFI_Past_Due_Text = table.Column<bool>(nullable: false),
                    Is_RFI_Response_Added_Email = table.Column<bool>(nullable: false),
                    Is_RFI_Response_Added_Push = table.Column<bool>(nullable: false),
                    Is_RFI_Response_Added_Text = table.Column<bool>(nullable: false),
                    Is_RFI_View = table.Column<bool>(nullable: false),
                    Is_RFI__Delete = table.Column<bool>(nullable: false),
                    Is_Schedule_Item_Discussion_All_Users = table.Column<bool>(nullable: false),
                    Is_Schedule_Item_Discussion_Email = table.Column<bool>(nullable: false),
                    Is_Schedule_Item_Discussion_Push = table.Column<bool>(nullable: false),
                    Is_Schedule_Item_Discussion_Text = table.Column<bool>(nullable: false),
                    Is_Selection_Approved_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Approved_Internally_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Approved_Internally_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Approved_Internally_Text = table.Column<bool>(nullable: false),
                    Is_Selection_Approved_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Approved_Text = table.Column<bool>(nullable: false),
                    Is_Selection_Choice_Added_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Choice_Added_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Choice_Added_Text = table.Column<bool>(nullable: false),
                    Is_Selection_Deadline_Reminder_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Deadline_Reminder_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Discussion_Added_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Discussion_Added_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Discussion_Added_Text = table.Column<bool>(nullable: false),
                    Is_Selection_Owner_Price_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Owner_Price_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Owner_Price_Text = table.Column<bool>(nullable: false),
                    Is_Selection_Sub_Price_Email = table.Column<bool>(nullable: false),
                    Is_Selection_Sub_Price_Push = table.Column<bool>(nullable: false),
                    Is_Selection_Sub_Price_Text = table.Column<bool>(nullable: false),
                    Is_Selections_Add = table.Column<bool>(nullable: false),
                    Is_Selections_Cost_Viewing = table.Column<bool>(nullable: false),
                    Is_Selections_Delete = table.Column<bool>(nullable: false),
                    Is_Selections_Edit = table.Column<bool>(nullable: false),
                    Is_Selections_View = table.Column<bool>(nullable: false),
                    Is_Set_Baseline = table.Column<bool>(nullable: false),
                    Is_Signature_Request_Past_Due_Email = table.Column<bool>(nullable: false),
                    Is_Signature_Request_Past_Due_Push = table.Column<bool>(nullable: false),
                    Is_Signature_Request_Signed_Email = table.Column<bool>(nullable: false),
                    Is_Signature_Request_Signed_Push = table.Column<bool>(nullable: false),
                    Is_Sub_Activated_Email = table.Column<bool>(nullable: false),
                    Is_Sub_And_Owner_Uploaded_Email = table.Column<bool>(nullable: false),
                    Is_Sub_And_Owner_Uploaded_Push = table.Column<bool>(nullable: false),
                    Is_Sub_And_Owner_Uploaded_Text = table.Column<bool>(nullable: false),
                    Is_Sub_Confirmation_Email = table.Column<bool>(nullable: false),
                    Is_Sub_Confirmation_Push = table.Column<bool>(nullable: false),
                    Is_Sub_Confirmation_Text = table.Column<bool>(nullable: false),
                    Is_Sub_Insurance_Remider_Email = table.Column<bool>(nullable: false),
                    Is_Subs_Add = table.Column<bool>(nullable: false),
                    Is_Subs_Delete = table.Column<bool>(nullable: false),
                    Is_Subs_Edit = table.Column<bool>(nullable: false),
                    Is_Subs_View = table.Column<bool>(nullable: false),
                    Is_Survey_Add = table.Column<bool>(nullable: false),
                    Is_Survey_Add_Review_Website = table.Column<bool>(nullable: false),
                    Is_Survey_Delete = table.Column<bool>(nullable: false),
                    Is_Survey_Edit = table.Column<bool>(nullable: false),
                    Is_Survey_View = table.Column<bool>(nullable: false),
                    Is_Text_All = table.Column<bool>(nullable: false),
                    Is_Time_Clock_Add = table.Column<bool>(nullable: false),
                    Is_Time_Clock_Adjust_Other_User = table.Column<bool>(nullable: false),
                    Is_Time_Clock_Cost_Viewing = table.Column<bool>(nullable: false),
                    Is_Time_Clock_Delete = table.Column<bool>(nullable: false),
                    Is_Time_Clock_Edit = table.Column<bool>(nullable: false),
                    Is_Time_Clock_Review_And_Approve = table.Column<bool>(nullable: false),
                    Is_Time_Clock_View = table.Column<bool>(nullable: false),
                    Is_Time_Clock_View_Other_User = table.Column<bool>(nullable: false),
                    Is_Time_Sheet_Adjustment_All_Users = table.Column<bool>(nullable: false),
                    Is_Time_Sheet_Adjustment_Email = table.Column<bool>(nullable: false),
                    Is_Time_Sheet_Adjustment_Push = table.Column<bool>(nullable: false),
                    Is_Time_Sheet_Adjustment_Text = table.Column<bool>(nullable: false),
                    Is_To_Do_Add = table.Column<bool>(nullable: false),
                    Is_To_Do_Assign_Users = table.Column<bool>(nullable: false),
                    Is_To_Do_Completed_Email = table.Column<bool>(nullable: false),
                    Is_To_Do_Completed_Push = table.Column<bool>(nullable: false),
                    Is_To_Do_Completed_Text = table.Column<bool>(nullable: false),
                    Is_To_Do_Delete = table.Column<bool>(nullable: false),
                    Is_To_Do_Discussion_Added_Email = table.Column<bool>(nullable: false),
                    Is_To_Do_Discussion_Added_Push = table.Column<bool>(nullable: false),
                    Is_To_Do_Discussion_Added_Text = table.Column<bool>(nullable: false),
                    Is_To_Do_Edit = table.Column<bool>(nullable: false),
                    Is_To_Do_Global = table.Column<bool>(nullable: false),
                    Is_To_Do_View = table.Column<bool>(nullable: false),
                    Is_Trade_Agreement_Action_Taken_Email = table.Column<bool>(nullable: false),
                    Is_User_Confirmed_Change_Email = table.Column<bool>(nullable: false),
                    Is_User_Confirmed_Change_Push = table.Column<bool>(nullable: false),
                    Is_User_Confirmed_Change_Text = table.Column<bool>(nullable: false),
                    Is_User_Declined_Change_Email = table.Column<bool>(nullable: false),
                    Is_User_Declined_Change_Push = table.Column<bool>(nullable: false),
                    Is_User_Declined_Change_Text = table.Column<bool>(nullable: false),
                    Is_User_Need_To_Confirm_Change_Email = table.Column<bool>(nullable: false),
                    Is_User_Need_To_Confirm_Change_Push = table.Column<bool>(nullable: false),
                    Is_User_Need_To_Confirm_Change_Text = table.Column<bool>(nullable: false),
                    Is_Video_Comment_Added_Email = table.Column<bool>(nullable: false),
                    Is_Video_Comment_Added_Push = table.Column<bool>(nullable: false),
                    Is_Video_Comment_Added_Text = table.Column<bool>(nullable: false),
                    Is_Videos_Add = table.Column<bool>(nullable: false),
                    Is_Videos_Delete = table.Column<bool>(nullable: false),
                    Is_Videos_Edit = table.Column<bool>(nullable: false),
                    Is_Videos_View = table.Column<bool>(nullable: false),
                    Is_View_All = table.Column<bool>(nullable: false),
                    Is_View_All_Customer_Contacts = table.Column<bool>(nullable: false),
                    Is_View_All_Customer_Contacts_Readonly = table.Column<bool>(nullable: false),
                    Is_View_Owner_Site = table.Column<bool>(nullable: false),
                    Is_Warranty_Add = table.Column<bool>(nullable: false),
                    Is_Warranty_Added_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Added_Internally_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Added_Internally_Push = table.Column<bool>(nullable: false),
                    Is_Warranty_Added_Internally_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Added_Push = table.Column<bool>(nullable: false),
                    Is_Warranty_Added_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Delete = table.Column<bool>(nullable: false),
                    Is_Warranty_Discussion_Added_All_Users = table.Column<bool>(nullable: false),
                    Is_Warranty_Discussion_Added_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Discussion_Added_Push = table.Column<bool>(nullable: false),
                    Is_Warranty_Discussion_Added_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Edit = table.Column<bool>(nullable: false),
                    Is_Warranty_Follow_Up_All_Users = table.Column<bool>(nullable: false),
                    Is_Warranty_Follow_Up_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Follow_Up_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Has_Feedback_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Schedule_Changed_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Schedule_Changed_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Service_Internally_Assigned_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Service_Internally_Assigned_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Updated_Appt_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Updated_Appt_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_Updated_Email = table.Column<bool>(nullable: false),
                    Is_Warranty_Updated_Text = table.Column<bool>(nullable: false),
                    Is_Warranty_View = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    User_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detaild_Permission", x => x.Detaild_Permission_Id);
                });

            migrationBuilder.CreateTable(
                name: "Login_Details_Info",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastLoginDate = table.Column<DateTime>(nullable: false),
                    LoginDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Details_Info", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Master",
                columns: table => new
                {
                    Menu_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    CssClass = table.Column<string>(nullable: true),
                    Delflag = table.Column<bool>(nullable: false),
                    Menu_Name = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    PatentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Master", x => x.Menu_ID);
                });

            migrationBuilder.CreateTable(
                name: "Owner_Master",
                columns: table => new
                {
                    Owner_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessMethod = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AllowLockedSelections = table.Column<bool>(nullable: false),
                    AllowOrderRequests = table.Column<bool>(nullable: false),
                    AllowPaymentsTab = table.Column<bool>(nullable: false),
                    AllowWarrantyClaims = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile_No = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    OwnerActivation = table.Column<string>(nullable: true),
                    OwnerCalendar = table.Column<string>(nullable: true),
                    OwnerInformation = table.Column<string>(nullable: true),
                    Owner_Name = table.Column<string>(nullable: true),
                    Profile_Picture = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    ShowBudgetPurchaseOrders = table.Column<bool>(nullable: false),
                    ShowProjectPrice = table.Column<bool>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner_Master", x => x.Owner_ID);
                });

            migrationBuilder.CreateTable(
                name: "Predecessor_Information",
                columns: table => new
                {
                    PredecessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Lag = table.Column<int>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    ScheduledItemId = table.Column<int>(nullable: false),
                    SourceScheuledId = table.Column<int>(nullable: false),
                    TimeFrame = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predecessor_Information", x => x.PredecessorId);
                });

            migrationBuilder.CreateTable(
                name: "Project_Color",
                columns: table => new
                {
                    ProjectColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorCode = table.Column<string>(nullable: true),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    IsDisable = table.Column<bool>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ProjectColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Color", x => x.ProjectColorId);
                });

            migrationBuilder.CreateTable(
                name: "Project_Group",
                columns: table => new
                {
                    Project_Goup_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Project_Group_Name = table.Column<string>(nullable: true),
                    User_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Group", x => x.Project_Goup_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Manager_Master",
                columns: table => new
                {
                    Manager_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Manager_Name = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Manager_Master", x => x.Manager_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Master",
                columns: table => new
                {
                    Project_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Built_Up_Area = table.Column<float>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Contract_Price = table.Column<decimal>(nullable: false),
                    Country_ID = table.Column<decimal>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Group_No = table.Column<string>(nullable: true),
                    Internal_Notes = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Lot_Info = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    No_Of_Unit = table.Column<int>(nullable: false),
                    Org_ID = table.Column<long>(nullable: false),
                    Permit_No = table.Column<string>(nullable: true),
                    Project_Group_ID = table.Column<string>(nullable: true),
                    Project_Manager_id = table.Column<string>(nullable: true),
                    Project_Name = table.Column<string>(nullable: true),
                    Project_Prefix = table.Column<string>(nullable: true),
                    Project_Type_ID = table.Column<int>(nullable: false),
                    Project_land_Cost = table.Column<float>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Status_ID = table.Column<int>(nullable: false),
                    Sub_Notes = table.Column<string>(nullable: true),
                    User_ID = table.Column<int>(nullable: false),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Master", x => x.Project_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_schedule_Master",
                columns: table => new
                {
                    Schedule_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Actual_Completion = table.Column<DateTime>(nullable: false),
                    Actual_Start = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    ProjectColorId = table.Column<string>(nullable: true),
                    Project_Color_ID = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    Projected_Completion = table.Column<DateTime>(nullable: false),
                    Projected_Start = table.Column<DateTime>(nullable: false),
                    Works_Days = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_schedule_Master", x => x.Schedule_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Status_Master",
                columns: table => new
                {
                    Status_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Status_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Status_Master", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Subcontractor_config",
                columns: table => new
                {
                    SubContractor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Project_ID = table.Column<decimal>(nullable: false),
                    Subcontractor_Name = table.Column<string>(nullable: true),
                    View_Access = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Subcontractor_config", x => x.SubContractor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_Type_Master",
                columns: table => new
                {
                    Project_Type_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Project_Type_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Type_Master", x => x.Project_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Project_User_Int_Config_Master",
                columns: table => new
                {
                    Internal_User_Con_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Org_ID = table.Column<int>(nullable: false),
                    Project_ID = table.Column<int>(nullable: false),
                    Recive_Notification = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    User_Name = table.Column<string>(nullable: true),
                    View_Access = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_User_Int_Config_Master", x => x.Internal_User_Con_Id);
                });

            migrationBuilder.CreateTable(
                name: "SubContractor_Master",
                columns: table => new
                {
                    SubContractor_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Beneficiary = table.Column<string>(nullable: true),
                    CR_NO = table.Column<string>(nullable: true),
                    Catogery_ID = table.Column<decimal>(nullable: false),
                    Contact_Persion = table.Column<string>(nullable: true),
                    Country_ID = table.Column<int>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Org_ID = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContractor_Master", x => x.SubContractor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tag_Master",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    TagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag_Master", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_Assign",
                columns: table => new
                {
                    ToDoAssignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDoUserAssignTypeId = table.Column<int>(nullable: false),
                    TodoDetailsID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Assign", x => x.ToDoAssignID);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_CheckList",
                columns: table => new
                {
                    ToDoCheckListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDoAssignIFilesCheckListItem = table.Column<bool>(nullable: false),
                    ToDoAssignIsCheckListItem = table.Column<bool>(nullable: false),
                    TodoDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_CheckList", x => x.ToDoCheckListId);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_CheckList_Details",
                columns: table => new
                {
                    ToDochecklistDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    ToDoCheckListId = table.Column<int>(nullable: false),
                    ToDoCheckListTitle = table.Column<string>(nullable: true),
                    ToDoCheckListUserId = table.Column<int>(nullable: false),
                    ToDoCheckListUserTypeId = table.Column<int>(nullable: false),
                    ToDoIsCheckList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_CheckList_Details", x => x.ToDochecklistDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_Master",
                columns: table => new
                {
                    Todo_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignTo = table.Column<string>(nullable: true),
                    Assign_Date = table.Column<DateTime>(nullable: false),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Due_Date_Selection = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Org_ID = table.Column<int>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    Project_Site = table.Column<string>(nullable: true),
                    Reminder_ID = table.Column<int>(nullable: false),
                    Schedule_ID = table.Column<int>(nullable: false),
                    TaG_ID = table.Column<int>(nullable: false),
                    Time_choosen_ID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    state_val = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Master", x => x.Todo_ID);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_Master_Details",
                columns: table => new
                {
                    TodoDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    DeletionStatus = table.Column<bool>(nullable: false),
                    DueDatetime = table.Column<string>(nullable: true),
                    Duedate = table.Column<DateTime>(nullable: false),
                    IsMarkedComplete = table.Column<bool>(nullable: false),
                    LinkToDate = table.Column<DateTime>(nullable: false),
                    LinkToDaysStatus = table.Column<string>(nullable: true),
                    LinkToTime = table.Column<string>(nullable: true),
                    LinkToUnit = table.Column<int>(nullable: false),
                    LinkToWorkId = table.Column<int>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    Project_ID = table.Column<int>(nullable: false),
                    Project_Site = table.Column<string>(nullable: true),
                    ReminderId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TypeNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Master_Details", x => x.TodoDetailsID);
                });

            migrationBuilder.CreateTable(
                name: "To_Do_Tag",
                columns: table => new
                {
                    ToDoTagid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Tagid = table.Column<int>(nullable: false),
                    TodoDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_Tag", x => x.ToDoTagid);
                });

            migrationBuilder.CreateTable(
                name: "User_Master",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    Org_ID = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    User_Alert_Schedule = table.Column<int>(nullable: false),
                    User_Cell_Email = table.Column<string>(nullable: true),
                    User_Contact_Info = table.Column<string>(nullable: true),
                    User_Default_Labour_Cost = table.Column<string>(nullable: true),
                    User_Default_Time_Clock = table.Column<int>(nullable: false),
                    User_Email = table.Column<string>(nullable: true),
                    User_Enabled = table.Column<bool>(nullable: false),
                    User_First_Name = table.Column<string>(nullable: true),
                    User_Forum_Handle = table.Column<string>(nullable: true),
                    User_Is_Alert = table.Column<bool>(nullable: false),
                    User_Is_Automatic_Access = table.Column<bool>(nullable: false),
                    User_Is_Forum_Handle = table.Column<bool>(nullable: false),
                    User_Last_Name = table.Column<string>(nullable: true),
                    User_Login_Enabled = table.Column<bool>(nullable: false),
                    User_Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Master", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Warrenty_Alert",
                columns: table => new
                {
                    Warrent_Alert_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_By = table.Column<string>(nullable: true),
                    Created_Date = table.Column<DateTime>(nullable: false),
                    Modified_By = table.Column<string>(nullable: true),
                    Modified_Date = table.Column<DateTime>(nullable: false),
                    User_ID = table.Column<int>(nullable: false),
                    Warrenty_Name = table.Column<string>(nullable: true),
                    Warrenty_Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warrenty_Alert", x => x.Warrent_Alert_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar_Phase");

            migrationBuilder.DropTable(
                name: "Calendar_Scheduled_Item");

            migrationBuilder.DropTable(
                name: "Calendar_Tag");

            migrationBuilder.DropTable(
                name: "Company_Master");

            migrationBuilder.DropTable(
                name: "Detaild_Permission");

            migrationBuilder.DropTable(
                name: "Login_Details_Info");

            migrationBuilder.DropTable(
                name: "Menu_Master");

            migrationBuilder.DropTable(
                name: "Owner_Master");

            migrationBuilder.DropTable(
                name: "Predecessor_Information");

            migrationBuilder.DropTable(
                name: "Project_Color");

            migrationBuilder.DropTable(
                name: "Project_Group");

            migrationBuilder.DropTable(
                name: "Project_Manager_Master");

            migrationBuilder.DropTable(
                name: "Project_Master");

            migrationBuilder.DropTable(
                name: "Project_schedule_Master");

            migrationBuilder.DropTable(
                name: "Project_Status_Master");

            migrationBuilder.DropTable(
                name: "Project_Subcontractor_config");

            migrationBuilder.DropTable(
                name: "Project_Type_Master");

            migrationBuilder.DropTable(
                name: "Project_User_Int_Config_Master");

            migrationBuilder.DropTable(
                name: "SubContractor_Master");

            migrationBuilder.DropTable(
                name: "Tag_Master");

            migrationBuilder.DropTable(
                name: "To_Do_Assign");

            migrationBuilder.DropTable(
                name: "To_Do_CheckList");

            migrationBuilder.DropTable(
                name: "To_Do_CheckList_Details");

            migrationBuilder.DropTable(
                name: "To_Do_Master");

            migrationBuilder.DropTable(
                name: "To_Do_Master_Details");

            migrationBuilder.DropTable(
                name: "To_Do_Tag");

            migrationBuilder.DropTable(
                name: "User_Master");

            migrationBuilder.DropTable(
                name: "Warrenty_Alert");
        }
    }
}
