namespace OOP
{
    public class Product
    {
        private static int counter = 0;
        public int Parcode { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Productcategory { get; set; }
        public bool Specialpackage { get; private set; }

        public Product(string name, int price, Category productCategory)
        {
            Parcode = ++counter;
            Name = name;
            Price = price;
            Productcategory = productCategory;
            Specialpackage = false;
        }

        public void Makespecial()
        {
            Specialpackage = true;
        }

        public override string ToString()
        {
            return $"Parcode: {Parcode}, Product's name: {Name}, Product's price: {Price}, " +
                $"Product's category: {Productcategory}, Is it special packaged?: {Specialpackage}";
        }
    }
}