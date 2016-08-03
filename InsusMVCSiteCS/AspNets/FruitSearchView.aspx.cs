using Insus.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace Insus.NET.AspNets
{
    public partial class FruitSearchView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ButtonSR_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.Reset();
            this.ReportViewer1.LocalReport.Dispose();
            this.ReportViewer1.LocalReport.DataSources.Clear();

            string categoryName = this.TextBoxCategroyName.Text.Trim();
            string kindName = this.TextBoxKindName.Text.Trim();
            string fruitName = this.TextBoxFruitName.Text.Trim();

            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/FruitSearchRpt.rdlc");

            //Microsoft.Reporting.WebForms.ReportParameter[] parameters = {
            //    new Microsoft.Reporting.WebForms.ReportParameter("CategoryName", categoryName),
            //    new Microsoft.Reporting.WebForms.ReportParameter("KindName", kindName),
            //    new Microsoft.Reporting.WebForms.ReportParameter("FruitName", fruitName)
            //    };

            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("CategoryName", categoryName));
            parameters.Add(new ReportParameter("KindName", kindName));
            parameters.Add(new ReportParameter("FruitName", fruitName));

            this.ReportViewer1.LocalReport.SetParameters(parameters);


            Microsoft.Reporting.WebForms.ReportDataSource reportDataSource
                = new Microsoft.Reporting.WebForms.ReportDataSource();

            reportDataSource.Name = "DsFruitSearch";

            FruitEntity fe = new FruitEntity();
            reportDataSource.Value = fe.SearchFruitForReport(categoryName, kindName, fruitName);

            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}