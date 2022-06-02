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
   public class admin:person
    {

        public void Set_Violation(int nid, string cid, string vdes,string vd,string vt,string vl)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into VIOLATIONINFO (VIOLATIONID,CARID,VIOLATIONDES,VDATE,VTIME,VLOCATION) values (:violationid,:carid,:vdesc,:vdate,:vtime,:vlocation)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("violationid",nid );
            cmd.Parameters.Add("carid", cid);
            cmd.Parameters.Add("vdesc", vdes);
            cmd.Parameters.Add("vdate", vd);
            cmd.Parameters.Add("vtime", vt);
            cmd.Parameters.Add("vlocation", vl);


            int r = cmd.ExecuteNonQuery();
            if (r != -1)
                MessageBox.Show("Done!");
        }

        public int responed(int status,string vid)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;

            if(status==1)
            {
                c.CommandText = "Delete from VIOLATIONINFO where VIOLATIONID=:id";
                c.Parameters.Add("id",vid);
                int r = c.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Violation deleted");
                    return 1;
                    
                }

            }
            else
            {
                c.CommandText = "update VIOLATIONINFO set STATUS='Rejected' where VIOLATIONID=:id";
                c.Parameters.Add("id",vid);
                int r = c.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Violation responded");
                }

            }
            return 0;
        }
    }
}
