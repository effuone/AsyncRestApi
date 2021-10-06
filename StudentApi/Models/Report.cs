using System;

namespace StudentApi.Models
{
    public class Report
    {
        public long ReportId { get; set; }
        public long DepartmentId { get; set; }
        public DateTime ReportDate { get; set; }
        public string Description {get; set;}
    }
}