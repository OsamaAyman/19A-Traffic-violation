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
    public partial class Make_complain : UserControl
    {
        string userName;
        string cid = "";
        string connstr = "Data Source=ORCL;User Id=scott;Password=tiger;";
        OracleConnection conn;
        driver driver;
        public Make_complain(driver driv)
        {
            InitializeComponent();
            userName = driv.username;
            driver = driv;

            /////////////////////////////////////////load/////////////////////////////
            conn = new OracleConnection(connstr);
            conn.Open();

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select CARID from USERINFO where USERNAME=:un";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("un", userName);
            OracleDataReader d = c.ExecuteReader();
            while (d.Read())
                cid = d[0].ToString();
            d.Close();


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select VIOLATIONID from VIOLATIONINFO where CARID=:id and STATUS is null";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", cid);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                cmb_violationID.Items.Add(dr[0]);

            dr.Close();
            /////////////////////////////////////////////////////////////////////////////////////////

        }

        private void Make_complain_Load(object sender, EventArgs e)
        {
           

        }
        // send button
        private void metroTile1_Click(object sender, EventArgs e)
        {
            int r=0;
            if (cmb_violationID.Text == "")
                MessageBox.Show("Please Choose violation id ");
            else
             r= driver.complain(txt_complainDesc.Text, cmb_violationID.Text);

            if (r == 1)
                cmb_violationID.Items.RemoveAt(cmb_violationID.SelectedIndex);

        }
    }
}
