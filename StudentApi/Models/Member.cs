using System;
using System.Collections.Generic;

namespace StudentApi.Models
{
    public class Member
    {
        public long MemberId { get; set; }    
        public long StudentId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}