using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace FileSharing
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Server.MapPath("~/Data/"));

            DataTable dt = new DataTable();
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Size", typeof(string));

            foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
            {
                FileInfo fi = new FileInfo(strFile);

                dt.Rows.Add(fi.Name, fi.Length);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Server.MapPath("~/Data/"));

            if (FileUpload1.HasFile)
            {
                try
                {
                    if (FileUpload1.PostedFile.ContentLength <= 5242880)
                    {
                        byte flag = 0;
                        foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
                        {
                            FileInfo fi = new FileInfo(strFile);
                            if(fi.Name.Equals(FileUpload1.FileName))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('File Already Exists!'); window.location='" + Request.ApplicationPath + "Default.aspx';", true);
                                flag = 1;
                                break;
                            }
                        }
                        if(flag==0)
                        {
                            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUpload1.FileName);
                            //FileUpload1.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(Request.ApplicationPath + "/Content/Data/") + FileUpload1.FileName);
                            Response.Redirect(Request.ApplicationPath + "Default.aspx");
                        }
                            
                            
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('File Size Limit : 5 MB'); window.location='" + Request.ApplicationPath + "Default.aspx';", true);
                }
                catch(HttpException)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('File Size Limit : 5 MB'); window.location='" + Request.ApplicationPath + "Default.aspx';", true);
                }
                
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Select File to Upload'); window.location='" + Request.ApplicationPath + "Default.aspx';", true);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Size", typeof(string));

            foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data/")))
            {
                FileInfo fi = new FileInfo(strFile);

                dt.Rows.Add(fi.Name, fi.Length);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.End();
            }
        }
    }
}