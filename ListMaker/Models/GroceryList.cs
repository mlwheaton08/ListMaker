namespace ListMaker.Models;

public class GroceryList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string? Notes { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public bool IsOpen { get; set; }

    public List<GroceryListItem>? Items { get; set; } = new List<GroceryListItem>();
}
