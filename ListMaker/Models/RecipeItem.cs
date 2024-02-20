namespace ListMaker.Models;

public class RecipeItem
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int ItemId { get; set; }
    public double Quantity { get; set; }
    public string? UnitMeas { get; set; }

    public Item? Item { get; set; }
}
