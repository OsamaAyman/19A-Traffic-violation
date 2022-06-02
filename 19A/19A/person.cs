using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace _19A
{
   public class person
    {
       public string name, username, password,connstr = "Data Source=ORCL;User Id=scott;Password=tiger;";
       
       public OracleConnection conn;
        public person()
        {
            conn = new OracleConnection(connstr);
            conn.Open();
        }
        public person(string un,string pas)
        {
            username = un;
            password = pas;
            conn = new OracleConnection(connstr);
            conn.Open();

        }
        public bool Login()
        {
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select userName , USERPW from userInfo";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                if (dr[0].ToString() == username && dr[1].ToString() ==password)
                    return true;
              

            }
            dr.Close();

            return false;
        }

         ~person()
        { conn.Close(); }


    }
}
