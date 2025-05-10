using Newtonsoft.Json;
using Supabase;
using SupaBaseNewsLetter.Models;

namespace SupaBaseNewsLetter.Services;

public class SupabaseService : ISupabaseService
{
    private readonly Supabase.Client _client;

    public SupabaseService(Supabase.Client client)
    {
        _client = client;
  }
    public async Task<List<User>> GetUsersAsync() =>
        (await _client.From<User>().Get()).Models.ToList();
    public async Task<List<dynamic>> GetUserByRPC()
    {
      
        var response = await _client.Postgrest.Rpc<List<dynamic>>("getusers",null);
        Console.WriteLine(response.GetType());
              return response;
        
        
    }

    public async Task<User?> CreateUserAsync(User user) =>
        (await _client.From<User>().Insert(user)).Models.FirstOrDefault();

    public async Task<bool> UpdateUserAsync(User user) =>
        (await _client.From<User>().Update(user)).Models.Any();

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = new User { Id = id };
        return (await _client.From<User>().Delete(user)).Models.Any();
    }
}
