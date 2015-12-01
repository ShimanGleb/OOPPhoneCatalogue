using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatlogue
{
    class PersonParser
    {
        public Person Parse(string line)
        {
            Person person = new Person();
            person.FormPerson(Convert.ToInt32(line.Split('=')[0]), line.Split('=')[1], line.Split('=')[2]);            
            string[] phones = line.Split('=');
            for (int i = 3; i < phones.Length; i++)
            {
                Phone phone = new Phone(phones[i]);
                person.AddPhone(phone);
            }
            return person;
        }
    }
}
