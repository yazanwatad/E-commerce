namespace OOP
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Password { get; set; }
        public Address Address { get; set; }

        protected Person(string name, int password, Address address)
        {
            Name = name;
            Password = password;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Password: {Password}, Address: {Address}";
        }
    }
}
