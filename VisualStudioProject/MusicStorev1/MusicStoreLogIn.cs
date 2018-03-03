using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace MusicStorev1
{
    public partial class MusicStoreLogIn : Form
    {
        public static string sendtext = "";
        public MusicStoreLogIn()
        {
            InitializeComponent();
        }

        public string MyValue
        {
            set { this.MyValue = Username.Text; }
            get { return this.MyValue; }
        }
        
        private void back_Click(object sender, EventArgs e)
        {
            MusicStoreStart next = new MusicStoreStart();
            this.Hide();
            next.Show();
        }

        private void inputPW_TextChanged(object sender, EventArgs e)
        {
            this.inputPW.PasswordChar = '*';
        }

        private void login_Click(object sender, EventArgs e)
        {
            //postgrekonekcija
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from useracc where username='"+Username.Text+"' and userpassword='"+inputPW.Text+"'",conn);
            NpgsqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                invalid.Visible = false;
                MessageBox.Show("You've been successfully logged in!");
                sendtext = Username.Text;
                MusicStoreOpen next = new MusicStoreOpen(sendtext);
                this.Hide();
                next.Show();
            }
            else
                invalid.Visible = true;


        }
    }
}
