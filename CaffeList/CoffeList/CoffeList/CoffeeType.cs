namespace CoffeeApp
{
    public class CoffeeType
    {
        public CoffeeType(string iD, string typ)
        {
            ID = iD;
            Typ = typ;
        }

        public string ID { get; set; }
        public string Typ { get; set; }
    }

}