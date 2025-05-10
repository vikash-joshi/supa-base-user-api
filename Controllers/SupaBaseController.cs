using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Supabase;
using SupaBaseNewsLetter.Models;
using SupaBaseNewsLetter.Services;

namespace SupaBaseNewsLetter.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SupaBaseController : ControllerBase
    {
           public readonly ISupabaseService _supabaseService;
        public SupaBaseController(ISupabaseService _supabaseService)
        {
            this._supabaseService = _supabaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _supabaseService.GetUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(JsonConvert.SerializeObject(users));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByRPC()
        {
            var users = await _supabaseService.GetUserByRPC();;
            List<dynamic> userList = new List<dynamic>();
            foreach (var user in users)
            {
                Console.WriteLine(user);
                userList.Add(new { sps = user?.sps == null ? "" : user?.sps,Id = user.Id, FullName = user.FullName,Email = user.Email });
            }
            return Ok(userList); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            var createdUser = await _supabaseService.CreateUserAsync(user);
            if (createdUser == null)
            {
                return BadRequest("Failed to create user.");
            }
            return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, new {createdUser.Id, createdUser.FullName, createdUser.Email});
        }


    }
}