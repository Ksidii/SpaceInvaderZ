using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaderZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void wlewo_Click(object sender, EventArgs e)
        {
            Opis.Text = "W lewo";
        }

        private void wprawo_Click(object sender, EventArgs e)
        {
            Opis.Text = "W prawo";
        }
    }
}
