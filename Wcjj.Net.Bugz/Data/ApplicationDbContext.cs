using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Wcjj.Net.Bugz.Data 
{

public class ApplicationDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<App>()
            .HasMany(e => e.Bugs)
            .WithOne(x => x.App)
            .HasForeignKey(x => x.BugId)
            .IsRequired();

        modelBuilder.Entity<Bug>()
            .HasOne(x => x.App)
            .WithMany(e => e.Bugs)
            .HasForeignKey( e => e.BugId)
            .IsRequired();


        base.OnModelCreating(modelBuilder);
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
        [Key]
        [ForeignKey(nameof(Bug))]
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerID { get; set; }
        
        public IdentityUser? Owner { get; set;}
        public DateTime CreateDate { get; set; }

        
        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }

    

    public partial class Bug()
    {
        [Key]
        public int BugId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]        
        public int StatusId { get; set; }
        [Required]        
        public int PriorityId {get;set;}

        //User reference                
        public string SubmitterId { get; set; }
        public IdentityUser? Submitter { get; set; }

        public string AssignedToId { get; set; }  
        public IdentityUser? AssignedTo { get; set; }

        
        //[NotMapped]
        //public int AppId1 { get; set; }

        
        public int AppId { get; set; }        
        public App? App { get; set; }

       public ICollection<Comment> Comments {get; set; } = new List<Comment>();

    }

    public class Status () {
        [ForeignKey(nameof(Bug))]
        public int StatusId {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}

        ICollection<Bug> Bugz {get; set;} = new List<Bug>();

    }

    public class Priority () {
        [ForeignKey(nameof(Bug))]
        public int PriorityId {get;set;}
        public int PriorityPrecedence { get; set; }
        public string Name {get;set;}
        public string Description {get;set;}

        ICollection<Bug> Bugz {get; set;} = new List<Bug>();

    }

    public class Comment
    {
        public int CommentId {get;set;}
        [ForeignKey (nameof(Bug))]
        public int BugId {get;set;}        
        public string Subject {get;set; }
        public string Details {get;set;}
        public string CreatedById {get;set;}
        public IdentityUser CreatedBy { get; set;}

        public ICollection<CommentAttachment> Attachments { get; } = new List<CommentAttachment>();
    }

    public class MimeType() {
        [ForeignKey(nameof(BugAttachment))]   
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
