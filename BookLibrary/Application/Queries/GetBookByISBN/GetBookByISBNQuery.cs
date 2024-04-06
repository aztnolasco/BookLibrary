using MediatR;
namespace Application.Queries.GetBookByISBN;

public class GetBookByISBNQuery : IRequest<GetBookByISBNQueryResult>
{
    public string ISBN { get; set; }
}
