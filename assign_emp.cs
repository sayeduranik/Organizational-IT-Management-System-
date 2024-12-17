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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Organizations_IT_Problem_complain_management
{
    public partial class assign_emp : Form
    {
        public assign_emp()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-BQV495VG\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("update complaint_table set emp_id=@emp_id where complaint_id=@complaint_id", con))
                    {
                        cmd.Parameters.AddWithValue("@complaint_id", textBox3.Text);
                        cmd.Parameters.AddWithValue("@emp_id", textBox4.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(textBox4.Text + " SuccessFully Assign");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

