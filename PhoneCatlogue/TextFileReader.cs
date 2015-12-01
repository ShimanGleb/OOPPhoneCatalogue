using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatlogue
{
    class TextFileReader
    {
        public string[] ReadPhones(string path)
        {
            return System.IO.File.ReadAllLines(@path);
        }
    }
}
