using Application.Queries.GetBookByAuthor;
using Application.Queries.GetBookByISBN;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private readonly IMediator _mediator;
    public ApiController(ILogger<ApiController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("GetBookByISBN")]
    public async Task<IActionResult> GetBookByISBN(long ISBN, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBookByISBNQuery
        {
            ISBN = ISBN
        }, cancellationToken);

        _logger.LogInformation("Searching Book");

        if(result == null) return Ok("Book not found");

        return Ok(result.Book);
    }

    [HttpGet("GetBookByAuthor")]
    public async Task<IActionResult> GetBookByAuthor(string authorName, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetBookByAuthorQuery
        {
            AuthorName = authorName
        }, cancellationToken);

        _logger.LogInformation("Searching Book");

        if(result == null) return Ok("Book not found");

        return Ok(result.Book);
    }

    
}
}