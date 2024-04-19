using System.ComponentModel.DataAnnotations.Schema;
using Application.Shared.Models.Enums;

namespace Application.Shared.Models;

[Table("BOOKS")]
public class Book
{
    [Column("book_id")]
    public long Id { get; set;}

    [Column("title")]
    public string Title { get; set; }

    [Column("first_name")]
    public String FirstName { get; set; }

    [Column("last_name")]
    public String LastName { get; set; }

    [Column("type")]
    public TypeEnum Type { get; set;}

    [Column("isbn")]
    public string ISBN { get; set; }

    [Column("category")]
    public CategoryEnum Category {get; set;}

    [Column("total_copies")]
    public int TotalCopies { get; set; }

    [Column("copies_in_use")]
    public int AvailableCopies { get; set; }
}
