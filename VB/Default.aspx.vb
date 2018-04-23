Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports DevExpress.XtraReports.UI
' ...

Namespace WebReportRuntime
	Partial Public Class _Default
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim ds As New DataSet()
			Dim t As New DataTable("Test")
			t.Columns.Add("DataColumn")
			ds.Tables.Add(t)
			For i As Integer = 0 To 49
				t.Rows.Add(New Object() { "Row " & i.ToString() })
			Next i
			Dim r As New XtraReport1()
			r.DataSource = ds
			r.DataMember = ds.Tables(0).TableName
			Dim label As New XRLabel()
			r.Bands(BandKind.Detail).Controls.Add(label)
			label.DataBindings.Add("Text", ds, r.DataMember & "." & "DataColumn")
			ASPxDocumentViewer1.Report = r
		End Sub

	End Class
End Namespace
