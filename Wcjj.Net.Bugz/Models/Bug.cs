namespace Wcjj.Net.Bugz.Data
{
    public partial class Bug
    {
        public List<Status> Status_ { get; set; }
        public List<Priority> BugTypes { get; set; }
        public List<MimeType> MimeTypes { get; set; }
       
    }
}
