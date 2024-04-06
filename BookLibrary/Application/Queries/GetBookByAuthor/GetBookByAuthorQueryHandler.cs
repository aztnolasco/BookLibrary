
using System.Threading;
using System.Threading.Tasks;
using Application.Shared.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.GetBookByAuthor;
public class GetBookByAuthorQueryHandler : IRequestHandler<GetBookByAuthorQuery, GetBookByAuthorQueryResult>
{
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<GetBookByAuthorQueryHandler> _logger;

    public GetBookByAuthorQueryHandler(IBookRepository bookRepository, ILogger<GetBookByAuthorQueryHandler> logger)
    {

        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<GetBookByAuthorQueryResult> Handle(GetBookByAuthorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var queryResult = new GetBookByAuthorQueryResult();

            var result = await _bookRepository.GetBookByAuthorAsync(request.AuthorName, cancellationToken);

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
