using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_SCM_NoticeAddControl : System.Web.UI.UserControl
{
    #region [1]Event Handler
    //Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //[1]스크립트
        string strAlert = @"<script>alert('관리자만 접근가능합니다.');location.href='../Default.aspx';</script>";

        //[2]로그인 체크
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Write(strAlert);
        }
        else
        {
            //[3]관리자만 접근가능
            if (Page.User.Identity.Name.ToLower() == "admin")
            {
                //
            }
            else
            {
                Response.Write(strAlert);
            }
        }
    }
    //Submit
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {        

        //[1]임시변수
        string strTitle = "";
        string strtotal1 = "";
string strsalesdate1 = ""; 

string strcompany1 = "";
string strcompany2 = "";
string strcompany3 = "";
string strcompany4 = "";
string strcompany5 = "";
string strcompany6 = "";
string strcompany7 = "";
string strcompany8 = "";



string stritem1 = ""; 
//string strcontent2 = "";
//string strterm = "";
//string strdeadline = "";
string strvat1 = "";
string strsalesman1 = ""; 
string strea1 = "";
string strprice1 = "";
string strsupply1 = "";
    string UpfileName = "";	

    string dbFileName = string.Empty;
     

         
	
       
                                                                        
        string path="d:\\_Mobile_System\\joblink\\fileUpload\\Notice\\";        


        string strAlert = @"<script>alert('입력했습니다.');location.href='SCM_NoticeList.aspx';</script>";


if ((FileUpload1.PostedFile.FileName != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            UpfileName = FileUpload1.PostedFile.FileName;
    
            string SaveLocation = Server.MapPath("~\\fileUpload\\Notice\\") + UpfileName;
            dbFileName = UpfileName;
            FileInfo fInfo = new FileInfo(SaveLocation);
            string newUpFile = string.Empty;
            if (!fInfo.Exists)
            {
                int fIndex = 0;
                string fExtension = fInfo.Extension;
                string fRealName = UpfileName.Replace(fExtension, "");

                do
                {
                    fIndex++;
                    dbFileName = fRealName + "" + fIndex.ToString() + fExtension;
		    SaveLocation =Server.MapPath("~\\fileUpload\\Notice\\")+dbFileName ;
                    fInfo = new FileInfo(SaveLocation)  ;                                              
                } while (fInfo.Exists);                                                                                                        
             }
                  FileUpload1.SaveAs(SaveLocation);                                                                                                          
        }


      

	 
        
        try
        {
            //[2]변환
            strTitle = txtTitle.Text
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r\n", "<br>")
                .Replace("\t", "&nbsp;&nbsp;&nbsp;");                
 
 		strtotal1 = txttotal1.Text
		 .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\r\n", "<br>")
                .Replace("\t", "&nbsp;&nbsp;&nbsp;");   
		
		
strsalesdate1 = txtsalesdate1.Text; 	
stritem1 = txtitem1.Text; 		
strcompany1 = txtcompany1.Text;
             

//strcontent2 = txtcontent2.Text;
//strterm = txtterm.Text;
//strdeadline = txtdeadline.Text;
strvat1 = txtvat1.Text;
strsalesman1 = txtsalesman1.Text; 
strea1 = txtea1.Text;
strprice1 = txtprice1.Text;
strsupply1 = txtsupply1.Text;
 











if (strcompany1 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strcompany2 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strcompany3 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strcompany4 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}
if (strcompany5 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                   cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}

if (strcompany6 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}


if (strcompany7 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}


if (strcompany8 !="")
{
               using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Sales", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@total1", strtotal1);
                    cmd.Parameters.AddWithValue("@item1", stritem1);	
					cmd.Parameters.AddWithValue("@upFileName", dbFileName);
					cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
					cmd.Parameters.AddWithValue("@ea1", strea1);
					cmd.Parameters.AddWithValue("@company1", strcompany1);
					//cmd.Parameters.AddWithValue("@content2", strcontent2);
					//cmd.Parameters.AddWithValue("@term", strterm);
					//cmd.Parameters.AddWithValue("@deadline", strdeadline);
					cmd.Parameters.AddWithValue("@vat1", strvat1);
					cmd.Parameters.AddWithValue("@salesman1", strsalesman1); 
					cmd.Parameters.AddWithValue("@price1", strprice1);
					cmd.Parameters.AddWithValue("@supply1", strsupply1);
					con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
}




























   /*      
                using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("UP_AddSCM_Notice", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", strTitle);
                    cmd.Parameters.AddWithValue("@Content", strContent);
                    cmd.Parameters.AddWithValue("@code1", strcode1);	
                    cmd.Parameters.AddWithValue("@code2", strcode2);	
                    cmd.Parameters.AddWithValue("@code3", strcode3);	
                    cmd.Parameters.AddWithValue("@code4", strcode4);	
                    cmd.Parameters.AddWithValue("@code5", strcode5);						
					
					
cmd.Parameters.AddWithValue("@upFileName", dbFileName);
cmd.Parameters.AddWithValue("@upFileName2", dbFileName2);
cmd.Parameters.AddWithValue("@upFileName3", dbFileName3);
cmd.Parameters.AddWithValue("@upFileName4", dbFileName4);
cmd.Parameters.AddWithValue("@upFileName5", dbFileName5);
                     
		     

cmd.Parameters.AddWithValue("@ps", strps);
cmd.Parameters.AddWithValue("@ts1", strts1);
cmd.Parameters.AddWithValue("@ts2", strts2);
cmd.Parameters.AddWithValue("@ts3", strts3);
cmd.Parameters.AddWithValue("@ts4", strts4);
cmd.Parameters.AddWithValue("@ts5", strts5);

cmd.Parameters.AddWithValue("@cs1", strcs1);
cmd.Parameters.AddWithValue("@cs2", strcs2);
cmd.Parameters.AddWithValue("@cs3", strcs3);
cmd.Parameters.AddWithValue("@cs4", strcs4);
cmd.Parameters.AddWithValue("@cs5", strcs5);


cmd.Parameters.AddWithValue("@link1", strlink1);
cmd.Parameters.AddWithValue("@link2", strlink2);
cmd.Parameters.AddWithValue("@link3", strlink3);
cmd.Parameters.AddWithValue("@link4", strlink4);
cmd.Parameters.AddWithValue("@link5", strlink5);

cmd.Parameters.AddWithValue("@Dead1", strDead1);
cmd.Parameters.AddWithValue("@Dead2", strDead2);
cmd.Parameters.AddWithValue("@Dead3", strDead3);
cmd.Parameters.AddWithValue("@Dead4", strDead4);
cmd.Parameters.AddWithValue("@Dead5", strDead5);

cmd.Parameters.AddWithValue("@Progress1", strProgress1);
cmd.Parameters.AddWithValue("@Progress2", strProgress2);
cmd.Parameters.AddWithValue("@Progress3", strProgress3);
cmd.Parameters.AddWithValue("@Progress4", strProgress4);
cmd.Parameters.AddWithValue("@Progress5", strProgress5);

cmd.Parameters.AddWithValue("@corp1", strcorp1); 
cmd.Parameters.AddWithValue("@corp2", strcorp2);
cmd.Parameters.AddWithValue("@corp3", strcorp3);
cmd.Parameters.AddWithValue("@corp4", strcorp4);
cmd.Parameters.AddWithValue("@corp5", strcorp5); 

con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
         */ 

            //[4]
            Response.Write(strAlert);
        }
        catch (Exception err)
        {
            //[5]Exception
            Response.Write(err.Source + " : " + err.Message);
        }
    }
    //Cancel
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SCM_NoticeList.aspx");
    } 
    #endregion
}
