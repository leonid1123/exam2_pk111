using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace exam2_pk111
{
    public partial class Form1 : Form
    {
        MySqlConnection conn=null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string ins = "INSERT INTO processors (Name,Cores,Friq) VALUES (@name,@cores,@freq)";
            MySqlCommand sqlIns = new MySqlCommand(ins,conn);
            sqlIns.Parameters.AddWithValue("@name",textBox1.Text);
            sqlIns.Parameters.AddWithValue("@cores",numericUpDown1.Value);
            sqlIns.Parameters.AddWithValue("@freq", trackBar1.Value);
            sqlIns.ExecuteNonQuery();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=localhost;User ID=root;Password=root;Database=exam_pk111");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();
        }
    }
}
