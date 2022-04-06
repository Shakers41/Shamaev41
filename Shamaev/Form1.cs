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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet4.MaterialType". При необходимости она может быть перемещена или удалена.
            this.materialTypeTableAdapter.Fill(this.dataSet4.MaterialType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet3.Material". При необходимости она может быть перемещена или удалена.
            this.materialTableAdapter2.Fill(this.dataSet3.Material);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet2.Material". При необходимости она может быть перемещена или удалена.
            this.materialTableAdapter1.Fill(this.dataSet2.Material);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Material". При необходимости она может быть перемещена или удалена.
            this.materialTableAdapter.Fill(this.dataSet1.Material);
            
            {
                string connectionString = @"Data Source =SQLNCLI11;Data Source=DESKTOP-HVD7F6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Shamaev";

                // Создание подключения
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    // Открываем подключение
                    connection.Open();
                    Console.WriteLine("Подключение открыто");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            {
                int count1 = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                count1++;
                                break;
                            }

                    


                }
                string constr = @"Data Source =SQLNCLI11;Data Source=DESKTOP-HVD7F6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Shamaev";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "select * from Material";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                label1.Text = "Записей : " + count1;
            }     
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-HVD7F6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Shamaev");
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select * from Material Order By Cost asc", con);
                con.Open();
                da.Fill(ds, "Material");
                dataGridView1.DataSource = ds.Tables[0];
                da.Dispose();
                con.Dispose();
                ds.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(comboBox2.Text))
                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source =SQLNCLI11;Data Source=DESKTOP-HVD7F6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Shamaev";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "select * from Material";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            { count++; }
            label1.Text = "Записей : " + count + " ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
