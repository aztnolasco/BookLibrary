
using Application.Queries.GetBookByISBN;
using Application.Shared.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.GetBookByAuthor;
public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, GetBookByISBNQueryResult>
{
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<GetBookByISBNQueryHandler> _logger;

    public GetBookByISBNQueryHandler(IBookRepository bookRepository, ILogger<GetBookByISBNQueryHandler> logger)
    {

        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<GetBookByISBNQueryResult> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var queryResult = new GetBookByISBNQueryResult();

            var result = await _bookRepository.GetBookByISBNAsync(request.ISBN, cancellationToken);

            queryResult.Book = result;

            return queryResult;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when getting book: {ex.Message}");
            throw;
        }
    }

}
