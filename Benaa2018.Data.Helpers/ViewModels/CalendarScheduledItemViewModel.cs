using System;
using System.Collections.Generic;

namespace Benaa2018.Helper.ViewModels
{
    public class CalendarScheduledItemViewModel : CommonViewModel
    {
        public CalendarScheduledItemViewModel()
        {
            CalendarPhaseModel = new CalendarPhaseViewModel();
            CalendarTagModel = new CalendarTagViewModel();
            CalendarPhaseModels = new List<CalendarPhaseViewModel>();
            CalendarTagModels = new List<CalendarTagViewModel>();
            PredecessorInformationModel = new PredecessorInformationViewModel();
            ProjectColorViewModels = new List<ProjectColorViewModel>();
            PredecessorInformationModels = new List<PredecessorInformationViewModel>();
            CalendarScheduledItemModels = new List<CalendarScheduledItemViewModel>();
        }

        public int ScheduledItemId { get; set; }
        public string Title { get; set; }
        public int CompanyId { get; set; }
        //public int TagId { get; set; }
        public int ProjectId { get; set; }
        public string ColorCode { get; set; }
        public string StartDate { get; set; }
        public string SelectedDate { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string AssignedTo { get; set; }
        public int Reminder { get; set; }
        public bool Hourly { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool ShowOnGnatt { get; set; }
        public bool ShowOwner { get; set; }
        public string PhaseName { get; set; }
        public string TagName { get; set; }
        public int PhaseId { get; set; }
        public int TagId { get; set; }
        public int Status { get; set; }
        public int TotalScheuleDay { get; set; }
        public int ScheuleDay { get; set; }
        public bool IsNotify { get; set; }
        public bool IsRequiredConfirmation { get; set; }
        public string PageType { get; set; }
        public string ResponseJsonString { get; set; }
        public CalendarPhaseViewModel CalendarPhaseModel { get; set; }
        public CalendarTagViewModel CalendarTagModel { get; set; }
        public List<CalendarPhaseViewModel> CalendarPhaseModels { get; set; }
        public List<CalendarTagViewModel> CalendarTagModels { get; set; }
        public List<ProjectColorViewModel> ProjectColorViewModels { get; set; }
        public List<UserMasterViewModel> UserMasterViewModels { get; set; }
        public List<ProjectSubcontractorMasterViewModel> ProjectSubcontractorMasterViewModels { get; set; }
        public PredecessorInformationViewModel PredecessorInformationModel { get; set; }
        public List<PredecessorInformationViewModel> PredecessorInformationModels { get; set; }
        public List<CalendarScheduledItemViewModel> CalendarScheduledItemModels { get; set; }
        public List<string> TimeIntervalLists
        {
            get
            {
                return TimeIntervals();
            }
        }
        public List<string> TimeIntervals()
        {
            List<string> timeIntervals = new List<string>();
            DateTime date = DateTime.MinValue.AddHours(0);
            DateTime endDate = DateTime.MinValue.AddDays(1).AddHours(0);
            while (date < endDate)
            {
                timeIntervals.Add(date.ToShortTimeString());
                date = date.AddMinutes(30);
            }
            return timeIntervals;
        }
    }
}
