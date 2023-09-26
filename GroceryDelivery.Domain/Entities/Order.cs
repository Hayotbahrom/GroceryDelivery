using GroceryDelivery.Domain.Commons;

namespace GroceryDelivery.Domain.Entities;

public class Order:Auditable
{
    public long ProductId { get; set; }
    public long CustomerId { get; set; }
    public long DriverId { get; set; }
    public string Location { get; set; }
    public DateTime DeliveryTime { get; set; } = DateTime.UtcNow;
    public string TotalAmount { get; set; }
    public string TotalFee { get; set; }
}
