using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSumAufgabe
{
    interface IChecksumCalculator
    {
       bool Validate(string input); // Prüfung einer Nummer

       int CalculateCheckDigit(string input); // berechnet eine Prüfziffer
    }
}
