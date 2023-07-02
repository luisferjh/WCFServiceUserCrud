using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        User Get(long id);
        List<User> GetAll();
        long Insert(User user);
        bool Update(User user);
        bool Delete(User user);

        Task<User> GetAsync(long id);
        Task<List<User>> GetAllAsync();
        Task<long> InsertAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);
    }
}
