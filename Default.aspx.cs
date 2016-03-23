using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;

namespace Fwtest1
{
    public partial class _Default : Page
    {
        private object dbconn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateData();
                lblMessage.Text = "Current Database Display";
            }
        }

        private void PopulateData()
        {

            using (SqlConnection dbConn = new SqlConnection("Data Source = (LocalDb)MSSQLLocalDB; AttachDbFilename =| DataDirectory |\aspnet - Fwtest3 - 20160323094236.mdf; Initial Catalog = aspnet - Fwtest3 - 20160323094236; Integrated Security = True" providerName="System.Data.SqlClient" "))
            {
                SqlCommand cmd = new SqlCommand("Select * from Address", dbConn);
                if (dbConn.State != System.Data.ConnectionState.Open)
                {
                    dbConn.Open();
                }
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                grdView.DataSource = dt;
                grdView.DataBind();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile.ContentType == "application/vnd.ms-excel" || FileUpload1.PostedFile.ContentType == "application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet")
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Datafile/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);

                    string conString = "";
                    String ext = Path.GetExtension(FileUpload1.PostedFile.FileName);

                    if (ext.ToLower() == ".xls")
                    {
                        conString = "provider=microsoft.jet.oledb.4.0;data source=" + path + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";

                    }
                    else if (ext.ToLower() == "xlsx")
                    {
                        conString = "provider=microsoft.jet.oledb.12.0;data source=" + path + ";extended properties=" + "\"excel 12.0;hdr=yes;\"";

                    }
                   //Context / comma - separated - values, text / csv, application / csv, application / excel, application / vnd.ms - excel, application / vnd.msexcel, text / anytext
                   if(ext.ToLower()== ".csv"|| "txt") {
                        conString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\;" + path +
                                           "Extended Properties=\"text;HDR=YES;FMT=Delimited\"");
                        //string mySelectQuery = "SELECT * FROM SampleFile.CSV";
                        
                        
                    }

                    string query = "Select * from [Address$]";
                    OleDbConnection con = new OleDbConnection(conString);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    // Create DbDataReader to Data Worksheet
                    DbDataReader dr = cmd.ExecuteReader();
                    // SQL Server Connection String
                    SqlConnection dbConn = new SqlConnection("db conn string");


                    // Bulk Copy to SQL Server 
                    SqlBulkCopy bulkInsert = new SqlBulkCopy("");
                    bulkInsert.DestinationTableName = "Address";

                    while (dr.Read())
                    {
                        bulkInsert.WriteToServer(dr);
                    }

                    con.Close();


                    dbConn.Close();

                    PopulateData();
                    lblMessage.Text = "Successfully Data Import Done";
                }
                catch (Exception) { throw; }

                






            }





        }
    }

