namespace Benaa2018.Helper.ViewModels
{
    public class PredecessorInformationViewModel : CommonViewModel
    {
        public int PredecessorId { get; set; }
        public int ScheduledItemId { get; set; }
        public int SourceScheuledId { get; set; }
        public string TimeFrame { get; set; }
        public int Lag { get; set; }
    }
}
