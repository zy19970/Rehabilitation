using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED
{
    public partial class LED: UserControl
    {
        public LED()
        {
            InitializeComponent();
        }
        public void LedIsOn()
        {
            picG.Visible =true;
            picR.Visible = false;
            picY.Visible = false;
            picD.Visible = false;
        }
        public void LedIsOff()
        {
            picG.Visible = false;
            picR.Visible = false;
            picY.Visible = false;
            picD.Visible = true;
        }
        public void LedIsWarn()
        {
            picG.Visible = false;
            picR.Visible = false;
            picY.Visible = true;
            picD.Visible = false;
        }
        public void LedIsError()
        {
            picG.Visible = false;
            picR.Visible = true;
            picY.Visible = false;
            picD.Visible = false;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LED_Load(object sender, EventArgs e)
        {

        }
    }
}
