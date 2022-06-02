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
    public partial class Responed_complain : UserControl
    {
        string connstr = "Data Source=ORCL;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Responed_complain()
        {
            InitializeComponent();
            conn = new OracleConnection(connstr);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select VIOLATIONID from VIOLATIONINFO where STATUS is not null";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                cmb_violationID.Items.Add(dr[0]);

            dr.Close();
        }

        private void Responed_complain_Load(object sender, EventArgs e)
        {
          
        }
        // button
        private void btn_responed_Click(object sender, EventArgs e)
        {
            if (cmb_violationID.Text == "")
                MessageBox.Show("Please choose Violation");
            else
            {
                admin admin = new admin();

                if (Rd_Accept.Checked)
                {
                   int rt= admin.responed(1, cmb_violationID.Text);
                    if(rt==1)
                        cmb_violationID.Items.RemoveAt(cmb_violationID.SelectedIndex);
                }
                else if (Rd_Reject.Checked)
                {
                    int rt=admin.responed(0, cmb_violationID.Text);

                }
                else
                    MessageBox.Show("Please choose a status");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroLabel1.Left--;
            if (metroLabel1.Left < -260)
                metroLabel1.Left = 300;
        }
        int alfa;
        int r;
        int g;
        int b;
        Random rnd = new Random();

        private void timer2_Tick(object sender, EventArgs e)
        {
            alfa = rnd.Next(0, 255);
            r = rnd.Next(0, 255);
            g = rnd.Next(0, 255);
            b = rnd.Next(0, 255);
            metroLabel1.ForeColor = Color.FromArgb(alfa, r, g, b);
        }
    }
}
