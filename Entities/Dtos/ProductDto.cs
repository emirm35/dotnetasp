using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{

    //Record tipleri immutabledir
    public record ProductDto
    {

        //validation işlemlerini şimdilik dto'a aktardık

        //Proplarda set olursa record type'ın immetuable olması sağlanamaz 
        //bu yüzden setleri init ile değiştir
        public int ProductId { get; init; }
        [Required(ErrorMessage = "ProductName is Required")]
        public String? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Price is Required")]
        public int Price { get; init; }

        public int? CategoryId { get; init; }
        public String? Summary { get; init; } = String.Empty;

        public String? ImageUrl { get; set; }

    }
}