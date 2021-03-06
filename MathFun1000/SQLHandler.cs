﻿/* Team Name: Math Fun 1000
* Team: Daniel Heffley, Daniel Moore, Bin Mei and Eric Laib
* Class: SQLHandler.aspx.cs
*
* Brief Description: Helper class that handles sql queries.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;

namespace MathFun1000
{
    public class SQLHandler
    {
        string query;
        List<SQLParameters> param;
        List<List<string>> results;
        int totalVars;

        string idOfLastInsert = "";
        public string IDofLastInsert
        {
            get { return idOfLastInsert; }
        }

        DataRow[] data;
        public DataRow[] Data
        {
            get { return data; }
        }

        MySql.Data.MySqlClient.MySqlConnection con;
        MySql.Data.MySqlClient.MySqlCommand cmd;

        public SQLHandler(string _query, List<SQLParameters> _outsideArgs, int _numVariables)
        {
            setUpConnection();
            setUpQuery(_query, _outsideArgs, _numVariables);
            setUpReturnValues(_numVariables);
            //executeStatment();
        }

        private void setUpQuery(string _query, List<SQLParameters> _outsideArgs, int _numVariables)
        {
            query = _query;
            param = _outsideArgs;
            totalVars = _numVariables;
        }

        private void setUpConnection()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            con = new MySql.Data.MySqlClient.MySqlConnection(connString);
        }

        private void setUpReturnValues(int _numVariables)
        {
            results = new List<List<string>>();
        }

        public bool executeStatment()
        {
            try
            {
                using (cmd = new MySqlCommand(query, con))
                {
                    con.Open();
                    cmd.Prepare();

                    foreach (SQLParameters p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Param);
                    }

                    var dt = new DataTable();

                    dt.Load(cmd.ExecuteReader());

                    data = dt.AsEnumerable().ToArray();
                    idOfLastInsert = cmd.LastInsertedId.ToString();
                    con.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                con.Close();
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}