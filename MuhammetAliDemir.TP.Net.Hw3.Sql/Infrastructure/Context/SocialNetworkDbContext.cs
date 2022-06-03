using Microsoft.EntityFrameworkCore;
using MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Common;
using MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity;

namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Infrastructure.Context
{
    public class SocialNetworkDbContext : DbContext
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
        public DbSet<RequestStatusType> RequestStatusTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }
}
