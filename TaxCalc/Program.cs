namespace TAXCalculator
{
    public class Program
    {
        static Dictionary<string, double> euCountryTaxRates = new Dictionary<string, double>
        {
            { "lithuania", 0.21 },
            { "poland", 0.23 },
            { "germany", 0.19 },
            { "france", 0.20 },
            { "italy", 0.22 },
            { "austria", 0.20 },
            { "sweden", 0.25 },
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

        static Dictionary<string, double> nonEuCountryTaxRates = new Dictionary<string, double>
        {
            { "norway", 0.25 },
            { "switzerland", 0.077 },
            { "iceland", 0.24 },
            { "uk", 0.20 },
            { "russia", 0.20 },
            { "turkey", 0.18 },
            { "usa", 0.0 },
            { "canada", 0.05 },
            { "australia", 0.10 },
            { "japan", 0.10 }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the price you want to add tax to: ");
            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("List of countries:");
            DisplayCountryList();

            Console.WriteLine("\nEnter the seller country:");
            var seller_country = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the buyer country:");
            var buyer_country = Console.ReadLine().ToLower();

            var vatRate = CalculateTaxRate(seller_country, buyer_country);

            var totalTax = price * vatRate;
            var totalPrice = price + totalTax;

            Console.WriteLine($"\nPrice: {price}");
            Console.WriteLine($"Tax ({seller_country} to {buyer_country}): {totalTax}");
            Console.WriteLine($"Total price: {totalPrice}");
        }

        public static void DisplayCountryList()
        {
            foreach (var country in euCountryTaxRates.Keys)
            {
                Console.WriteLine(country);
            }
            foreach (var country in nonEuCountryTaxRates.Keys)
            {
                Console.WriteLine(country);
            }
        }

        public static double CalculateTaxRate(string seller_country, string buyer_country)
        {
            double taxRate = 0.0;

            if (seller_country == buyer_country)
            {
                if (euCountryTaxRates.ContainsKey(buyer_country))
                {
                    taxRate = euCountryTaxRates[buyer_country];
                }
                else if (nonEuCountryTaxRates.ContainsKey(buyer_country))
                {
                    taxRate = nonEuCountryTaxRates[buyer_country];
                }
            }
            else if (euCountryTaxRates.ContainsKey(seller_country))
            {
                taxRate = euCountryTaxRates[seller_country];
            }

            return taxRate;
        }
    }
}
