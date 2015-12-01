using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatlogue
{
    class Phone
    {
        string number;        

        public Phone(string number)
        {
            this.number = number;
        }

        public string ReturnPhone()
        {
            return number;
        }

        public bool CompareNumbers(string number)
        {
            return this.number == number ? true : false;
        }

        public Phone Copy()
        {
            return new Phone(number);
        }
    }
}
