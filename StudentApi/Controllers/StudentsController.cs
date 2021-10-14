using Microsoft.AspNetCore.Mvc;
using StudentApi.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentApi.DTOs;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IAsyncRepository<Student> repository;

        public StudentsController(IAsyncRepository<Student> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = (await repository.GetAllAsync())
            .Select(x=>new StudentDto{
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                GroupId = x.GroupId,
                Birthday = x.Birthday
            });
            return students;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentAsync(Guid id)
        {
            var student = await repository.GetAsync(id);
            if(student is null)
            {
                return NotFound();
            }
            return student.AsDto();
        }
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudentAsync(CreateStudentDto studentDto)
        {
            Student student = new()
            {
                Id = Guid.NewGuid(),
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                GroupId = studentDto.GroupId,
                Birthday = studentDto.Birthday
            };
            await repository.CreateAsync(student);
            return CreatedAtAction(nameof(GetStudentAsync), new {Id = student.Id}, student.AsDto());
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<StudentDto>> UpdateStudentAsync(Guid id, UpdateStudentDto studentDto)
        {
            var existingStudent = await repository.GetAsync(id);
            if (existingStudent is null)
            {
                return NotFound();
            }

            var updatedStudent = new Student()
            {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            GroupId = studentDto.GroupId,
            Birthday = studentDto.Birthday
            };
            await repository.UpdateAsync(updatedStudent);
            return NoContent();
        }
        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingStudent = await repository.GetAsync(id);
            if(existingStudent is null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(id);
            return NoContent();
        }
    }
}