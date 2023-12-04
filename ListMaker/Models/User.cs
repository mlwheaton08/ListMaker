namespace ListMaker.Models;

public class User
{
    public int Id { get; set; }
    public string FirebaseId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime RegisterDate { get; set; }
}
