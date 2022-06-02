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
    
   public class driver:person
    {

        public int complain(string des,string vid)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update VIOLATIONINFO set COMPLAINDES=:comDes,status=:st where VIOLATIONID=:vid";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("comDes", des);
            cmd.Parameters.Add("st", "Not responded yet");
            cmd.Parameters.Add("vid", vid);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Complaint Sent");
                return 1;
            }
            return 0;
        }

        public bool payFees(string vid)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "Delete from VIOLATIONINFO where VIOLATIONID=:id";
            c.Parameters.Add("id", vid);
            int r = c.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Violation deleted");
                return true;
                
            }
            return false;

        }

        public void SignUp(string un,string fn,string ln,string up,string ph,string add,string cid)
        {
            bool valid = true;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select userName from userInfo";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                if (dr[0].ToString() == un)
                {
                    MessageBox.Show("enter another user name");
                    valid = false;
                }
            }
            dr.Close();



            ///////////////////////////////////////////////

            if (valid)
            {
                cmd.CommandText = "insert into userInfo values (:userN,:fn,:ln,:userP,:Mob,:addr,:cID)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("userN", un);
                cmd.Parameters.Add("fn", fn);
                cmd.Parameters.Add("ln",ln);
                cmd.Parameters.Add("userP",up);
                cmd.Parameters.Add("Mob",ph);
                cmd.Parameters.Add("addr",add);
                cmd.Parameters.Add("cID",cid);
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                    MessageBox.Show("signed up correctlly !");
            }
        }

    }
}
