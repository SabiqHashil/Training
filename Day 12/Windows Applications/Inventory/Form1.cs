using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-G77CVUNO\\SQLEXPRESS01;Initial Catalog=InventoryManagementDB;Integrated Security=True;Encrypt=False");
        // Insert product
        private void button1_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox5.Text) ||
                !int.TryParse(textBox2.Text, out int proid) || !int.TryParse(textBox3.Text, out int proquantity) ||
                !decimal.TryParse(textBox4.Text, out decimal price))
            {
                MessageBox.Show("Please enter valid data.");
                return;
            }

            con.Open();
            SqlCommand cmd = new SqlCommand($"EXEC InsertProduct '{textBox1.Text}', {proid}, {proquantity}, {price}, '{textBox5.Text}'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Product inserted successfully.");

            GetList();
        }

        // Show in Grid View
        void GetList()
        {
            SqlCommand c = new SqlCommand("EXEC ListProduct", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        //Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
        }
        //Update product
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter Product ID.");
                return;
            }

            int proid = int.Parse(textBox2.Text);
            var updates = new List<string>();

            if (!string.IsNullOrWhiteSpace(textBox1.Text)) updates.Add($"ProductName = '{textBox1.Text}'");
            if (!string.IsNullOrWhiteSpace(textBox5.Text)) updates.Add($"Supplier = '{textBox5.Text}'");
            if (int.TryParse(textBox3.Text, out int proquantity)) updates.Add($"Quantity = {proquantity}");
            if (decimal.TryParse(textBox4.Text, out decimal price)) updates.Add($"PricePerUnit = {price}");

            if (updates.Count == 0)
            {
                MessageBox.Show("No fields to update.");
                return;
            }

            string query = $"UPDATE InventoryTable SET {string.Join(", ", updates)} WHERE ProductID = {proid}";

            con.Open();
            new SqlCommand(query, con).ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Product updated successfully.");
            GetList();
        }
        //Delete product
        private void button4_Click(object sender, EventArgs e)
        {
            // Delete
            if (string.IsNullOrWhiteSpace(textBox2.Text) || !int.TryParse(textBox2.Text, out int proid))
            {
                MessageBox.Show("Please enter a valid Product ID.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete?", "Delete Product", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"EXEC DeleteProduct {proid}", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Product deleted successfully.");

                GetList();
            }
        }
        // Search Product
        private void button3_Click(object sender, EventArgs e)
        {
            // Check if the text box is empty or if the input is not a valid integer
            if (string.IsNullOrWhiteSpace(textBox2.Text) || !int.TryParse(textBox2.Text, out int proid))
            {
                MessageBox.Show("Please enter a valid Product ID.");
                return;
            }

            SqlCommand cmd = new SqlCommand($"EXEC LoadProduct {proid}", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
