using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_download : System.Web.UI.Page
{
    public string path = "../fileupload/";
  
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request["UpFileName"] != null) && (Request["UpFileName"] != ""))
        {
            ForceDownload("e:\\cjcm\\fileupload\\sion\\", Request["UpFileName"]);
        }
        else
        {
            
            ForceDownload("e:\\cjcm\\fileupload\\sion\\", Request["UpFileName2"]);
        }
     
    }
    /// <summary>
    /// 지정한 경로의 파일을 강제로 다운로드 시킵니다.
    /// </summary>
    /// <param name="path">폴더경로</param>
    /// <param name="fileName">원본 파일명</param>
    /// <param name="downFileName">다운로드 파일명</param>
    public static void ForceDownload(string path,string fileName, string downFileName)
    {
        if ((fileName != null) && (fileName != ""))
        {
            System.Web.HttpContext objCurrent = System.Web.HttpContext.Current;

            string strFullPath = Path.Combine(path, fileName);
            string encFileName = downFileName;
            //// [2009.08.20] IE 6에서 바로 열기시, Encoding으로 인한 문제 발생
            //encFileName = EncodeFileName(downFileName);

            objCurrent.Response.Clear();
            objCurrent.Response.ClearHeaders();
            objCurrent.Response.ClearContent();

            encFileName = HttpUtility.UrlEncode(encFileName,
                                 System.Text.Encoding.UTF8).Replace("+", "%20");

            // [2009.08.20] 해당 파일 다운로드시, Header Encoding을 한글로 처리 (바로 열기시 처리를 위함)
            //objCurrent.Response.HeaderEncoding = System.Text.Encoding.GetEncoding(949);
            //objCurrent.Response.Charset = System.Text.Encoding.GetEncoding(949).HeaderName;
            //objCurrent.Response.ContentEncoding = System.Text.Encoding.GetEncoding(949);

            objCurrent.Response.ContentType = "Application/Unknown";
            objCurrent.Response.AddHeader("content-disposition", "attachment;filename=" + encFileName);
            objCurrent.Response.AddHeader("content-length", (new System.IO.FileInfo(strFullPath)).Length.ToString());
            objCurrent.Response.TransmitFile(strFullPath);
        }        
    }
    /// <summary>
    /// 지정한 경로의 파일을 강제로 다운로드 시킵니다.
    /// </summary>
    /// <param name="path">폴더경로</param>
    /// <param name="fileName">원본 파일명</param>
    public static void ForceDownload(string path, string fileName)
    {
        ForceDownload(path, fileName, fileName);
    }
}

