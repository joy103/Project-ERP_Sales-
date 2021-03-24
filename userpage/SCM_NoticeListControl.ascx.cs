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

public partial class SCM_NoticeListControl : System.Web.UI.UserControl
{
    #region [1]Event Handler
    //Load : Check Admin
    public string salesman1="";
public string ctitle ="전체";
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (salesman1=="전체")
         ctitle ="전체";
        else if (salesman1=="김가연")
         ctitle ="김가연";
        else if (salesman1=="오민준")
         ctitle ="오민준";
        else if (salesman1=="이정현")
         ctitle ="이정현";
        else if (salesman1=="장지인")
         ctitle ="장지인";
        // else if (salesman1=="건강")
        //  ctitle ="건강";
        // else if (salesman1=="도서")
        //  ctitle ="도서";
        else if (salesman1=="")
         ctitle =" ";
 
        
        if (!IsPostBack)
        {
            DisplayData();
        }          
    }   
       
    //Paging
    protected void ctlNoticeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ctlNoticeList.PageIndex = e.NewPageIndex;
        DisplayData();
    }
    //마우수 오바시 효과
    protected void ctlNoticeList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add(
                "onMouseOver", "this.style.backgroundColor='#D0D7E2';return true");

            e.Row.Attributes.Add(
                "onMouseOut", "this.style.backgroundColor='#ffffff';");
        }
    }
    #endregion

    #region [2]Method
    //[1]그리드 바인딩
    private void DisplayData()
    {
        //[1]
        DataSet ds = null;

        try
        {
            using (Is.Notice.Bsl.Notice_NTx bsl = new Is.Notice.Bsl.Notice_NTx())
            {
                //[2]Fill
                //ds = bsl.ListNotice();
                ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["ISDB"].ConnectionString, "UP_ListSCM_Sales", salesman1);
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //[3]Bind
                    ctlNoticeList.DataSource = ds;
                    ctlNoticeList.DataBind();
                }
                else
                {
                    //lblNoticeError.Text = "공지사항이 없습니다";
                }                
            }  
        }
        catch (Exception err)
        {
            //
        }                   
    } 
    //[2]제목길이 자르기
	
	
	
	
	
	
	
    public string FuncCutStrng(object objTitle)
    { 
        //[1]
        string strTitle = Convert.ToString(objTitle);

        //[2]
        if (strTitle.Length > 50)
        {
            return strTitle.Substring(0, 50) + "...";
        }
        else
        {
            return strTitle;
        }
    }
	
	
	public string FuncLineReturn(object objContent)
	{
		string strContent = Convert.ToString(objContent);
		return strContent.Replace("\r\n", "<br />");
	}
	 
	
	
	
	
	
	
	
	
    //[3]오늘쓴글은 뉴이미지
    public string FuncNew(object PostDate)
    {
        //[1]Convert
        DateTime dt = Convert.ToDateTime(PostDate);

        //[2]Different
        TimeSpan Diff = DateTime.Now - dt;

        //[3]Return Value
        string strResult = String.Empty;

        //[4]차이가 24 이하면 새글
        if (Diff.TotalHours < 24)
        {
            
        }

        //[5]리턴
        return strResult;
    }
    #endregion            
}
