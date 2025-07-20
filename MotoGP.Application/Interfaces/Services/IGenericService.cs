using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Application.Interfaces.Services;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T news);
    Task<T?> UpdateAsync(Guid id, T news);
    Task<bool> DeleteAsync(Guid id);
}
