using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> Users = new List<User>();

    // GET: Retrieve a list of users with pagination
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            // Pagination logic to improve performance
            var pagedUsers = Users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return Ok(pagedUsers);
        }
        catch (Exception ex)
        {
            // Error handling for unhandled exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: Retrieve a specific user by ID
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        try
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        catch (Exception ex)
        {
            // Error handling for unhandled exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // POST: Add a new user with validation
    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            // Error handling for unhandled exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: Update an existing user's details with validation
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Department = updatedUser.Department;
            return NoContent();
        }
        catch (Exception ex)
        {
            // Error handling for unhandled exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: Remove a user by ID
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            Users.Remove(user);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Error handling for unhandled exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
