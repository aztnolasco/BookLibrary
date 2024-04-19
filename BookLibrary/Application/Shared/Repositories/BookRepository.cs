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
    
    public async Task<Book> GetBookByAuthorAsync(string authorName, CancellationToken cancellationToken)
    {
        string query = $"SELECT * FROM BOOKS B WHERE B.first_name LIKE ('{authorName}')";
        var result = await _dbConnection.QueryAsync<Book>(query, cancellationToken);
        return result.FirstOrDefault();
    }

    public async Task<Book> GetBookByISBNAsync(long ISBN, CancellationToken cancellationToken)
    {
        string query = $"SELECT * FROM BOOKS B WHERE CONVERT(BIGINT, B.ISBN)= {ISBN}";
        var result = await _dbConnection.QueryAsync<Book>(query, cancellationToken);
        return result.FirstOrDefault();
    }

}
