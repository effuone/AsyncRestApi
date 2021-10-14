using System;
using System.ComponentModel.DataAnnotations;

namespace StudentApi.DTOs
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init;}
        public decimal Price { get; init; } 
        public DateTimeOffset CreatedDate {get; init;}
    }
    public record CreateItemDto
    {
        [Required]
        public string Name { get; init;}
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; } 
    }
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init;}
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; } 
    }
}