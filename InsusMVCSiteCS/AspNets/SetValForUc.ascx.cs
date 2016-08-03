using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insus.NET.AspNets
{
    public partial class SetValForUc : System.Web.UI.UserControl
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBox1.Text = _Name;
        }
    }
}