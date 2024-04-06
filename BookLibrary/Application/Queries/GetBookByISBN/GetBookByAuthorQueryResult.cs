using Application.Shared.Models;

namespace Application.Queries.GetBookByISBN;


public class GetBookByISBNQueryResult
{
    public  List<Book> Book { get; set; }
}
