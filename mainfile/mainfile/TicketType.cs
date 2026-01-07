namespace mainfile;
using System.Text.Json.Serialization;

public class TicketType
{
    public string CategoryName { get; private set; }
    public decimal Price { get; private set; }
    public int MaxQuantity { get; private set; } // Stoc total
    public int SoldCount { get; private set; } // Câte s-au vândut

    [JsonConstructor]
    public TicketType(string CategoryName, decimal Price, int MaxQuantity, int SoldCount = 0)
    {
        this.CategoryName = CategoryName;
        this.Price = Price;
        this.MaxQuantity = MaxQuantity;
        this.SoldCount = SoldCount;
    }

    // Proprietate care verifică rapid dacă mai sunt locuri
    public bool IsAvailable
    {
        get
        {
            return SoldCount < MaxQuantity;
        }
    }

    // Metoda apelată la cumpărare
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
    public void DecrementSales()// scadere vanzari
    {
        if (SoldCount > 0)
        {
            SoldCount--;
        }
    }
}