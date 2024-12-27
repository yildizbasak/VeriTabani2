using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Order : BaseEntity
{
    public int ProductId { get; set; }
    [JsonIgnore]
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}
