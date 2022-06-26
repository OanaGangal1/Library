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
            [0] = 978,
            [1] = (new Random()).Next(0, 9),
            [2] = (new Random()).Next(10, 99),
            [3] = (new Random()).Next(100000, 999999),
            [4] = (new Random()).Next(0, 9)
        };

       isbn.ForEach(x => Isbn += x + "-");
       Isbn = Isbn.Remove(Isbn.LastIndexOf("-", StringComparison.Ordinal));
    }
}