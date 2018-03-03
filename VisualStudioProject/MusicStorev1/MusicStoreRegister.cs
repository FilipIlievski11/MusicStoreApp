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
    public partial class MusicStoreRegister : Form
    {
        public MusicStoreRegister()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            

            // pomosh
            bool flag = false;

            // proverka za korisnickoime
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from useracc where username='" + Username.Text + "'", conn);
            NpgsqlDataReader data = cmd1.ExecuteReader();
            data.Read();
            if (data.HasRows)
            {

                tryAgain.Visible = true;
                flag = true;
            }
            else
                tryAgain.Visible = false;

            conn.Close();
            //dali drugite mesta se prazni?
            if (!flag)
            {
                if ((!string.IsNullOrWhiteSpace(FirstName.Text)) && (!string.IsNullOrWhiteSpace(SecondName.Text)) &&
                    (!string.IsNullOrWhiteSpace(Username.Text)) && (!string.IsNullOrWhiteSpace(inputPW.Text)) &&
                    (drzavi.SelectedIndex > -1))
                {
                    NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                    NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                    conn2.Open();
                    conn3.Open();
                    NpgsqlCommand cmd3 =new NpgsqlCommand("select countryID from country where countryName='" + drzavi.Text + "'",conn3);
                    NpgsqlDataReader data2 = cmd3.ExecuteReader();
                    data2.Read();
                    
                    
                    NpgsqlCommand cmd2 = new NpgsqlCommand("insert into useracc(username,userpassword,firstname,secondname,countryID) values('"+ Username.Text+"','"+inputPW.Text+"','"+FirstName.Text+"','"+SecondName.Text+"','"+data2[0]+"')",conn2);
                    cmd2.ExecuteNonQuery();
                    tryAgain.Visible = false;
                    panelE.Visible = false;
                    conn2.Close();
                    conn3.Close();
                    MessageBox.Show("You can now log into your new account.");
                    MusicStoreLogIn next = new MusicStoreLogIn();
                    
                    this.Hide();
                    next.Show();
                }
                else
                    panelE.Visible = true;

            }
            conn.Close();
        }
    }
}
