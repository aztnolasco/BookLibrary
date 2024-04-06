using Application.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Repositories.Contexts;

public class BookContext : DbContext
{
    public virtual DbSet<Book> Books { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options) {}
}
