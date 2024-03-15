using ListMaker.Models;
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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var list = _groceryListRepo.GetById(id);
        if (list != null) return Ok(list);
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post(GroceryList groceryList)
    {
        _groceryListRepo.Add(groceryList);
        return CreatedAtAction("GetById", new { id = groceryList.Id }, groceryList);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, GroceryList groceryList)
    {
        if (id != groceryList.Id)
        {
            return BadRequest();
        }

        _groceryListRepo.Update(groceryList);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _groceryListRepo.Delete(id);
        return NoContent();
    }
}