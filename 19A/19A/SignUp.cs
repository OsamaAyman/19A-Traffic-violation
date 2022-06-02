using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace _19A
{
    public partial class SignUp : UserControl
    {

       
        public SignUp()
        {
            InitializeComponent();
        }
        // Sign Up
        private void metroTile1_Click(object sender, EventArgs e)
        {
            driver dri = new driver();
            dri.SignUp(txt_un.Text, txt_fn.Text, txt_ln.Text, txt_up.Text, txt_PN.Text, txt_add.Text, txt_CarN.Text);

        }

       
    }
}
