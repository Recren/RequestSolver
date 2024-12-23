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

        [HttpGet("Users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

    }
}