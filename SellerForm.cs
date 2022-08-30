using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shoprite_Ghana
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BMPC\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "Select * from SellerTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDVG.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into SellerTb1 values(" + bunifuMaterialTextbox1.Text + ",'" + bunifuMaterialTextbox2.Text + "', '" + bunifuMaterialTextbox3.Text + "', '" + bunifuMaterialTextbox4.Text + "', '" + bunifuMaterialTextbox5.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller added Successfully");
                Con.Close();
                populate();
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
                bunifuMaterialTextbox4.Text = "";
                bunifuMaterialTextbox5.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            populate();
        }


        private void SellerDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMaterialTextbox1.Text = SellerDVG.SelectedRows[0].Cells[0].Value.ToString();
            bunifuMaterialTextbox2.Text = SellerDVG.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMaterialTextbox3.Text = SellerDVG.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMaterialTextbox4.Text = SellerDVG.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMaterialTextbox5.Text = SellerDVG.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuMaterialTextbox1.Text == "")
                {
                    MessageBox.Show("Select attendant to remove");
                }
                else
                {
                    Con.Open();
                    string query = "delete from SellerTb1 where SellerId="+ bunifuMaterialTextbox1.Text +"";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller removed successfully");
                    Con.Close();
                    populate();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    bunifuMaterialTextbox3.Text = "";
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {

                if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || bunifuMaterialTextbox4.Text == "" || bunifuMaterialTextbox5.Text == "")
                {
                    MessageBox.Show("Missing information");
                }
                else
                {
                    Con.Open();
                    string query = "update SellerTb1 set SellerId ='" + bunifuMaterialTextbox1.Text + "',SellerName ='" + bunifuMaterialTextbox2.Text + "',SellerAge ='" + bunifuMaterialTextbox3.Text + "',SellerPhone ='" + bunifuMaterialTextbox4.Text + "', SellerPass ='" + bunifuMaterialTextbox5.Text + "' where SellerId = '" + bunifuMaterialTextbox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendant data updated successfully");
                    Con.Close();
                    populate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm products = new ProductForm();
            products.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CATEGORYFORM category = new CATEGORYFORM();
            category.Show();
            this.Hide();
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}
