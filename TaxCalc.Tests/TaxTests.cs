using TAXCalculator;

namespace TaxCalc.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("lithuania", "lithuania", 0.21)]
        [TestCase("norway", "norway", 0.25)]
        [TestCase("baram", "baram", 0.0)]
        [TestCase("lithuania", "norway", 0.21)]
        [TestCase("baram", "lithuania", 0.0)]
        [TestCase("baram", "taram", 0.0)]
        [TestCase("germany", "uk", 0.19)]
        [TestCase("uk", "germany", 0.0)]
        public void Test_GetVatRate(string seller_ountry, string buyer_ountry, double expectation)
        {
            var taxRate = Program.CalculateTaxRate(seller_ountry, buyer_ountry);

            Assert.That(taxRate, Is.EqualTo(expectation));
        }
    }
}