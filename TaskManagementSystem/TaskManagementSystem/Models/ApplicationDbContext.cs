using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskManagementSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Dedails About Under Method-https://entityframework.net/knowledge-base/39798317/identityuserlogin-string---requires-a-primary-key-to-be-defined-error-while-adding-migration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            // https://eamonkeane.dev/computed-columns-in-entity-framework-core/           

        }
        public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<PoliceStation> PoliceStation { get; set; }
        public virtual DbSet<PostOffice> PostOffice { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<EmpBasicInfo> EmpBasicInfo { get; set; }
        public virtual DbSet<EmpCategory> EmpCategory { get; set; }
        public virtual DbSet<EmpDepartment> EmpDepartment { get; set; }
        public virtual DbSet<EmpDesignation> EmpDesignation { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<IssueAttachment> IssueAttachment { get; set; }
        public virtual DbSet<IssueHistory> IssueHistory { get; set; }
        public virtual DbSet<IssueStatus> IssueStatus { get; set; }
        public virtual DbSet<IssueType> IssueType { get; set; }
        public virtual DbSet<IssueWebLink> IssueWebLink { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectUsers> ProjectUsers { get; set; }
        public virtual DbSet<Sprint> Sprint { get; set; }
    }
}
