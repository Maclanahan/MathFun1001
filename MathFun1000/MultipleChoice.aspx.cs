using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class MultipleChoice : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        String queryStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            literal_ChapterNum.Text = "2";
            literal_ProblemNum.Text = "1";
            literal_Problem.Text = "2+2 equals?";
            CheckBox1.Text = "A stick!";
            CheckBox2.Text = "Melted Chocolate!";
            CheckBox3.Text = "Sponge?";
            CheckBox4.Text = "4";
            CheckBox5.Text = "Who cares?";
            bool isChecked = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //foreach (CheckBox cb : Control c)
            //{

            //}
        }



    }
}