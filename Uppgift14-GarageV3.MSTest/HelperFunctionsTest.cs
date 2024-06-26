using Uppgift14_GarageV3.Helpers;

namespace Uppgift14_GarageV3.MSTest
{
    [TestClass]
    public class HelperFunctionsTest
    {
        [TestMethod]
        public void ParkedTimeAmount_ShouldReturn_Ninetyfiveminutes()
        {
            // Arrange
            DateTime arrivalTime = new DateTime(2024, 04, 17, 12, 0, 0);
            DateTime departureTime = new DateTime(2024, 04, 17, 13, 35, 0);

            TimeSpan expected = new TimeSpan(1, 35, 0);

            // Act
            var actual = HelperFunctions.ParkedTimeAmount(arrivalTime, departureTime);

            // Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void CostCalculation_ShouldReturn_Near_18_99()
        {
            // Arrange
            DateTime arrivalTime = new DateTime(2024, 04, 17, 12, 0, 0);
            DateTime departureTime = new DateTime(2024, 04, 17, 13, 35, 0);

            decimal pricePerHour = 12.0m;

            decimal expected = 1.583m * pricePerHour;

            // Act
            var actual = HelperFunctions.CostCalculation(HelperFunctions.ParkedTimeAmount(arrivalTime, departureTime), pricePerHour);

            Assert.AreEqual(expected, actual, 0.01m); // Delta value 0,01 to allow for minor rounding differences
        }


        [TestMethod]
        public void ParkedTimeAmount_ShouldReturn_Exception()
        {
            // Arrange
            DateTime arrivalTime = new DateTime(2024, 04, 17, 13, 35, 0);
            DateTime departureTime = new DateTime(2024, 04, 17, 12, 0, 0);

            // Act

            // Assert
            Assert.ThrowsException<System.ArgumentException>(() => HelperFunctions.ParkedTimeAmount(arrivalTime, departureTime) );
        }

    }
}