using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cooksmark.Core.Units
{
    public class UnitConversionService
    {
        private readonly Dictionary<UnitName, UnitType> _unitsDictionary;

        private readonly Dictionary<UnitName, decimal> _convertionDictionary;
        //2.95735e-5
        public UnitConversionService()
        {
            _unitsDictionary = new Dictionary<UnitName, UnitType>
            {
                {UnitName.Liter, UnitType.Volume},
                {UnitName.Quart, UnitType.Volume}
            };

            _convertionDictionary = new Dictionary<UnitName, decimal>
            {
                {UnitName.Liter, 0.001m},
                {UnitName.Quart, 0.000946353m}
            };
        }
        public decimal GetConvertionRate(Unit unitFrom, Unit unitTo)
        {
            if (_unitsDictionary[unitFrom.Name] == _unitsDictionary[unitTo.Name])
            {
                var unitFromRatio = _convertionDictionary[unitFrom.Name];
                var unitToRatio = _convertionDictionary[unitTo.Name];
                return unitFromRatio/unitToRatio;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
