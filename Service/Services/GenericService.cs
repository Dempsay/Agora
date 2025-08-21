using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    internal class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        public GenericService() { 

        }
        public Task<T?> AddAsync(T? entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>?> GetAllAsync(string? filtro)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>?> GetDeletedsAllAsync(string? filtro)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RestoreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T? entity)
        {
            throw new NotImplementedException();
        }
    }
}
