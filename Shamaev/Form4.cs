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

namespace Shamaev
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Title = textBox1.Text.Trim();
            int INN = Convert.ToInt32(textBox2.Text.Trim());
            string StartDate = textBox3.Text.Trim();
            int QualityRating = Convert.ToInt32(textBox4.Text.Trim());
            object SupplierType = comboBox1.Text.Trim();

           SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-HVD7F6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Shamaev");
            con.Open();
            //string query = "SELECT * FROM Supplier";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader reader = cmd.ExecuteReader();

            //if (reader.HasRows)
            {
                //while (reader.Read())
               // {
                    //object ID = reader.GetValue(0);
                    //SupplierType = ID;
                //}
                //reader.Close();
                try
                {
                    string insertquery = "INSERT INTO Supplier (Title, INN, StartDate, QualityRating, SupplierType) VALUES ('" + Title + "','" + INN + "','" + StartDate + "','" + QualityRating + "','" + SupplierType + "')";
                    SqlCommand cmd2 = new SqlCommand(insertquery, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Запись добавлена!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Form4.ActiveForm.Close();
            }
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet7.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter.Fill(this.dataSet7.Supplier);

        }
    }
}
