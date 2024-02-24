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

    [HttpGet("{id}", Name = "GeItemById")]
    public IActionResult GetById(int id)
    {
        var item = _itemRepo.GetById(id);
        if (item != null) return Ok(item);
        return BadRequest();
    }

    [HttpPost]
    public IActionResult Post(Item item)
    {
        _itemRepo.Add(item);
        return CreatedAtAction("GetItemById", new { id = item.Id }, item);
    }
}