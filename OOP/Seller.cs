namespace OOP
{
    public class Seller : Person, IInventoryCount
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int GetCount()
        {
            return Products.Count;
        }
        public Seller(string name, int password, Address address)
            : base(name, password, address)
        {
        }

        public void AddProduct(string name, int price, Category category)
        {
            Products.Add(new Product(name, price, category));
        }

        public void MakeProductSpecial(int parcode)
        {
            var product = Products.FirstOrDefault(p => p.Parcode == parcode);
            if (product != null)
            {
                product.Makespecial();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static List<Seller> operator +(List<Seller> sellers, Seller seller)
        {
            sellers.Add(seller);
            return sellers;
        }

        public override string ToString()
        {
            if (!Products.Any())
            {
                return $"{base.ToString()}\nNo products yet";
            }

            var productInfo = string.Join("\n", Products.Select(p => p.ToString()));
            return $"{base.ToString()}\nProducts:\n{productInfo}";
        }
    }
}