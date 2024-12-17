using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizations_IT_Problem_complain_management
{
    public partial class emp_details : Form
    {
        public emp_details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-BQV495VG\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from emp_tbl ", con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_form admin = new admin_form();
            admin.Show();
            this.Hide();
        }
    }
}
