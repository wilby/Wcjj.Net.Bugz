using System.ComponentModel.DataAnnotations.Schema;

namespace Wcjj.Net.Bugz.Data
{
    public partial class Bug
    {
        [NotMapped]
        public List<Status> Status_ { get; set; } = new List<Status>();
        [NotMapped]
        public List<Priority> BugTypes { get; set; } = new List<Priority>();
        [NotMapped]
        public List<MimeType> MimeTypes { get; set; } = new List<MimeType>();
        [NotMapped]
        public List<App> Apps { get; set; } = new List<App>();

    }
}
