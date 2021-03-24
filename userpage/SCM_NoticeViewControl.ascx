<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeViewControl.ascx.cs" Inherits="SCM_NoticeViewControl" %>
<asp:Label ID="lblNoticeError" runat="server" ForeColor="Red"></asp:Label>

<div id="text_mode_c" align=center><b>품명 및 규격 : <asp:Label ID="lblTitle" runat="server"></asp:Label></b></div>
 
<!div id="text_mode_c" align=justify>



<TABLE width=100% border=0> 
<tr bgcolor="#efefef" height=30> 

<td id="text_mode_c" align=left colspan=2><b>판매처명 : <asp:Label ID="lblcompany1" runat="server"></asp:Label></b></td></tr> 
<tr>
<td  align=center valign=top width=30%> 
<img src ="../../fileUpload/notice/<%= lblFileName.Text %>" width=100%>
</td> 
<td align=left width=70%> 
<br><br> 
일자 : <asp:Label ID="lblsalesdate1" runat="server"></asp:Label><br>
수량 : <asp:Label ID="lblea1" runat="server"></asp:Label><br>
부가세 : <asp:Label ID="lblprice1" runat="server"></asp:Label><br>
공급가액 : <asp:Label ID="lblsupply1" runat="server"></asp:Label><br>
부가세 : <asp:Label ID="lblvat1" runat="server"></asp:Label> <br>
합계 : <asp:Label ID="lbltotal1" runat="server"></asp:Label> <br>
</td></tr>
<tr bgcolor="#efefef">
 
<td id="text_mode_t" align=left width=20%> </td>
<td   align=left><a class="fancybox fancybox.iframe"  href="../../job_jiwon/a/SCM_jiwonAdd.aspx"><font color="#000000"><font size=3><b>
품목 : <font color="red"><asp:Label ID="lblitem1" runat="server"></asp:Label></font>&nbsp;&nbsp;|&nbsp;&nbsp;
번호 : <font color="red"><asp:Label ID="lblSCM_SalesID" runat="server"></asp:Label></font></b>&nbsp;&nbsp;
</td></tr> 
</table> 











<!--<div id="text_mode_s" align=right><b>일자 : <asp:Label ID="lblps" runat="server"></asp:Label></b></div> 
<asp:Label ID="lblContent" runat="server"></asp:Label> 
<asp:Label ID="lblPostDate" runat="server"></asp:Label><asp:Label ID="lblReadCount" runat="server"></asp:Label>                                    
<asp:Label ID="lblFileName" runat="server"></asp:Label><asp:Button  ID="btnFile"  runat="server" onclick="btnFile_Click" Text="" />-->   
  

 