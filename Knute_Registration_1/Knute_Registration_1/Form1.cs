using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Knute_Registration_1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        
        private void btn_Submit_Click_1(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                SqlConnection _sql_con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MyDatabase.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("Select * from tbl_Login where UserName=@username and Password=@password", _sql_con);
                cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);

                _sql_con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapt.Fill(ds);
                _sql_con.Close();
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}