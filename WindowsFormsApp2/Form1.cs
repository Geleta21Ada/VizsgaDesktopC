using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
            List<Book> list = new List<Book>();
        public Form1()
        {
            InitializeComponent();
            string[] line = File.ReadAllLines("books.txt");

            foreach (string line2 in line)
            {
                string[] value = line2.Split(',');
                Book obj = new Book(value[0], value[1], value[2], value[3], value[4]);
                list.Add(obj);
            }

            int osszdb = 0;
            foreach (var item in list)
            {
                osszdb += item.db;
            }

            label1.Text = $"Az össz darabszám: {osszdb}db";

            List<Book> books = new List<Book>();
            Book legdragabb = list[0];
            books.Add(legdragabb);

            foreach (var item in list)
            {
                if (item.ar > legdragabb.ar)
                {
                    legdragabb = item;
                    books.Clear();
                    books.Add(legdragabb);
                }
                else if (item.ar == legdragabb.ar)
                {
                    books.Add(item);
                }
            }
            foreach (var item in books) 
            {
                dataGridView1.Rows.Add(item.kateg, item.cim, item.ar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selected))
            {
                var selectedProd = list.Where(t => t.kateg == selected).ToList();

                listBox1.Items.Clear();

                foreach (var item in selectedProd)
                {
                    listBox1.Items.Add($"Cim: {item.cim},Ár: {item.ar}, Darabszám: {item.db}");
                }
            }
        }
    }
}
