using System;

namespace StudentApi.DTOs
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init;}
        public decimal Price { get; init; } 
        public DateTimeOffset CreatedDate {get; init;}
    }
}