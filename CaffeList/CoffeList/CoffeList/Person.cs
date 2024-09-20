
namespace CoffeeApp
{
    public class Person
    {
        public Person(string ID, string name)
        {
            ID = ID;
            Name = name;
        }

        public string ID { get; set; }
        public string Name { get; set; }

        
        public override string? ToString()
        {
            return ID + Name;
        }
    }
}