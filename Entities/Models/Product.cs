using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    //SOLID'e uygun olması için validation'u Dto'a bıraktık
    public String? ProductName { get; set; } = String.Empty;

    public int Price { get; set; }

    public int? CategoryId { get; set; }       //foreign key
    public Category? Category { get; set; } //navigation property

    public String? Summary { get; set; } = String.Empty;

    public String? ImageUrl { get; set; }


    public bool ShowCase { get; set; }
}
