Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private dataHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ASPxGridView1.DataBind()
        End If
    End Sub

    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        ASPxGridView1.DataSource = dataHelper.CategoryList
    End Sub

    Protected Sub ASPxGridView1_BatchUpdate(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs)
        Throw New Exception("Data modifications are not allowed in the online example. If you need to test the data editing functionality, please download the example on your machine and run it locally.")
        For Each args In e.InsertValues
            dataHelper.InsertNewItem(args.NewValues)
        Next args
        For Each args In e.UpdateValues
            dataHelper.UpdateItem(args.Keys, args.NewValues)
        Next args
        For Each args In e.DeleteValues
            dataHelper.DeleteItem(args.Keys, args.Values)
        Next args

        e.Handled = True
    End Sub
End Class