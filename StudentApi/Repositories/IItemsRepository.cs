using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentApi.Models;

namespace StudentApi.Repositories {
    public interface IItemsRepository<T> where T : class 
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(Guid id);
    }
}