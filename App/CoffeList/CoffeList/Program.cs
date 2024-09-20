using CoffeeApp;

namespace CoffeeList
{
    internal static class Program
    {
    
        [STAThread]
        static void Main()
        {
         
           
            ApplicationConfiguration.Initialize();

         
            Application.Run(new Form1());
        }
    }
}
