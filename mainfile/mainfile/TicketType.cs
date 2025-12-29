
namespace mainfile;
using System.Text.Json.Serialization;

public class TicketType
{
    public string CategoryName { get; private set; }
    public decimal Price { get; private set; }
    public int MaxQuantity { get; private set; }
    public int SoldCount { get; private set; }

    [JsonConstructor]
    public TicketType(string CategoryName, decimal Price, int MaxQuantity, int SoldCount = 0)
    {
        this.CategoryName = CategoryName;
        this.Price = Price;
        this.MaxQuantity = MaxQuantity;
        this.SoldCount = SoldCount;
    }

    public bool IsAvailable
    {
        get
        {
            return SoldCount < MaxQuantity;
        }
    }

    public void IncrementSales()
    {
        if (IsAvailable)
        {
            SoldCount++;
        }
        else
        {
            throw new Exception("All tickets are sold");
        }
    }
}