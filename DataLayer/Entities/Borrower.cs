namespace DataLayer.Entities;

public class Borrower : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public string HomeAddress { get; set; }
    public ICollection<BorrowBook> BorrowBooks { get; set; }
}