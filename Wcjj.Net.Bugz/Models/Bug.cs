using System.ComponentModel.DataAnnotations.Schema;

namespace Wcjj.Net.Bugz.Data
{
    public partial class Bug
    {
        public List<Status> Status_ { get; set; } = new List<Status>();
        public List<Priority> BugTypes { get; set; } = new List<Priority>();
        public List<MimeType> MimeTypes { get; set; } = new List<MimeType>();
        public List<App> Apps { get; set; } = new List<App>();
    }
}
