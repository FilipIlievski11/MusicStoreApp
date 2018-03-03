using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicStorev1
{
    public partial class MusicStoreStart : Form
    {
        public MusicStoreStart()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            MusicStoreRegister next = new MusicStoreRegister();
            
            next.Show();
            this.Hide();
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            MusicStoreLogIn next = new MusicStoreLogIn();
            this.Hide();
            next.Show();
        }

        private void test111_Click(object sender, EventArgs e)
        {
            Test t = new Test();
            t.Show();
        }
    }
}
