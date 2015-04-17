using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathFun1000
{
    public partial class Multi : System.Web.UI.Page
    {
        public Multis multi_int = new Multis();

        //On page load this event handler is called.
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateCode();
            SetUpButtons();
        }

        private void SetUpButtons()
        {

        }

        private void GenerateCode()
        {
            string parse = multi_int.GenerateCode();
            ParseForInput(parse);
        }

        private void ParseForInput(string parase)
        {
            innerMain.InnerHtml = parase;
        }
    }
}