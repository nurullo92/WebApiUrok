using EF_Urok.Model;

public class Borrowin
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public DateTime DataTaken { get; set; }
    public DateTime? DateReturned { get; set; }
}