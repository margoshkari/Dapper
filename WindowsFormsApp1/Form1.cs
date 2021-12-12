using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "EXEC [InsertData] @name=, @price=, @category_id=, @manufacturer_id=";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "EXEC [DeleteData] @id=";
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "EXEC [SelectData]";
            using (var connection = new SqlConnection($"Data Source=SQL5105.site4now.net;Initial Catalog=db_a7d3bf_margo;User Id=db_a7d3bf_margo_admin;Password=qwerty2578"))
            {
                var results = connection.Execute(this.textBox1.Text);
                List<Product> products = connection.Query<Product>(this.textBox1.Text).ToList();
                this.textBox1.Text = string.Empty;
                foreach (var item in products)
                {
                    this.textBox1.Text += $"id: {item.product_id}\r\n name: {item.name}\r\n price: {item.price}\r\n category id: {item.category_id}\r\n manufacturer id: {item.manufacturer_id}\r\n\r\n";
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "EXEC [UpdateData] @name=, @price=, @id=";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection($"Data Source=SQL5105.site4now.net;Initial Catalog=db_a7d3bf_margo;User Id=db_a7d3bf_margo_admin;Password=qwerty2578"))
                {
                    var results = connection.Execute(this.textBox1.Text);
                    if (results > 0)
                        MessageBox.Show($"Succes!");
                    else
                        MessageBox.Show($"Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
