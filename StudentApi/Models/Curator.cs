using System;
using System.Collections.Generic;

namespace StudentApi.Models
{
    public class Curator
    {
        public long CuratorId { get; set; }    
        public long MemberId { get; set; }
        public DateTime BecameDate { get; set; }
    }
}