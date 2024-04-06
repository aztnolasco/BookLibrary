namespace Application.Shared.Models;

public class Book
{
    public string Title { get; set; }
    public string Publisher { get; set; }
    public List<Author> Authors { get; set; }
    public TypeEnum Type { get; set;}
    public string ISBN { get; set; }
    public CategoryEnum Category {get; set;}
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
}
