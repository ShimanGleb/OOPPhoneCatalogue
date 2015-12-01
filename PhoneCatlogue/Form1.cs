using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhoneCatlogue
{
    public partial class Form1 : Form
    {        
        SqlConnection catalogueConnection = new SqlConnection("user=User;" +
                                       "password=123;server=SQLEXPRESS;" +
                                       "Trusted_Connection=yes;" +
                                       "database=PhoneCatalogue; " +
                                       "connection timeout=20");
        string filename = "Phones.txt";
        List<Person> persons = new List<Person>();
        Person selectedPerson = new Person();
        Person newPerson = new Person();
        public Form1()
        {
            InitializeComponent();
            //catalogueConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataLoader loader = new DataLoader();
            persons = loader.LoadData();       
            
            for (int i = 0; i < persons.Count; i++)
            {
                dataGridView1.Rows.Add();
                List<string> personData = persons[i].ReturnData();
                dataGridView1[0, i].Value = personData[0];
                dataGridView1[1, i].Value = personData[1];
                dataGridView1[2, i].Value = personData[2];
                for (int j = 3; j < personData.Count; j++)
                {
                    dataGridView1[3, i].Value += personData[j] + " ";
                }                
            }            
        }        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
            List<string> data = selectedPerson.ReturnValue(comboBox2.Text);
            if (data[0] != "error")
            {
                string newData = "";
                for (int i = 0; i < data.Count; i++)
                {
                    newData += data[i] + "\r\n";
                }
                textBox4.Text = newData;                                   
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.SelectedRows[0].Index;
            selectedPerson = persons[rowIndex].Copy();
            newPerson=persons[rowIndex].Copy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> newValue = new List<string>();
            newValue.Add(comboBox2.Text);
            string[] info = textBox4.Text.Split('\n');
            for (int i=0; i<info.Length; i++)
            {
                newValue.Add(info[i].Split('\r')[0]);
            }
            selectedPerson.ChangeValue(newValue);
            persons[dataGridView1.SelectedRows[0].Index] = selectedPerson.Copy();

            dataGridView1.Rows.Clear();
            for (int i = 0; i < persons.Count; i++)
            {
                dataGridView1.Rows.Add();
                List<string> personData = persons[i].ReturnData();
                dataGridView1[0, i].Value = personData[0];
                dataGridView1[1, i].Value = personData[1];
                dataGridView1[2, i].Value = personData[2];
                for (int j = 3; j < personData.Count; j++)
                {
                    dataGridView1[3, i].Value += personData[j] + " ";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> newValue = new List<string>();
            newValue.Add(comboBox2.Text);
            string[] info = textBox4.Text.Split('\n');
            for (int i = 0; i < info.Length; i++)
            {
                newValue.Add(info[i].Split('\r')[0]);
            }
            newPerson.ChangeValue(newValue);

            dataGridView1.Rows.Add();
            newPerson.SetId(dataGridView1.Rows.Count);
            List<string> personData = newPerson.ReturnData();
            dataGridView1[0, dataGridView1.Rows.Count-1].Value = personData[0];
            dataGridView1[1, dataGridView1.Rows.Count-1].Value = personData[1];
            dataGridView1[2, dataGridView1.Rows.Count-1].Value = personData[2];
            for (int j = 3; j < personData.Count; j++)
            {
                dataGridView1[3, dataGridView1.Rows.Count-1].Value += personData[j] + " ";
            }
            persons.Add(newPerson);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            List<string> newValue = new List<string>();
            newValue.Add(comboBox2.Text);
            string[] info = textBox4.Text.Split('\n');
            for (int i = 0; i < info.Length; i++)
            {
                newValue.Add(info[i].Split('\r')[0]);
            }
            selectedPerson.ChangeValue(newValue);
            newPerson.ChangeValue(newValue);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSaver saver = new DataSaver();
            saver.SaveData(persons);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].DoesFit(comboBox1.Text, textBox2.Text) == true)
                {
                    List<string> data = persons[i].ReturnData();
                    for (int j = 0; j < data.Count; j++)
                    {
                        textBox3.Text += data[j] + "\r\n";
                    }
                    break;
                }
            }
        }
    }
}