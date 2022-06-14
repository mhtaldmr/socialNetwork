
using TP.Net.Hw.Application.Interfaces.Models;

namespace TP.Net.Hw.Application.Dtos.Requests
{
    public class UserMessageQueryDto : IQueryObject
    {
        public string? SortBy { get ; set; }
        public bool IsSortAscending { get ; set; }
        public int Page { get ; set; }
        public byte PageSize { get ; set; }
        public string? MessageBody { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}