using Xunit;

namespace IPValidation.Test
{
    public class CalculateIfIPAddressIsValidTest
    {
        [Theory]
        [InlineData("0.0.0.0", true)]
        [InlineData("12.255.56.1", true)]
        [InlineData("137.255.156.100", true)]
        public void IsValidIPTest1_Successful(string ipAddress, bool expected)
        {
            //Arrange
            ICalculateIfIPAddressIsValid calculateIfIPAddressIsValid = new CalculateIfIPAddressIsValid();

            //Act
            var actual = calculateIfIPAddressIsValid.is_valid_IP(ipAddress);

            //Assert

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("", false)]

        public void IsValidIPTest_ShouldReturnFalse_EmptyIP(string ipAddress, bool expected)
        {
            //Arrange
            ICalculateIfIPAddressIsValid calculateIfIPAddressIsValid = new CalculateIfIPAddressIsValid();

            //Act
            var actual = calculateIfIPAddressIsValid.is_valid_IP(ipAddress);

            //Assert

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("abc.def.ghi.jkl", false)]
        [InlineData("pr12.34.56.78", false)]
        [InlineData("12.34.56.78sf", false)]
        [InlineData("12.34.56 .1", false)]
        public void IsValidIPTest_ShouldReturnFalse_IPContainsNonDecimal(string ipAddress, bool expected)
        {
            //Arrange
            ICalculateIfIPAddressIsValid calculateIfIPAddressIsValid = new CalculateIfIPAddressIsValid();

            //Act
            var actual = calculateIfIPAddressIsValid.is_valid_IP(ipAddress);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("12.34.56", false)]
        [InlineData("12.34.56.7.8", false)]
        [InlineData("1234.34.56", false)]
        public void IsValidIPTest_ShouldReturnFalse_IPDoesntContainFourDigitsSeperatedByPeriod(string ipAddress, bool expected)
        {
            //Arrange
            ICalculateIfIPAddressIsValid calculateIfIPAddressIsValid = new CalculateIfIPAddressIsValid();

            //Act
            var actual = calculateIfIPAddressIsValid.is_valid_IP(ipAddress);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("123.456.789.0", false)]
        [InlineData("12.34.56.00", false)]
        [InlineData("123.045.067.089", false)]
        public void IsValidIPTest_ShouldReturnFalse_IPContainLeadingZeros(string ipAddress, bool expected)
        {
            //Arrange
            ICalculateIfIPAddressIsValid calculateIfIPAddressIsValid = new CalculateIfIPAddressIsValid();

            //Act
            var actual = calculateIfIPAddressIsValid.is_valid_IP(ipAddress);

            //Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("12.34.256.78", false)]
        [InlineData("12.34.56.-1", false)]
        public void IsValidIPTest_ShouldReturnFalse_InvalidIPNumber(string ipAddress, bool expected)
        {
            //Arrange
            ICalculateIfIPAddressIsValid calculateIfIPAddressIsValid = new CalculateIfIPAddressIsValid();

            //Act
            var actual = calculateIfIPAddressIsValid.is_valid_IP(ipAddress);

            //Assert

            Assert.Equal(expected, actual);
        }



    }
}
