using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupaBaseNewsLetter.Models;

namespace SupaBaseNewsLetter.Services
{
    public interface ISupabaseService
    {
        Task<List<User>> GetUsersAsync();

        Task<List<dynamic>> GetUserByRPC();
    Task<User?> CreateUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(int id);
    }
}