using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Services
{
    public static class Converter
    {
        public static double ConvertStringToDouble(string number)
        {
            if(number.Contains("."))
            {
                NumberFormatInfo numberFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = "."
                };
                return Convert.ToDouble(number, numberFormatInfo);
            }
            return double.Parse(number);
        }
    }
}
