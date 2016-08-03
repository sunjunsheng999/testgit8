using Insus.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insus.NET.AspNets
{
    public partial class RdlcView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Data_Binding();
            }
        }

        private void Data_Binding()
        {
            this.ReportViewer1.Reset();
            this.ReportViewer1.LocalReport.Dispose();
            this.ReportViewer1.LocalReport.DataSources.Clear();

            Microsoft.Reporting.WebForms.ReportDataSource reportDataSource
                = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource.Name = "DsFruit";

            FruitEntity fe = new FruitEntity();

            reportDataSource.Value = fe.GetAllFruitForReport();

            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/FruitRpt.rdlc");

            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.Refresh();

        }
    }
}