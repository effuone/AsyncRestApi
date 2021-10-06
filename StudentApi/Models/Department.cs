using System;
using System.Collections.Generic;

namespace StudentApi.Models
{
    public class Department
    {
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long CuratorId { get; set; }   
    }
}