using System;
using System.ComponentModel.DataAnnotations;

namespace StudentApi.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public DateTimeOffset Birthday { get; set;}
        public long GroupId { get; set;} 
    } 

    public class CreateStudentDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set;}
        [Required]
        public DateTimeOffset Birthday { get; set;} 
        [Required]
        public long GroupId { get; set; }
    }
    public class UpdateStudentDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set;}
        [Required]
        public DateTimeOffset Birthday { get; set;} 
        [Required]
        public long GroupId { get; set; }
    }
}
    