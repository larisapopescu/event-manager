
namespace mainfile;
using System.Text.Json.Serialization;

public class TicketType
{
    public string CategoryName { get; private set; }
    public decimal Price { get; private set; }
    public int MaxQuantity { get; private set; }
    public int SoldCount { get; private set; }

    [JsonConstructor]
    public TicketType(string categoryName, decimal price, int maxQuantity, int soldCount = 0)
    {
        CategoryName = categoryName;
        Price = price;
        MaxQuantity = maxQuantity;
        SoldCount = soldCount;
    }

    public bool isAvailable
    {
        get
        {
            return SoldCount < MaxQuantity;
        }
    }

    public void IncrementSales()
    {
        if (isAvailable)
        {
            SoldCount++;
        }
        else
        {
            throw new Exception("All tickets are sold");
        }
    }
}