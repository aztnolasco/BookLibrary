using System.Data;
using Application.Shared.Interfaces;
using Application.Shared.Models;
using Application.Shared.Repositories.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IDbConnection _dbConnection;

    public BookRepository(BookContext context)
    {
      _dbConnection = context.Database.GetDbConnection();
      
    }
    
    public async Task<List<Book>> GetBookByAuthorAsync(string authorName, CancellationToken cancellationToken)
    {
        string query = $"SELECT * FROM BOOKS B WHERE B.FIRSTNAME LIKE {authorName}";
        var result = await _dbConnection.QueryAsync<Book>(query, cancellationToken);
        return result.ToList();
    }

    public async Task<List<Book>> GetBookByISBNAsync(string ISBN, CancellationToken cancellationToken)
    {
        string query = $"SELECT * FROM BOOKS B WHERE B.ISBN = {ISBN}";
        var result = await _dbConnection.QueryAsync<Book>(query, cancellationToken);
        return result.ToList();
    }

}
