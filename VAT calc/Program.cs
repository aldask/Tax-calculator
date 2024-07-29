namespace VAT_calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rates = new Dictionary<string, double>
            {
                { "lithuania", 0.21 },
                { "poland", 0.23 },
                { "germany", 0.19 },
                { "france", 0.20 },
                { "italy", 0.22 },
                { "austria", 0.20 },
                { "sweden", 0.25 },
                { "norway", 0.25 },
                { "denmark", 0.25 },
                { "finland", 0.24 },
                { "ireland", 0.23 },
                { "portugal", 0.23 },
                { "greece", 0.24 },
                { "hungary", 0.27 },
                { "czech republic", 0.21 },
                { "slovakia", 0.20 },
                { "croatia", 0.25 }
            };

            Console.WriteLine("Enter the amount you want to add Tax: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the country you want to calculate VAT for: ");
            string country = Console.ReadLine().ToLower();

            if (!rates.ContainsKey(country))
            {
                Console.WriteLine("There is no such country in the list");
                return;
            }

            double finalPrice = rates[country];

            double vatAmount = amount * finalPrice;
            double totalAmount = amount + vatAmount;

            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"VAT ({country}): {vatAmount}");
            Console.WriteLine($"Total Amount: {totalAmount}");
        }
    }
}
