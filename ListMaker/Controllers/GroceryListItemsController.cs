using ListMaker.Models;
using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class GroceryListItemsController : ControllerBase
{
    private readonly IGroceryListItemRepository _groceryListItemRepo;

    public GroceryListItemsController(IGroceryListItemRepository groceryListItemRepo)
    {
        _groceryListItemRepo = groceryListItemRepo;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var groceryListItem = _groceryListItemRepo.GetById(id);
        if (groceryListItem == null) return NotFound();
        return Ok(groceryListItem);
    }

    [HttpPost]
    public IActionResult Post(GroceryListItem groceryListItem)
    {
        _groceryListItemRepo.Add(groceryListItem);
        return CreatedAtAction("GetById", new { id = groceryListItem.Id }, groceryListItem);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, GroceryListItem groceryListItem)
    {
        if (id != groceryListItem.Id)
        {
            return BadRequest();
        }

        _groceryListItemRepo.Update(groceryListItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _groceryListItemRepo.Delete(id);
        return NoContent();
    }
}