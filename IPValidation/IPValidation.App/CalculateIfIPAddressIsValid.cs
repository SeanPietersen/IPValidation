using System;
using System.Text.RegularExpressions;

namespace IPValidation.App
{
    public class CalculateIfIPAddressIsValid : ICalculateIfIPAddressIsValid
    {
        public bool is_valid_IP(string ipAddres)
        {
            if(!String.IsNullOrEmpty(ipAddres))
            {
                string[] seperatedString = ipAddres.Split(".");
                if(seperatedString.Length == 4)
                {
                    Regex regex = new Regex(@"\D");
                    foreach (var number in seperatedString)
                    {
                        if (String.IsNullOrEmpty(number))
                        {
                            return false;
                        }
                        char[] digit = number.ToCharArray();
                        if(regex.IsMatch(number))
                        {
                            return false;
                        }
                        if(Char.GetNumericValue(digit[0]) == 0 && !(digit.Length == 1))
                        {
                            return false;
                        }
                        if(Int32.Parse(number) > 255 || Int32.Parse(number) < 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}

