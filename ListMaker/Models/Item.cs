namespace ListMaker.Models;

public class Item
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StoreSectionId { get; set; }
    public string Name { get; set; }
    public string? Notes { get; set; }
    public DateTime DateCreated { get; set; }

    public StoreSection? StoreSection { get; set; }
}
