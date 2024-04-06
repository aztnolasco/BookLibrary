using MediatR;

namespace Application.Queries.GetBookByAuthor;

public class GetBookByAuthorQuery : IRequest<GetBookByAuthorQueryResult>
{
    public string AuthorName { get; set; }
}
