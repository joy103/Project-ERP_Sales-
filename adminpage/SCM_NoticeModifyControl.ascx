<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeModifyControl.ascx.cs" Inherits="Admin_SCM_NoticeModifyControl"  %>

<link rel="stylesheet" href="build/kalendae.css" type="text/css" charset="utf-8">
   <script src="build/kalendae.js" type="text/javascript" charset="utf-8"></script>
   <style type="text/css" media="screen">
      .kalendae .k-days span.closed {
         background:red;
      }

      .tdd {
         border: 1px solid #efefef;
      }
   </style>
   
<table width=98% style="border: 1px solid #d7d7d7">

<tr height=30  bgcolor="#4d4d4d">
<td  colspan=9 align=center><font color="#ffffff" size="3rem"><b>담당자별 판매 실적</b></td>
</tr>

<tr height=30>
<td bgcolor="#efefef" width="8%" align=center><b>품목</b></td>
<td bgcolor="#efefef" width="25%" align=center><b> 품명 및 규격 </b></td>
<td bgcolor="#efefef" width="7%" align=center><b> 담당자명 </b></td>
<td bgcolor="#efefef" width="10%" align=center><b> 일자 </b></td>
<td bgcolor="#efefef" width="10%" align=center><b> 수량 </b></td>
<td bgcolor="#efefef" width="10%" align=center><b> 단가</b></td>
<td bgcolor="#efefef" width="10%" align=center><b> 공급가액 </b></td>
<td bgcolor="#efefef" width="10%" align=center><b> 부가세 </b></td>
<td bgcolor="#efefef" width="10%" align=center><b> 합계 </b></td>
</tr>

<tr height=30>
<td class="tdd" align=center><asp:DropDownList ID="txtitem1" runat="server">
<asp:ListItem Value="전자기기">전자기기</asp:ListItem>
    <asp:ListItem Value="의류">의류</asp:ListItem>
        <asp:ListItem Value="생활용품">생활용품</asp:ListItem>
   <asp:ListItem Value="식품">식품</asp:ListItem>
   <asp:ListItem Value="건강">건강</asp:ListItem>
   <asp:ListItem Value="도서">도서</asp:ListItem>
   </asp:DropDownList></td>

<td class="tdd" align=center><asp:DropDownList ID="txtTitle" runat="server">
<asp:ListItem Value="가장 빠른 노트북 [15inch]">가장 빠른 노트북 [15inch]</asp:ListItem>
    <asp:ListItem Value="USB 마우스 [Black]">USB 마우스 [Black]</asp:ListItem>
        <asp:ListItem Value="무선 이어폰 [White]">무선 이어폰 [White]</asp:ListItem>
   <asp:ListItem Value="블루투스 키보드 [Black]">블루투스 키보드 [Black]</asp:ListItem>
   <asp:ListItem Value="스마트 워치 [Silver]">스마트 워치 [Silver]</asp:ListItem>
   <asp:ListItem Value="따뜻한 겨울 양말 남성용 [Black]">따뜻한 겨울 양말 남성용 [Black]</asp:ListItem>
   <asp:ListItem Value="따뜻한 겨울 양말 여성용 [Black]">따뜻한 겨울 양말 여성용 [Black]</asp:ListItem>
    <asp:ListItem Value="따뜻한 겨울 양말 남성용 [White]">따뜻한 겨울 양말 남성용 [White]</asp:ListItem>
        <asp:ListItem Value="따뜻한 겨울 양말 여성용 [White]">따뜻한 겨울 양말 여성용 [White]</asp:ListItem>
   <asp:ListItem Value="경량 패딩 자켓 남녀공용 [Ivory,90]">경량 패딩 자켓 남녀공용 [Ivory,90]</asp:ListItem>
   <asp:ListItem Value="경량 패딩 자켓 남녀공용 [Ivory,95]">경량 패딩 자켓 남녀공용 [Ivory,95]</asp:ListItem>
   <asp:ListItem Value="경량 패딩 자켓 남녀공용 [Ivory,100]">경량 패딩 자켓 남녀공용 [Ivory,100]</asp:ListItem>
   <asp:ListItem Value="편한 슬리퍼 [260]">편한 슬리퍼 [260]</asp:ListItem>
    <asp:ListItem Value="깨끗한 물티슈 [100매]">깨끗한 물티슈 [100매]</asp:ListItem>
        <asp:ListItem Value="스테인리스 텀블러 [473mL]">스테인리스 텀블러 [473mL]</asp:ListItem>
   <asp:ListItem Value="맛있는 딸기우유 [4개]">맛있는 딸기우유 [4개]</asp:ListItem>
   <asp:ListItem Value="민트초코 아이스크림 [474mL]">민트초코 아이스크림 [474mL]</asp:ListItem>
   <asp:ListItem Value="쫀득한 치즈볼 [270g]">쫀득한 치즈볼 [270g]</asp:ListItem>
   <asp:ListItem Value="한우 안심 스테이크 [600g]">한우 안심 스테이크 [600g]</asp:ListItem>
    <asp:ListItem Value="친환경 무항생제 특란 [30구]">친환경 무항생제 특란 [30구]</asp:ListItem>
        <asp:ListItem Value="멀티비타민 100정">멀티비타민 100정</asp:ListItem>
   <asp:ListItem Value="몸에 좋은 유산균 [60포]">몸에 좋은 유산균 [60포]</asp:ListItem>
   <asp:ListItem Value="KF94 마스크 [50매]">KF94 마스크 [50매]</asp:ListItem>
   <asp:ListItem Value="세상을 변화시키는 화학공학">세상을 변화시키는 화학공학</asp:ListItem>
   <asp:ListItem Value="JAVA 마스터">JAVA 마스터</asp:ListItem>
   <asp:ListItem Value="모든 순간의 물리학">모든 순간의 물리학</asp:ListItem>
   <asp:ListItem Value="신소재 개발이야기">신소재 개발이야기</asp:ListItem>
</asp:DropDownList></td>

<td class="tdd" align=center><nobr>
<asp:DropDownList ID="txtsalesman1" runat="server">
   <asp:ListItem Value="김가연">김가연</asp:ListItem>
   <asp:ListItem Value="오민준">오민준</asp:ListItem>
   <asp:ListItem Value="이정현">이정현</asp:ListItem>
   <asp:ListItem Value="장지인">장지인</asp:ListItem>
</asp:DropDownList>
</td>

<td class="tdd" align=center><b><asp:TextBox ID="txtsalesdate1"  class="auto-kal"  runat="server" Width="80%"></asp:TextBox></b>
</td>

<td class="tdd" align=center><nobr>
<asp:TextBox Width="80%" ID="txtea1" class="txtea1" onKeyup="inputNumberAutoComma(this);" runat="server" ></asp:TextBox>
</td>

<td class="tdd" align=center><nobr><asp:TextBox width="90%" ID="txtprice1" class="txtprice1" onchange="calculate()" onKeyup="inputNumberAutoComma(this);" runat="server" ></asp:TextBox>      
</td>

<td class="tdd" align=center><nobr><asp:TextBox Width="90%" ID="txtsupply1" class="txtsupply1" runat="server"  ></asp:TextBox></td>

<td class="tdd" align=center>
<asp:TextBox Width="80%" ID="txtvat1" class="txtvat1" runat="server"></asp:TextBox> 
</nobr></td>

<td class="tdd" align=center><b><asp:TextBox ID="txttotal1" class="txttotal1" runat="server"  Width="80%"></asp:TextBox></b></td>
</tr>
</table>
<Br>

<table width=98% border="1" bordercolor="#d7d7d7">
<tr height=30>
<td bgcolor="#efefef" align=center><b> 판매처명 </b></td>
<td class="tdd" align=left><b><asp:DropDownList ID="txtcompany1" runat="server">
<asp:ListItem Value="(주)삼송테크">(주)삼송테크</asp:ListItem>
    <asp:ListItem Value="(주)애플파트너">(주)애플파트너</asp:ListItem>
        <asp:ListItem Value="CSS마켓">CSS마켓</asp:ListItem>
      <asp:ListItem Value="(주)DB패션">(주)DB패션</asp:ListItem>
    <asp:ListItem Value="다이서">다이서</asp:ListItem>
        <asp:ListItem Value="ETRI커피">ETRI커피</asp:ListItem>
   <asp:ListItem Value="쿠펑">쿠펑</asp:ListItem>
   <asp:ListItem Value="마켓에스큐엘">마켓에스큐엘</asp:ListItem>
      <asp:ListItem Value="(주)H케어">(주)H케어</asp:ListItem>
    <asp:ListItem Value="아우터파크">아우터파크</asp:ListItem>
   <asp:ListItem Value="NO24">NO24</asp:ListItem></asp:DropDownList></b></td>

   <td rowspan=3  bgcolor="#efefef" width="10%" align=center><b>이미지</b></td>
<td class="tdd" rowspan=3 align=left width="40%"><% if (lblFileName.Text != "")  { %>
<img src ="../../fileUpload/notice/<%= lblFileName.Text %>" width=50%>
<%} else { %><%} %><!--<asp:Label ID="lblFileName" runat="server"></asp:Label>--><asp:FileUpload ID="FileUpload1" runat="server" /></asp:FileUpload></td>
</nobr></td>
</tr>                                             

</table>               


 
 
 <table width="100%" border="0">
      <tr><td><HR SIZE=1></td></tr>
                <tr><td align="right">
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Images/ok_bt.gif" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/cancel_bt.gif"
                            OnClick="btnCancel_Click" />
                </td></tr>
            </table>
  
 
<script src="sales.js" type="text/javascript" charset="utf-8"></script>



                 
 



 

 