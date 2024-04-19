using MediatR;
namespace Application.Queries.GetBookByISBN;

public class GetBookByISBNQuery : IRequest<GetBookByISBNQueryResult>
{
    public long ISBN { get; set; }
}
