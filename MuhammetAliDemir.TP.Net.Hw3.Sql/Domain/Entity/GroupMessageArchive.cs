namespace MuhammetAliDemir.TP.Net.Hw3.Sql.Domain.Entity
{
    public class GroupMessageArchive
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string MessageBody { get; set; }
        public int MessageTypeId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
