using System;

namespace CheckSumAufgabe
{
    public class ChecksumFactory
    {
        public ChecksumCalculator GetCalculator(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new Exception("Algotyp leer.");

            switch (type.ToLower())
            {
                case "luhn":
                    return new LuhnChecksumCalculator();
                case "isbn10":
                    return new ISBN10ChecksumCalculator();
                case "isbn13":
                    return new ISBN13ChecksumCalculator();
                default:
                    throw new Exception("Algo unbekannt!!!");
            }
        }
    }
}
