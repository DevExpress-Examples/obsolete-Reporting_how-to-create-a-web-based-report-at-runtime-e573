using System;
using System.Data;
using DevExpress.XtraReports.UI;
// ...

namespace WebReportRuntime {
    public partial class _Default : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Test");
            t.Columns.Add("DataColumn");
            ds.Tables.Add(t);
            for(int i = 0; i < 50; i++)
                t.Rows.Add(new object[] { "Row " + i.ToString() });
            XtraReport1 r = new XtraReport1();
            r.DataSource = ds;
            r.DataMember = ds.Tables[0].TableName;
            XRLabel label = new XRLabel();
            r.Bands[BandKind.Detail].Controls.Add(label);
            label.DataBindings.Add("Text", ds, r.DataMember + "." + "DataColumn");
            ReportViewer1.Report = r;
        }

    }
}
