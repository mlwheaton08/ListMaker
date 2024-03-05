using ListMaker.Models;
using ListMaker.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListMaker.Controllers;

[Route("[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepo;

    public ItemsController(IItemRepository itemRepo)
    {
        _itemRepo = itemRepo;
    }

    [HttpGet]
    public IActionResult GetAll(int? userId)
    {
        return Ok(_itemRepo.GetAll(userId));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _itemRepo.GetById(id);
        if (item != null) return Ok(item);
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post(Item item)
    {
        _itemRepo.Add(item);
        return CreatedAtAction("GetById", new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _itemRepo.Update(item);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _itemRepo.Delete(id);
        return NoContent();
    }
}