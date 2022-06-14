﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Net.Hw4.Domain.Entity
{
    public class UserMessageQuery
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
        public int MessageId { get; set; }
        public string? MessageBody { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}