using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {

    private DataBaseHelper dataHelper = new DataBaseHelper();

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            ASPxGridView1.DataBind();
    }

    protected void ASPxGridView1_DataBinding(object sender, EventArgs e) {
        ASPxGridView1.DataSource = dataHelper.CategoryList;
    }

    protected void ASPxGridView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e) {
        throw new Exception("Data modifications are not allowed in the online example. If you need to test the data editing functionality, please download the example on your machine and run it locally.");
        foreach (var args in e.InsertValues)
            dataHelper.InsertNewItem(args.NewValues);
        foreach (var args in e.UpdateValues)
            dataHelper.UpdateItem(args.Keys, args.NewValues);
        foreach (var args in e.DeleteValues)
            dataHelper.DeleteItem(args.Keys, args.Values);

        e.Handled = true;
    }
}