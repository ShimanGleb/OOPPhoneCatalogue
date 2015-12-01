using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatlogue
{
    class DataLoader
    {
        public List<Person> LoadData()
        {
            string filename = "Phones.txt";
            List<Person> persons = new List<Person>();
            TextFileReader reader = new TextFileReader();
            string[] people = reader.ReadPhones(filename);
            PersonParser parser = new PersonParser();
            foreach (string data in people)
            {
                persons.Add(parser.Parse(data));
            }
            return persons;
        }
    }
}
