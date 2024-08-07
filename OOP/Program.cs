

namespace OOP
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Seller> sellers = new List<Seller>();

        static void Main(string[] args)
        {
            /* Yazan Watad 314635863
               Yusif Masarweh 206659187 */

            while (true)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a customer");
                Console.WriteLine("2. Add a seller");
                Console.WriteLine("3. Add a product to a seller");
                Console.WriteLine("4. Add a product to a customer's cart");
                Console.WriteLine("5. Make payment");
                Console.WriteLine("6. Display all sellers info");
                Console.WriteLine("7. Display all customers info");
                Console.WriteLine("9. Create a new cart from order history");
                Console.WriteLine("10. Exit");
                int option;
                try
                {
                    option = int.Parse(Console.ReadLine());
                    if (option < 1 || option > 10)
                    {
                        throw new ArgumentOutOfRangeException("Option", "Please enter a number between 1 and 8.");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Input error: {ex.Message}. Please enter a valid number.");
                    continue;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    continue;
                }

                try
                {
                    switch (option)
                    {
                        case 1:
                            AddCustomer();
                            break;
                        case 2:
                            AddSeller();
                            break;
                        case 3:
                            AddProductToSeller();
                            break;
                        case 4:
                            AddProductToCustomerCart();
                            break;
                        case 5:
                            MakePayment();
                            break;
                        case 6:
                            DisplaySellersInfo();
                            break;
                        case 7:
                            DisplayCustomersInfo();
                            break;
                        case 8:
                            CompareCustomers();
                            break;
                        case 9:
                            GetOrderFromHistory();
                            break;
                        case 10:
                            return;
                    }
                }
                catch (OrderException ex)
                {
                    Console.WriteLine($"Order error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}. Source: {ex.Source}");
                }
            }
        }


        static void AddCustomer()
        {
            
            try
            {
                Console.WriteLine("Enter customer name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter customer password: ");
                int password = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter customer street:");
                string street = Console.ReadLine();

                Console.WriteLine("Enter customer building number:");
                int building = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter customer city:");
                string city = Console.ReadLine();

                Console.WriteLine("Enter customer country:");
                string country = Console.ReadLine();

                Address address = new Address(street, building, city, country);
                Customer customer = new Customer(name, password, address);
                customers = customers + customer;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}. Source: {ex.Source}");
            }
        }

        static void AddSeller()
        {
          
          
            try
            {
                Console.WriteLine("Enter seller name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter seller password:");
                int password = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter seller street:");
                string street = Console.ReadLine();

                Console.WriteLine("Enter seller's building number:");
                int building = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter seller city:");
                string city = Console.ReadLine();

                Console.WriteLine("Enter seller country:");
                string country = Console.ReadLine();

                Address address = new Address(street, building, city, country);
                Seller seller = new Seller(name, password, address);
                sellers = sellers + seller; 
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}. Source: {ex.Source}");
            }
           
        }

        static void AddProductToSeller()
        {
            try
            {
                Console.WriteLine("Enter seller name:");
                string sel = Console.ReadLine();
                Seller seller = sellers.FirstOrDefault(s => s.Name == sel);
                if (seller == null)
                {
                    Console.WriteLine("Seller not found.");
                    return;
                }

                Console.WriteLine("Enter product name:");
                string prod = Console.ReadLine();

                Console.WriteLine("Enter product price:");
                int price = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product category's name (Kids, Office, Electrical, Clothing):");
                string categoryname = Console.ReadLine();
                if (!Enum.TryParse(categoryname, true, out ProductCategory categoryEnum))
                {
                    Console.WriteLine("Invalid category. Please enter one of these: Kids, Office, Electrical, Clothing.");
                    return;
                }

                Category category = new Category(categoryname, (int)categoryEnum);
                seller.AddProduct(prod, price, category);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}. Please enter a valid number.");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}.Make sure u'r choosing the right objects");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An  error occurred: {ex.Message}. Source: {ex.Source}");
            }
        }

        static void AddProductToCustomerCart()
        {
            try
            {
                Console.WriteLine("Enter customer name:");
                string cus = Console.ReadLine();
                Customer customer = customers.FirstOrDefault(c => c.Name == cus);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                Console.WriteLine("Enter seller name:");
                string sellername = Console.ReadLine();
                Seller seller = sellers.FirstOrDefault(s => s.Name == sellername);
                if (seller == null)
                {
                    Console.WriteLine("Seller not found.");
                    return;
                }

                Console.WriteLine("Enter product name:");
                string prod = Console.ReadLine();
                Product product = seller.Products.FirstOrDefault(p => p.Name == prod);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                customer.MakeOrder(seller, product);
            }
            catch (OrderException ex)
            {
                Console.WriteLine($"Order error: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}.Make sure u'r choosing the right objects");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}. Source: {ex.Source}");
            }
        }


        static void MakePayment()
        {
            try
            {
                Console.WriteLine("Enter customer name:");
                string cus = Console.ReadLine();
                Customer customer = customers.FirstOrDefault(c => c.Name == cus);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

            
                if (customer.Orders.Count == 1)
                {
                    throw new OrderException();
                }

                int sum = customer.Orders.Sum(order => order.Lastprice);
                Console.WriteLine($"Amount to pay is: {sum}");
            }
            catch (OrderException ex)
            {
                Console.WriteLine($"Payment error: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}. please make sure of the objects");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}. Source: {ex.Source}");
            }

        }
        static void DisplaySellersInfo()
        {
            try
            {
                Administrative admin = new Administrative("Store", customers, sellers);
                var sortedSellers = admin.Sellers.OrderByDescending(s => s.GetCount()).ToList();

                foreach (var seller in sortedSellers)
                {
                    Console.WriteLine($"{seller.Name} - Items Sold: {seller.GetCount()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}. Source: {ex.Source}");
            }
        }
        static void CompareCustomers()
        {
            try
            {
                Console.WriteLine("Enter the name of the first customer:");
                string name1= Console.ReadLine();
                Customer customer1 = customers.FirstOrDefault(c => c.Name == name1);
                if (customer1 == null)
                {
                    Console.WriteLine("First customer not found.");
                    return;
                }

                Console.WriteLine("Enter the name of the second customer:");
                string name2 = Console.ReadLine();
                Customer customer2 = customers.FirstOrDefault(c => c.Name == name2);
                if (customer2 == null)
                {
                    Console.WriteLine("Second customer not found.");
                    return;
                }

                if (customer1 < customer2)
                {
                    Console.WriteLine($"{name1}'s cart total is less than {name2}'s cart total.");
                }
                else if (customer1 > customer2)
                {
                    Console.WriteLine($"{name1}'s cart total is greater than {name2}'s cart total.");
                }
                else
                {
                    Console.WriteLine($"{name1} and {name2} have the same cart total.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during comparison: {ex.Message}");
            }
        }
        static void GetOrderFromHistory()
        {
            try
            {
                Console.WriteLine("Enter customer name:");
                string cusName = Console.ReadLine();
                Customer customer = customers.FirstOrDefault(c => c.Name == cusName);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                if (customer.Orders.Count == 0)
                {
                    Console.WriteLine("This customer has no orders in history.");
                    return;
                }

                Console.WriteLine("Select an order to clone:");
                for (int i = 0; i < customer.Orders.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {customer.Orders[i].Product.Name} - Price: {customer.Orders[i].Lastprice}");
                }

                Console.WriteLine("Enter the order number to clone:");
                int orderNumber = int.Parse(Console.ReadLine()) - 1;

                customer.CloneOrder(orderNumber);
                Console.WriteLine("Order successfully cloned to new cart.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}. Please enter a valid number.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Selection error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}. Source: {ex.Source}");
            }
        }

        static void DisplayCustomersInfo()
        {
            try
            {
                Administrative admin = new Administrative("Store", customers, sellers);
                admin.DisplayAllCustomers();
            }
            catch (Exception ex)    
            {
                Console.WriteLine($"An error occurred: {ex.Message}. Source: {ex.Source}");
            }
        }
    }
}