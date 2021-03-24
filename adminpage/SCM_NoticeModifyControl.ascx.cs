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
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public partial class Admin_SCM_NoticeModifyControl : System.Web.UI.UserControl
{
   #region [1]Event Handler
    //[1]그리드..
    protected void Page_Load(object sender, EventArgs e)
    {
        //[1]스크립트
        string strAlert = @"<script>location.href='../Default.aspx';</script>";
        
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
                if (!IsPostBack)
                {
                    DisplayData();
                }
            }
            else
            {
                Response.Write(strAlert);                
            }
        }        
    }
    
    //수정
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //[1]제목과 내용 변수
        string strTitle = "";
	string strsalesdate1 = "";
	 
string strcompany1 = "";
//string strcontent2 = "";
//string strterm = "";
//string strdeadline = "";
string strea1 = "";
string strvat1 = "";
string strsalesman1 = "";
string stritem1 = ""; 
string strprice1 = "";
string strsupply1 = "";
string strtotal1 = "";
string UpfileName = "";   
string dbFileName = lblFileName.Text ; 
	                                                  
        

        //[1-1]script
        string strAlert = @"<script>alert('수정했습니다.');location.href='SCM_NoticeView.aspx?SCM_SalesID=" 
            + Request["SCM_SalesID"] 
            + "';</script>"; 


        if ((FileUpload1.PostedFile.FileName != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            UpfileName = FileUpload1.PostedFile.FileName;
    
            string SaveLocation = Server.MapPath("~\\fileUpload\\notice\\") + UpfileName;
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
		    SaveLocation =Server.MapPath("~\\fileUpload\\notice\\")+dbFileName ;
                    fInfo = new FileInfo(SaveLocation)  ;                                                    
                } while (fInfo.Exists);

                                                                                                              
             }
    
              FileUpload1.SaveAs(SaveLocation);
                                                                                                               
        }
 
       
        try
        {            
            //[2]리플레이스 변환
            strTitle = txtTitle.Text;                    				
					
	    strsalesdate1 = txtsalesdate1.Text;  
            strcompany1 = txtcompany1.Text;  
            //strcontent2 = txtcontent2.Text;  
            //strterm = txtterm.Text; 			
//strdeadline = txtdeadline.Text; 
strvat1 = txtvat1.Text; 
strsalesman1 = txtsalesman1.Text; 
stritem1 = txtitem1.Text; 
strea1 = txtea1.Text; 
strprice1 = txtprice1.Text; 
strsupply1 = txtsupply1.Text; 
strtotal1 = txttotal1.Text 
			.Replace("\r\n", "<br />");
 

            using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
            {
                //[1]Excute
             
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UP_ModifySCM_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", strTitle);
		cmd.Parameters.AddWithValue("@salesdate1", strsalesdate1);
		cmd.Parameters.AddWithValue("@company1", strcompany1); 
		//cmd.Parameters.AddWithValue("@content2", strcontent2); 
		//cmd.Parameters.AddWithValue("@term", strterm); 		
		//cmd.Parameters.AddWithValue("@deadline", strdeadline); 
		cmd.Parameters.AddWithValue("@vat1", strvat1); 
		cmd.Parameters.AddWithValue("@salesman1", strsalesman1);  
		cmd.Parameters.AddWithValue("@item1", stritem1);  
		cmd.Parameters.AddWithValue("@ea1", strea1); 
		cmd.Parameters.AddWithValue("@price1", strprice1);   
		cmd.Parameters.AddWithValue("@supply1", strsupply1);
        cmd.Parameters.AddWithValue("@total1", strtotal1);  
        cmd.Parameters.AddWithValue("@upFileName", dbFileName);  
				
				
                cmd.Parameters.AddWithValue("@SCM_SalesID", Convert.ToInt32(Request["SCM_SalesID"]));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            //[2]리디렉트..수차후수정
            Response.Write(strAlert);            
        }
        catch (Exception err)
        {
            //[3]Exception
            Response.Write(err.Source + " : " + err.Message);
        }
        
    }
    //취소
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {        
        Response.Redirect("SCM_NoticeView.aspx?SCM_SalesID=" + Request["SCM_SalesID"]);
    }
    #endregion

    #region [2]Method
    //텍스트 박스 바인딩
    private void DisplayData()
    {
        //[1]dataset
        DataSet ds = null;
        
        try
        {
            using (Is.Notice.Bsl.Notice_RTx bsl = new Is.Notice.Bsl.Notice_RTx())
            {
                //[2]Fill
              //  ds = bsl.ViewNotice(Convert.ToInt32(Request["NoticeID"]));
                ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString, "UP_ViewSCM_Sales", Convert.ToInt32(Request["SCM_SalesID"]));

                //[3]Bind
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
		txtsalesdate1.Text = ds.Tables[0].Rows[0]["salesdate1"].ToString(); 
		txtcompany1.Text = ds.Tables[0].Rows[0]["company1"].ToString();  
		//txtcontent2.Text = ds.Tables[0].Rows[0]["content2"].ToString(); 
		//txtterm.Text = ds.Tables[0].Rows[0]["term"].ToString();  
		txtea1.Text = ds.Tables[0].Rows[0]["ea1"].ToString();
		txtprice1.Text = ds.Tables[0].Rows[0]["price1"].ToString();		
		//txtdeadline.Text = ds.Tables[0].Rows[0]["deadline"].ToString();  
		txtvat1.Text = ds.Tables[0].Rows[0]["vat1"].ToString();  
		txtsalesman1.Text = ds.Tables[0].Rows[0]["salesman1"].ToString();  
		txtitem1.Text = ds.Tables[0].Rows[0]["item1"].ToString();  		
        txttotal1.Text = ds.Tables[0].Rows[0]["total1"].ToString()  
		.Replace("\r\n", "<br />");
		txtsupply1.Text = ds.Tables[0].Rows[0]["supply1"].ToString(); 
		
lblFileName.Text = ds.Tables[0].Rows[0]["UpFileName"].ToString(); 
 
                
            }            
        }
        catch (Exception err)
        {
            //[4]예외
            Response.Write(err.Source + " : " + err.Message);
        }               
    } 
    #endregion
   
}
