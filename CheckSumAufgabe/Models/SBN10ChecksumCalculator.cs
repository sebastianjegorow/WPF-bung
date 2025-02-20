using System;

namespace CheckSumAufgabe
{
    public class ISBN10ChecksumCalculator : ChecksumCalculator
    {
        public override bool Validate(string input)
        {
            if (input.Length != 10) return false; // 10 Stellen?!

            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int digit;

                if (input[i] == 'X' && i == 9) // Umwandlung X = 10
                {
                    digit = 10;
                }
                else if (input[i] >= '0' && input[i] <= '9')
                {
                    digit = input[i] - '0'; // Zeichen in Zahl umwandeln
                }
                else
                {
                    return false; // ungültig
                }

                sum += (digit * (i + 1));
            }

            return (sum % 11 == 0);
        }

        public override int CalculateCheckDigit(string input)
        {
            if (input.Length != 9) return -1; // 9 Positionen?

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                if (input[i] < '0' || input[i] > '9') return -1; // Nur Zahlen erlaubt
                sum += (input[i] - '0') * (i + 1);
            }

            int checkDigit = sum % 11;

            return checkDigit; // X noch 10 Problem
        }
    }
}
