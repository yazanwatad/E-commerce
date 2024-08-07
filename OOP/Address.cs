namespace OOP
{
    public class Address
    {
        public string Street { get; set; }
        public int Building { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(string street, int building, string city, string country)
        {
            Street = street;
            Building = building;
            City = city;
            Country = country;
        }

        public override string ToString()
        {
            return $"Street: {Street}, Building: {Building}, City: {City}, Country: {Country}";
        }
    }
}