using System;

namespace CheckSumAufgabe
{
    public class ISBN13ChecksumCalculator : ChecksumCalculator
    {
        public override bool Validate(string input)
        {
            if (input.Length != 13) return false; // 13 Stellen?

            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                if (input[i] < '0' || input[i] > '9') return false; // Zahlen?!

                int digit = input[i] - '0';
                int weight = (i % 2 == 0) ? 1 : 3; // Gewicht abwechselnd 1 und 3
                sum += digit * weight;
            }

            int checkDigit = (10 - (sum % 10)) % 10; // Prüfziffer berechnen

            return (checkDigit == (input[12] - '0')); // Prüfziffer vergleichen
        }

        public override int CalculateCheckDigit(string input)
        {
            if (input.Length != 12) return -1; // 12 Zahlen (ohne Prüfziffer)?

            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                if (input[i] < '0' || input[i] > '9') return -1; // Nur Zahlen?

                int digit = input[i] - '0';
                int weight = (i % 2 == 0) ? 1 : 3; // Gewicht abwechselnd 1 und 3
                sum += digit * weight;
            }

            return (10 - (sum % 10)) % 10; // Prüfziffer berechnen
        }
    }
}
