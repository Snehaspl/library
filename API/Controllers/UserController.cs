using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetUserList()
        {
            var user = await _context.Users.ToListAsync();
            return user;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUsers>> GetUserListById(int id)
        {
            var userList = await _context.Users.FindAsync(id);
            return userList;
        }
    }
}