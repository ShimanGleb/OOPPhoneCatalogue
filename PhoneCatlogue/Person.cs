using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatlogue
{
    class Person
    {
        int id = 0;
        string name = "Nobody";
        string lastName = "Nothing";
        List<Phone> phones = new List<Phone>();

        public void AddPhone(Phone phone)
        {
            phones.Add(phone);
        }        

        public void RemovePhone(string number)
        {
            for (int i = 0; i < phones.Count; i++)
            {
                if (phones[i].CompareNumbers(number) == true)
                {
                    phones.Remove(phones[i]);
                }
            }
        }

        public void FormPerson(int id, string name, string lastName)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
        }

        public List<string> ReturnData()
        {
            List<string> data =new List<string>();
            data.Add(id.ToString());
            data.Add(name);
            data.Add(lastName);
            for (int i = 0; i < phones.Count; i++)
            {
                data.Add(phones[i].ReturnPhone());                
            }
            return data;
        }

        public List<string> ReturnValue(string valueType)
        {
            List<string> value = new List<string>();
            switch (valueType)
            {
                case "ID":
                    {
                        value.Add(id.ToString());
                        break;                                                
                    }
                case "Name":
                    {
                        value.Add(name);
                        break;
                    }
                case "Family name":
                    {
                        value.Add(lastName);
                        break;
                    }
                case "Phone":
                    {                        
                        foreach (Phone phone in phones)
                        {
                            value.Add(phone.ReturnPhone());                            
                        }
                        break;
                    }
                default:
                    {
                        value.Add("error");
                        break;
                    }
                 
            }
            return value;
        }

        public void ChangeValue(List<string> newValue)
        {
            switch (newValue[0])
            {
                case "ID":
                    {
                        id = Convert.ToInt32(newValue[1]);
                        break;
                    }
                case "Name":
                    {
                        name = newValue[1];
                        break;
                    }
                case "Family name":
                    {
                        lastName = newValue[1];
                        break;
                    }
                case "Phone":
                    {
                        phones.Clear();
                        for (int i = 1; i< newValue.Count; i++)
                        {
                            phones.Add(new Phone(newValue[i]));
                        }
                        break;
                    }
            }
        }

        public bool DoesFit(string comparisionType,string word)
        {            
            switch (comparisionType)
            {
                case "ID":
                    {
                        if (id == Convert.ToInt32(word))
                        {
                            return true;
                        }
                        break;
                    }
                case "Name":
                    {
                        if (name == word)
                        {
                            return true;
                        }
                        break;
                    }
                case "Phone":
                    {
                        for (int i = 0; i < phones.Count; i++)
                        {
                            if (phones[i].ReturnPhone() == word)
                            {
                                return true;
                            }
                        }
                        break;
                    }
            }
            return false;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public Person Copy()
        {
            Person newPerson = new Person();
            newPerson.FormPerson(id, name, lastName);
            for (int i = 0; i < phones.Count; i++)
            {
                newPerson.phones.Add(phones[i].Copy());
            }
            return newPerson;
        }
    }
}
