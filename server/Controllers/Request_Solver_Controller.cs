using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using RequestSolver.Data;
using RequestSolver.Entities;

namespace RequestSolver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequestSolverController : ControllerBase
    {
        private readonly RequestSolverContext _context;

        public RequestSolverController(RequestSolverContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("users/{user_id}")]
        public async Task<ActionResult<User>> GetUser(int user_id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.user_id == user_id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("requests")]
        public async Task<ActionResult<List<Request>>> GetRequests()
        {
            var requests = await _context.Requests.ToListAsync();
            return Ok(requests);
        }

        [HttpGet("requests/assigned_requests/{user_id}")]
        public async Task<ActionResult<List<Request>>> GetAllRequestForUser(int user_id)
        {
            var userExists = await _context.Users.SingleOrDefaultAsync(user => user.user_id == user_id);
            if (userExists == null)
            {
                return NotFound();
            }
            var requestsForUser = await _context.Requests.Where(rq => rq.assigned_to_user_id == user_id).ToListAsync();
            return Ok(requestsForUser);
        }
    }
}