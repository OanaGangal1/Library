using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public class Borrower : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [NotMapped] public string FullName => $"{FirstName} {LastName}";
    public string IdentityNumber { get; set; }
    public string HomeAddress { get; set; }
    public ICollection<BorrowBook> BorrowBooks { get; set; } = new HashSet<BorrowBook>();

}