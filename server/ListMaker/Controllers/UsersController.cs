using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepo;

    public UsersController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet("{firebaseId}", Name = "GetUserByFirebaseId")]
    public IActionResult GetByFirebaseId(string firebaseId)
    {
        var user = _userRepo.GetByFirebaseId(firebaseId);
        if (user != null) return Ok(user);
        return NotFound();
    }
}