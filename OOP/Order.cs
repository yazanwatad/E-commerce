namespace OOP
{
    public class Order
    {
        public Product Product { get; set; }
        public int Lastprice { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }

        public Order(Product product, Customer customer, Seller seller)
        {
            Product = product;
            Lastprice = product.Price;
            Customer = customer;
            Seller = seller;
        }

        public override string ToString()
        {
            return $"Product: {Product}, Last price is: {Lastprice}";
        }
    }
}
