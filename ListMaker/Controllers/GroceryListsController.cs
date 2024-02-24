using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class GroceryListsController : ControllerBase
{
    private readonly IGroceryListRepository _groceryListRepo;

    public GroceryListsController(IGroceryListRepository groceryListRepo)
    {
        _groceryListRepo = groceryListRepo;
    }

    [HttpGet]
    public IActionResult GetAll(int? userId, bool? listItems, bool? isOpen)
    {
        return Ok(_groceryListRepo.GetAll(userId, listItems, isOpen));
    }

    [HttpGet("{id}", Name = "GetGroceryListById")]
    public IActionResult GetById(int id)
    {
        var list = _groceryListRepo.GetById(id);
        if (list != null) return Ok(list);
        return BadRequest();
    }
}