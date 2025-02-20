using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSumAufgabe
{
    public class LuhnChecksumCalculator : ChecksumCalculator
    {

        public override bool Validate(string input)
        {
            int sum = 0;
            int[] tocheck = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                tocheck[i] = input[i] - '0';
            }

            for (int i = tocheck.Length - 2; i >= 0; i -= 2) //  Verdopplung 2.0 (von rechts)
            {
                tocheck[i] *= 2;

                if (tocheck[i] > 9)                         // Quersumme bei zweistellig
                    tocheck[i] = (tocheck[i] / 10) + (tocheck[i] % 10); 
            }

            foreach (int value in tocheck)
            {
                sum += value;
            }

            return sum % 10 == 0;                   //Rest 0?
        }



        public override int CalculateCheckDigit(string input)
        {
            int sum = 0;
            int[] tocheck = new int[input.Length + 1]; // Prüfziffer hier

            for (int i = 0; i < input.Length; i++)
            {
                tocheck[i] = input[i] - '0';
            }

            tocheck[input.Length] = 0; // Temporäre Prüfziffer = 0

            for (int i = tocheck.Length - 2; i >= 0; i -= 2) //  Verdopplung 2.0
            {
                tocheck[i] *= 2;

                if (tocheck[i] > 9)                         // Quersumme bei zweistellig
                    tocheck[i] = (tocheck[i] / 10) + (tocheck[i] % 10);
            }

            foreach (int value in tocheck)
            {
                sum += value;
            }

            return (10 - (sum % 10)) % 10; 
        }


    }
}

