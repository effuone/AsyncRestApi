using System;

namespace StudentApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public DateTimeOffset Birthday { get; set;}
        public long GroupId { get; set;} 
    }
}