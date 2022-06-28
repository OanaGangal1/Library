namespace DataLayer.Entities;

public class Book : BaseEntity
{
    
    public string Name { get; set; }
    public string Isbn { get; set; }
    public decimal RentalPrice { get; set; }
    public ICollection<BorrowBook> BorrowBooks { get; set; } = new HashSet<BorrowBook>();

    public Book()
    {
        var isbn = new List<int>
        {
            978,
            (new Random()).Next(0, 9),
            (new Random()).Next(10, 99),
            (new Random()).Next(100000, 999999),
            (new Random()).Next(0, 9)
        };

       isbn.ForEach(x => Isbn += x + "-");
       Isbn = Isbn.Remove(Isbn.LastIndexOf("-", StringComparison.Ordinal));
    }

    public static bool operator ==(Book left, Book right)
    {
        if (left is null)
            return right is null;

        if (right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Book left, Book right)
    {
        return !(left == right);
    }

    public override bool Equals(Object obj)
    {
        if (!this.GetType().Equals(obj.GetType()))
            return false;

        var book = (Book)obj;

        return this.Isbn == book.Isbn
        && this.RentalPrice == book.RentalPrice
        && this.Name == book.Name;
    }
}