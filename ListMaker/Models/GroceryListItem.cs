namespace ListMaker.Models;

public class GroceryListItem
{
    public int Id { get; set; }
    public int GrocerListId { get; set; }
    public int ItemId { get; set; }
    public double Quantity { get; set; }
    public string? UnitMeas { get; set; }

    public Item? Item { get; set; }
}
