namespace OOP
{
    public class Administrative
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Seller> Sellers { get; set; }

        public Administrative(string name, List<Customer> customers, List<Seller> sellers)
        {
            Name = name;
            Customers = customers;
            Sellers = sellers;
        }

        public void DisplayAllCustomers()
        {
            foreach (var customer in Customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public void DisplayAllSellers()
        {
            foreach (var seller in Sellers)
            {
                Console.WriteLine(seller.ToString());
            }
        }
    }
}
