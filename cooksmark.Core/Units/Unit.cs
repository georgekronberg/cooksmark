using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cooksmark.Core.Units
{
    public class Unit
    {
        public UnitName Name { get; set; }
        public decimal Value { get; set; }
    }

    public enum UnitName
    {
        Liter,
        Quart,
        Tablespoon,
        Teaspoon,
        Cup,
        Gallon,
        Pint,
        Mililiter,
        Ounce
    }

    public enum UnitType
    {
        Volume,
        Weight
    }
}
