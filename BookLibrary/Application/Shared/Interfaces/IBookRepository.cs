
using Application.Shared.Models;

namespace Application.Shared.Interfaces;

public interface IBookRepository
{
    Task<Book> GetBookByAuthorAsync(string authorName, CancellationToken cancellationToken);
    Task<Book> GetBookByISBNAsync(string iSBN, CancellationToken cancellationToken);
}
