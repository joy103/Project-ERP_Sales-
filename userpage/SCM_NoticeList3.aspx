<%@ Page Language="C#" MasterPageFile="MasterPageSCM_Notice.master" Title="프로젝트정보" %>

<%@ Register Src="SCM_NoticeListControl.ascx" TagName="SCM_NoticeListControl" TagPrefix="uc1" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
	<!--salesman1의 값이 이정현일 때 content를 불러옵니다.-->
	<uc1:SCM_NoticeListControl ID="NoticeListControl1" salesman1="이정현" runat="server" />
</asp:Content>

