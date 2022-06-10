using Microsoft.EntityFrameworkCore;
using MuhammetAliDemir.TP.Net.Hw4.Domain.Common;
using MuhammetAliDemir.TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Interfaces.Context
{
    public interface ISocialNetworkDbContext
    {
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
    }
}
