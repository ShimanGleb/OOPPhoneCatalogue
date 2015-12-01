using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatlogue
{
    class DataSaver
    {
        public void SaveData(List<Person> persons)
        {
            string fileName = @"Phones.txt";
            string[] people = new string[persons.Count];
            for (int i = 0; i < persons.Count; i++)
            {                
                List<string> personData = persons[i].ReturnData();
                string data = "";
                for (int j = 0; j < personData.Count; j++)
                {
                    data += personData[j];
                    if (j != personData.Count - 1)
                    {
                        data += '=';
                    }
                }
                people[i] = data;
            }
            System.IO.File.Delete(fileName);
            System.IO.File.Create(fileName);
            System.IO.File.WriteAllLines(fileName, people);
        }
    }
}
