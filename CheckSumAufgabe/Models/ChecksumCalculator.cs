using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSumAufgabe
{
    public abstract class ChecksumCalculator : IChecksumCalculator
    {


        public virtual bool IsNumeric(string input)
        {
           //hm..
            return true;
        }
        public abstract bool Validate(string input); 

        public abstract int CalculateCheckDigit(string input); 



    }

    
}
