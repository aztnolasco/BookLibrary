
using Application.Shared.Models;

namespace Application.Shared.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetBookByAuthorAsync(string authorName, CancellationToken cancellationToken);
    Task<List<Book>> GetBookByISBNAsync(string ISBN, CancellationToken cancellationToken);
}
