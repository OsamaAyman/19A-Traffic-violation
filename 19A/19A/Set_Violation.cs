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
    public partial class Set_Violation : UserControl
    {
        string connstr = "Data Source=ORCL;User Id=scott;Password=tiger;";
        OracleConnection conn;
        int newid;
        public Set_Violation()
        {
            InitializeComponent();
        }

        private void Set_Violation_Load(object sender, EventArgs e)
        {
            int maxid;
            conn = new OracleConnection(connstr);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "GetViolationID";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            c.ExecuteNonQuery();
            try
            {
                maxid = Convert.ToInt32(c.Parameters["id"].Value.ToString());
                newid = maxid + 1;
            }
            catch
            {
                newid = 1;

            }
            txt_VID.Text = "Violation ID: "+ newid.ToString();
        }
        // ADD Button
        private void metroTile1_Click(object sender, EventArgs e)
        {
            admin ad = new admin();
            ad.Set_Violation(newid, txt_CID.Text, txt_VDES.Text, txt_VD.Text, txt_VT.Text, txt_VL.Text);
        }
    }
}
