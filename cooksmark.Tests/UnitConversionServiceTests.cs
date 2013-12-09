using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cooksmark.Core.Units;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace cooksmark.Tests
{
    public class UnitConversionServiceTests
    {
        private readonly UnitConversionService _sut;
        public UnitConversionServiceTests()
        {
            _sut = new UnitConversionService();
        }

        [Theory]
        [InlineData(UnitName.Liter, UnitName.Quart, 1.05669)]
        [InlineData(UnitName.Quart, UnitName.Liter, 0.94635)]
        [InlineData(UnitName.Liter, UnitName.Ounce, 33.814)]
        public void ShouldConvertUnits(UnitName unitFromName, UnitName unitToName, double expected)
        {
            var unitFrom = new Unit {Name = unitFromName, Value = 1};
            var unitTo = new Unit {Name = unitToName, Value = 1};

            var actual = _sut.GetConvertionRate(unitFrom, unitTo);

            Math.Abs((decimal)expected - actual).Should().BeLessOrEqualTo(0.001m, "expected: {0}, actual: {1}", new object[] { expected, actual.ToString(CultureInfo.InvariantCulture) });
        }
    }
}
