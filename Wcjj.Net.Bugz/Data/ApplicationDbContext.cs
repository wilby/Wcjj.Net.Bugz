using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Wcjj.Net.Bugz.Data 
{

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<App> Apps {get; set;}
    public DbSet<Bug> Bugs {get; set;}
    public DbSet<Status> Status_ {get; set;}
    public DbSet<Priority> Priorities {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<MimeType> MimeTypes {get; set;}    
    public DbSet<BugAttachment> BugAttachments {get; set;}
    public DbSet<CommentAttachment> CommentAttachments {get; set;}
}
    public class App()
    {
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerID { get; set; }
        
        
        
        public IdentityUser? Owner { get; set;}
        public DateTime CreateDate { get; set; }

        
        public List<Bug> Bugz { get; set; } = new();
    }

    

    public partial class Bug()
    {
        public int BugId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        
        public int StatusId { get; set; } 
        public int PriorityId {get;set;}

        //User reference
        public string SubmitterId { get; set; }
        public IdentityUser? Submitter { get; set;}
        public string AssignedToId { get; set; }
        public IdentityUser? AssignedTo { get; set;}

        public int AppId { get; set; }        
        public App? Application { get; set; }

       public List<Comment> Comments {get; set; } = new();

    }

    public class Status () {
        public int StatusId {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}

        List<Bug> Bugz {get; set;} = new(); 

    }

    public class Priority () {
        public int PriorityId {get;set;}
        public int PriorityPrecedence { get; set; }
        public string Name {get;set;}
        public string Description {get;set;}

        List<Bug> Bugz {get; set;} = new(); 

    }

    public class Comment
    {
        public int CommentId {get;set;}
        public int BugId {get;set;}
        public Bug Bugg {  get; set; }
        public string Subject {get;set; }
        public string Details {get;set;}
        public string CreatedById {get;set;}
        public IdentityUser CreatedBy { get; set;}

        public List<CommentAttachment> Attachments { get; } = new();
    }

    public class MimeType() {
        public int MimeTypeId { get; set; } 
        public string Type { get; set; }
        public string Description {get;set;}
        public string AltType {get;set;}
    }

    public class BugAttachment()
    {   
        public int BugAttachmentId  {get;set;}
        public string Path {get;set;}
        public int MimeTypeId {get; set;}
        public MimeType MimeType_ {get;set;}

        public int BugId {get;set;}
        public Bug? Bugg {get;set;}
        
        
    }

    public class CommentAttachment() {
        public int CommentAttachmentId {get;set;}
        public string Path {get;set;}   
        public int MimeTypeId {get; set;}
        public MimeType MimeType_ {get;set;}

        public int CommentId {get;set;}
        public Comment? Comment_ {get;set;}
    }
}
