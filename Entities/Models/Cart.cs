namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        /* Add Item */
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        /* Remove Item */
        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductId.Equals(product.ProductId));



        //Calculate Total
        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

        //Clear Cart
        public virtual void Clear() => Lines.Clear();
    }

}