using System;
using System.Collections.Generic;

namespace StudentApi.Models
{
    public class Student
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }         
        public string  Phone { get; set; }
        public long GroupId { get; set; }       
    }
}