using RO.DevTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(Client client);
    }
}
