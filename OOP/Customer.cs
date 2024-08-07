namespace OOP
{
    public class Customer : Person, ICartClonable
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public void CloneOrder(int orderIndex)
        {
            if (orderIndex < 0 || orderIndex >= Orders.Count)
            {
                throw new IndexOutOfRangeException("Invalid order index.");
            }

            Order originalOrder = Orders[orderIndex];
            Order clonedOrder = new Order(originalOrder.Product, this, originalOrder.Seller);
            Orders.Add(clonedOrder);
        }

        public Customer(string name, int password, Address address)
            : base(name, password, address)
        {
        }

        public void MakeOrder(Seller seller, Product product)
        {
            if (Orders.Count == 1)
            {
                throw new OrderException();
            }
            Orders.Add(new Order(product, this, seller));
        }
        public static bool operator <(Customer cus1, Customer cus2)
        {
            return cus1.Orders.Sum(order => order.Lastprice) < cus2.Orders.Sum(order => order.Lastprice);
        }

        public static bool operator >(Customer cus1, Customer cus2)
        {
            return cus1.Orders.Sum(order => order.Lastprice) > cus2.Orders.Sum(order => order.Lastprice);
        }


        public static List<Customer> operator +(List<Customer> customers, Customer customer)
        {
            customers.Add(customer);
            return customers;
        }

        public override string ToString()
        {
            if (!Orders.Any())
            {
                return $"{base.ToString()}\nNo orders yet";
            }

            var orderInfo = string.Join("\n", Orders.Select(o => o.ToString()));
            return $"{base.ToString()}\nOrders:\n{orderInfo}";
        }
    }
}
