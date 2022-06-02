using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19A
{
    public partial class Login : UserControl
    {
       
        person p;
        public Login()
        {
            InitializeComponent();
        }
        // Admin 
        private void btn_Admin_Click(object sender, EventArgs e)
        {
            if (txt_un_login.Text == "Admin" && txt_userpw_login.Text == "123")
            {
                mainAdmin M= new mainAdmin();
                ((Form)this.TopLevelControl).Hide();
                M.ShowDialog();
                ((Form)this.TopLevelControl).Close();
            }
            else
                MessageBox.Show("No username or password");
        }
        // Driver
        private void btn_Driver_Click(object sender, EventArgs e)
        {
            bool valid = false;
             p = new person(txt_un_login.Text, txt_userpw_login.Text);
            valid = p.Login();
            if (!valid)
            {
                MessageBox.Show("The username or Password is not correct !");
            }
           
            if (valid)
            {
                main_user M = new main_user(p);
                ((Form)this.TopLevelControl).Hide();
                M.ShowDialog();
                ((Form)this.TopLevelControl).Close();
            }
        }

        
    }
}
