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
    public partial class complaint_history : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-BQV495VG\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");

        public complaint_history()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-BQV495VG\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))

                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    using (DataTable dt = new DataTable("complaint_table"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT complaint_table.Complaint_id, user_tbl.user_id, user_tbl.name, complaint_table.complaint, complaint_table.emp_id, complaint_table.status FROM user_tbl INNER JOIN complaint_table ON user_tbl.user_id = complaint_table.user_id", cn))
                        {
                            
                            SqlDataAdapter ad = new SqlDataAdapter(cmd);
                            ad.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            }
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            assign_emp k= new assign_emp();
            k.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void complaint_history_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_form a= new admin_form();
            a.Show();
            this.Hide();
        }
    }
}
