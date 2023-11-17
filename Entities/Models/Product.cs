using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "ProductName is Required")]
    public String? ProductName { get; set; } = String.Empty;
    [Required(ErrorMessage = "Price is Required")]
    public int Price { get; set; }
}
