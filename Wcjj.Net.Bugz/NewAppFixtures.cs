using Microsoft.EntityFrameworkCore;
using Wcjj.Net.Bugz.Data;

namespace Wcjj.Net.Bugz
{
    public class NewAppFixtures
    {
        private ApplicationDbContext _context;

        public NewAppFixtures(ApplicationDbContext appContext)
        {
            _context = appContext;
        }

        public void CreateFixtures()
        {
            bool hasFixtures = _context.Priorities.Count() > 0;
            if(!hasFixtures)
            {
                _context.Priorities.Add(new Priority()
                {
                    PriorityId = 1,
                    PriorityPrecedence = 1,
                    Name = "Bug",
                    Description = "A standard non-fatal bug"
                });
                _context.Priorities.Add(new Priority()
                {
                    PriorityId = 2,
                    PriorityPrecedence = 2,
                    Name = "Enhancement Request",
                    Description = "A feature or enchancement request."
                });
                _context.Priorities.Add(new Priority()
                {
                    PriorityId = 3,
                    PriorityPrecedence = 0,
                    Name = "Catastrophic Bug",
                    Description = "A bug that keeps any part of the system from working."
                });

                _context.Status_.Add(new Status()
                {
                    StatusId = 1,
                    Name = "New",
                    Description = "A new created bug, not yet assigned or reviewed."
                });

                _context.Status_.Add(new Status()
                {
                    StatusId = 2,
                    Name = "Open",
                    Description = "Assigned or accepted, currently working."
                });

                _context.Status_.Add(new Status()
                {
                    StatusId = 3,
                    Name = "On Hold",
                    Description = "Bug was opened and has been worked, currently back burnered for a higher priority"
                });

                _context.Status_.Add(new Status()
                {
                    StatusId = 3,
                    Name = "Closed",
                    Description = "Bug has been resolved and closed out."
                });

                _context.Apps.Add(new App()
                {
                    AppId = 1,
                    Name = "Default App",
                    Description = "A default app.",
                    CreateDate = DateTime.Now, 
                    OwnerID = _context.Users.FirstOrDefault().Id                    
                });
                _context.SaveChanges();
            }
        }
    }
}
