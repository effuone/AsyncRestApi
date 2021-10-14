using StudentApi.DTOs;
using StudentApi.Models;

namespace StudentApi{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
        public static StudentDto AsDto(this Student student)
        {
            return new StudentDto{
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId
            };
        }
    }
}