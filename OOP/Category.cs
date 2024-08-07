namespace OOP
{
    public class Category
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public Category() { }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"Category Name: {Name}, Category Code: {Code}";
        }
    }
}