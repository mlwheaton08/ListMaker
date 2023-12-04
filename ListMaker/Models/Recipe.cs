namespace ListMaker.Models;

public class Recipe
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string? Notes { get; set; }
    public DateTime DateCreated { get; set; }

    public List<RecipeItem> Items { get; set; } = new List<RecipeItem>();
}