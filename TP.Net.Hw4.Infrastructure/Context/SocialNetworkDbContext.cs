using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP.Net.Hw4.Domain.Common;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Application.Interfaces.Context;

namespace TP.Net.Hw4.Infrastructure.Context
{
    public class SocialNetworkDbContext : IdentityDbContext<User, UserRole, int>, ISocialNetworkDbContext
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
        {
        }
         
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<UserMessageArchive> UserMessagesArchive { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserPostComment> UserPostsComments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendshipRequest> FriendshipRequests { get; set; }
        public DbSet<FriendshipApproval> FriendshipApprovals { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }
        public DbSet<GroupMessageArchive> GroupMessagesArchive { get; set; }
        public DbSet<CommentType> CommentTypes { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;


            //modelBuilder.Entity<IdentityUserLogin<string>>(eb => eb.HasNoKey());
            //modelBuilder.Entity<IdentityUserRole<string>>(eb => eb.HasNoKey());
            //modelBuilder.Entity<IdentityUserToken<string>>(eb => eb.HasNoKey());

        }

    }
}
