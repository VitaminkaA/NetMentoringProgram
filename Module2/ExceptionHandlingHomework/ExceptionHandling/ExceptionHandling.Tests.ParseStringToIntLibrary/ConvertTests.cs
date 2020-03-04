using System;
using Xunit;
using ExceptionHandling.ParseStringToIntLibrary;

namespace ExceptionHandling.Tests.ParseStringToIntLibrary
{
    public class ConvertTests
    {
        [Fact]
        public void StringToInt_StringIsNull_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.StringToInt(null));
            Assert.Equal("The entered string cannot be null, empty or white space.", exception.Message);
        }

        [Fact]
        public void StringToInt_StringIsEmpty_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.StringToInt(""));
            Assert.Equal("The entered string cannot be null, empty or white space.", exception.Message);
        }

        [Fact]
        public void StringToInt_StringIsWhiteSpace_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.StringToInt("   "));
            Assert.Equal("The entered string cannot be null, empty or white space.", exception.Message);
        }

        [Fact]
        public void StringToInt_3_3()
        {
            // Arrange
            const int exp = 3;

            // Act
            var res = Converter.StringToInt($"{exp}");

            // Assert
            Assert.True(res == exp);
        }

        [Fact]
        public void StringToInt_Negative4545_Negative4545()
        {
            // Arrange
            const int exp = -4545;

            // Act
            var res = Converter.StringToInt($"{exp}");

            // Assert
            Assert.True(res == exp);
        }

        [Fact]
        public void StringToInt_0_0()
        {
            // Arrange
            const int exp = 0;

            // Act
            var res = Converter.StringToInt($"{exp}");

            // Assert
            Assert.True(res == exp);
        }

        [Fact]
        public void StringToInt_SpaceNegative123Space_Negative123()
        {
            // Arrange
            const int exp = -123;

            // Act
            var res = Converter.StringToInt($"   {exp} ");

            // Assert
            Assert.True(res == exp);
        }
        [Fact]
        public void StringToInt_Space0Space_0()
        {
            // Arrange
            const int exp = 0;

            // Act
            var res = Converter.StringToInt($" 0 ");

            // Assert
            Assert.True(res == exp);
        }

        [Fact]
        public void StringToInt_Negative0_0()
        {
            // Arrange
            const int exp = 0;

            // Act
            var res = Converter.StringToInt($"-0");

            // Assert
            Assert.True(res == exp);
        }

        [Fact]
        public void StringToInt_012345_123456()
        {
            // Arrange
            const int exp = 0123456;

            // Act
            var res = Converter.StringToInt($"{exp}");

            // Assert
            Assert.True(res == exp);
        }

        [Fact]
        public void StringToInt_12Space3_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.StringToInt("12 3"));
            Assert.Equal("Character is not a number", exception.Message);
        }

        [Fact]
        public void StringToInt_12SomeSpace3_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(() => Converter.StringToInt("12     3"));
            Assert.Equal("Character is not a number", exception.Message);
        }

        [Fact]
        public void StringToInt_9898989898989898989_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(()
                => Converter.StringToInt("9898989898989898989"));
            Assert.Equal("Value was either too large or too small for an Int32.", exception.Message);
        }

        [Fact]
        public void StringToInt_123Gg87_ArgumentException()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<ArgumentException>(()
                => Converter.StringToInt("123Gg87"));
            Assert.Equal("Character is not a number", exception.Message);
        }
    }
}
