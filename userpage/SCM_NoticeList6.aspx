<%@ Page Language="C#" MasterPageFile="MasterPageSCM_Notice.master" Title="프로젝트정보" %>

<%@ Register Src="SCM_NoticeListControl.ascx" TagName="SCM_NoticeListControl" TagPrefix="uc1" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
	<uc1:SCM_NoticeListControl ID="NoticeListControl1" item1="도서" runat="server" />
</asp:Content>

