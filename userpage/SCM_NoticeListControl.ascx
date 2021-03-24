<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCM_NoticeListControl.ascx.cs"  Inherits="SCM_NoticeListControl" %>   
<asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>

<link rel="stylesheet" href="js/fancybox/source/jquery.fancybox.css?v=2.1.5" type="text/css" media="screen" />
<script type="text/javascript" src="js/fancybox/source/jquery.fancybox.pack.js?v=2.1.5"></script> 
 					 
<SCRIPT LANGUAGE="JavaScript">
<!--
  function viewStyle(obj){
    while(true){
      if((obj=obj.nextSibling).nodeName=="DIV"){
        obj.style.display=(obj.style.display!='block')?'block':'none';
        obj.style.fontSize = "13px";	
        obj.style.color = "#000000";
		//obj.style.backgroundColor = "#ffffff";
		obj.style.width = "100%";		
        break;
      }
    }
  }
 
//-->

</script>


<style type="text/css">

.dropbtn {
  background-color: #E7D1FF ;
  color: black;
  padding: 16px;
  font-size: 15px;
  border: none;
}

.dropdown {
  margin-left : 18px;
  position: relative;
  display: inline-block;  
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #ffffff;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

.dropdown-content a:hover {background-color: #ddd;}

.dropdown:hover .dropdown-content {display: block;}

.dropdown:hover .dropbtn {background-color: #BA7BFF;}


.sum_line .val1 {
    background-color: #efefef;
    color: #000;
    font-weight: 600;
    text-align: center;
    height: 18px;
}
.sum_line .val2 {
    background-color: #efefef;
    color: #000;
    font-weight: 600;
    text-align: right;
    height: 18px;
}
.salesTR:hover {
    background-image: linear-gradient(to right, #fbc2eb 0%, #a6c1ee 51%, #fbc2eb 100%);
     box-shadow: 0px 0px 20px #ffd7d7;
    z-index: 2;
    -webkit-transition: all 200ms ease-in;
    -webkit-transform: scale(1.01);
    -ms-transition: all 200ms ease-in;
    -ms-transform: scale(1.01);   
    -moz-transition: all 200ms ease-in;
    -moz-transform: scale(1.01);
    transition: all 200ms ease-in;
    transform: scale(1.01);
}


.totalcheckk {
  margin-top: 15px;
  margin-bottom: -19px;
}

</style>

<br>

<div style="height:20px;"></div>

<div align=center style="font-size:2.5rem">담당자별 판매 실적</div> 

<div style="height:20px;"></div>

<div class="dropdown">
  <button class="dropbtn"><b>담당자 선택</b></button>
  <div class="dropdown-content">
    <a href="SCM_NoticeList7.aspx">전체</a> 
    <a href="SCM_NoticeList.aspx">김가연</a>
    <a href="SCM_NoticeList2.aspx">오민준</a>
    <a href="SCM_NoticeList3.aspx">이정현</a>
    <a href="SCM_NoticeList4.aspx">장지인</a>
  </div>
</div>

<div class="totalcheckk"> 
  <input type="checkbox" class="totalcheck">담당자별 합계 확인
</div>

<div align=right style='font-size:14px; margin-right:10px;'> 
  회사명 : 이카운트 &nbsp; &nbsp; &nbsp; &nbsp;  
  <span id='date'>2020/11/01 ~ </span> 
</div>

<font face='맑은 고딕'>

<asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
  <ContentTemplate>
    <asp:GridView ID="ctlNoticeList" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        Width="100%" Font-Size="14px" CellPadding="4" ForeColor="#a29e9e"  PageSize="50"
          OnPageIndexChanging="ctlNoticeList_PageIndexChanging">
                

      <Columns> 
                     
        <asp:TemplateField HeaderText="일자"> 
          <ItemTemplate>                                                 
            <%#FuncCutStrng(Eval("salesdate1"))%> 
          </ItemTemplate>
          <ItemStyle Width="7%" HorizontalAlign="center" ForeColor="#0088cc"  verticalAlign="middle"/>
        </asp:TemplateField> 
      
        <asp:TemplateField HeaderText="담당자명">
          <ItemTemplate>                                                 
            <div class="salesman">
              <%#FuncCutStrng(Eval("salesman1"))%>
            </div>
          </ItemTemplate>
          <ItemStyle Width="8%" HorizontalAlign="left" Font-Bold="True" ForeColor="blue" verticalAlign="middle"/>
        </asp:TemplateField> 	

        <asp:TemplateField HeaderText="품목 및 규격">
          <ItemTemplate> 
            <a href='SCM_NoticeView.aspx?SCM_SalesID=<%#Eval("SCM_SalesID") %>' onclick="viewStyle(this);return false">													
              <!a class="fancybox fancybox.iframe" href='SCM_NoticeView.aspx?SCM_SalesID=<%#Eval("SCM_SalesID") %>' onfocus="this.blur()" rel="external"> 
              &nbsp;<%#FuncCutStrng(Eval("Title"))%>....more
              &nbsp;<%#FuncNew(Eval("PostDate")) %>
            </a>
        
          <div style='display:none'>
          <br>
          <img src='../../fileUpload/notice/<%#FuncCutStrng(Eval("UpFileName"))%>' width=30% height=40%>													
          <br>
          <br>
            * 수량 : <%#FuncCutStrng(Eval("ea1"))%> ea <br>
            * 단가 : \ <%#FuncCutStrng(Eval("price1"))%><br>
            * 공급가액 : \ <%#FuncCutStrng(Eval("supply1"))%><br>
            * 부가세 : \ <%#FuncCutStrng(Eval("vat1"))%><br>
            * 합계 : \ <%#FuncCutStrng(Eval("total1"))%><br>
            * 판매처명 : <%#FuncCutStrng(Eval("company1"))%> 
          <br>
          <br>												   
          </div>
          </ItemTemplate>
          <ItemStyle Width="35%"   HorizontalAlign="left" verticalAlign="middle" />
        </asp:TemplateField>  
  
  
        <asp:TemplateField HeaderText="수량">
          <ItemTemplate>
            <div class="ea"> 
              <%#FuncCutStrng(Eval("ea1"))%> 
            </div>
          </ItemTemplate>
          <ItemStyle Width="8%" HorizontalAlign="right"   verticalAlign="middle"/>
        </asp:TemplateField>    
  
        <asp:TemplateField HeaderText="단가">
          <ItemTemplate>    
            <div class="price">                                          
              <%#FuncCutStrng(Eval("price1"))%>
            </div>
          </ItemTemplate>
          <ItemStyle Width="8%" HorizontalAlign="right"   verticalAlign="middle"/>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="공급가액">
          <ItemTemplate>  
            <div class="supply">                                             
              <%#FuncCutStrng(Eval("supply1"))%>
            </div>
          </ItemTemplate>
        <ItemStyle Width="8%" HorizontalAlign="right"   verticalAlign="middle"/>
        </asp:TemplateField> 
  
  
        <asp:TemplateField HeaderText="부가세">
          <ItemTemplate> 
            <div class="vat"> 
            <%#FuncCutStrng(Eval("vat1"))%>
            </div>								   
          </ItemTemplate>
          <ItemStyle Width="8%" HorizontalAlign="right" verticalAlign="middle"/>
        </asp:TemplateField> 
  
        <asp:TemplateField HeaderText="합계">
          <ItemTemplate>         
            <div class="total">                                        
              <%#FuncCutStrng(Eval("total1"))%></font>
            </div>										
          </ItemTemplate>
          <ItemStyle Width="8%" HorizontalAlign="right"   verticalAlign="middle"/>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="판매처명">
          <ItemTemplate>                                                
            <%#FuncCutStrng(Eval("company1"))%>									
          </ItemTemplate>
          <ItemStyle HorizontalAlign="left"   verticalAlign="middle"/>
        </asp:TemplateField> 

      </Columns>
  
      <HeaderStyle BackColor="#f2f2f2"  ForeColor="#0088cc" HorizontalAlign="Center"/> 
      <RowStyle BackColor="#ffffff" ForeColor="#333333" />
      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /> 
      <EditRowStyle BackColor="#999999" />
      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#a29e9e" />
      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
      <AlternatingRowStyle BackColor="White" ForeColor="#000000" />								
    </asp:GridView>
    
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
  
  </ContentTemplate>
</asp:UpdatePanel>

</font>	 
  						

<script type="text/javascript" src="js/jquery-latest.js"></script> 
<link rel="stylesheet" href="js/fancybox/source/jquery.fancybox.css?v=2.1.5" type="text/css" media="screen" />
<script type="text/javascript" src="js/fancybox/source/jquery.fancybox.pack.js?v=2.1.5"></script> 

<script type="text/javascript">
	$(document).ready(function() {
		$(".fancybox").fancybox({		
		fitToView	: false,
		width		: '100%',
		height	: '300',
		autoSize	: false,
		autoCenter	: false,
		closeClick	: false,
		openEffect	: 'none',
		closeEffect	: 'none'
		 
	});
});
</script> 

<!--user화면에 대한 js 파일 불러오기-->
<script src="salespc.js" type="text/javascript"></script>


 		


















<!--
    
    <style type="Text/css">
      .tab {
        overflow: hidden;
        background-color: white;
        width: 700px;
      }

      .tab button {
        background-color: inherit;
        float: left;
        border: none;
        outline: none;
        cursor: pointer;
        padding: 14px 16px;
        font-weight: 600;
        transition: 0.3s;
        width:100px;
      }

      .tab button:hover {background-color: #cce0ff;}
      .tab button.active {background-color: #ccc;}

      .tabcontent {
        display: none;
        padding: 6px 12px;
        border: 1px solid #ccc;
        border-top: none;
        animation: fadeEffect 1s;
      }

      @keyframes fadeEffect {
        from {opacity: 0;}
        to {opacity: 1;}
      }
    
      
    </style>
    
    
    <div class="tab">
      <button class="tablinks" id="tab1"><a href="SCM_NoticeList7.aspx">전체</a></button>  
      <button class="tablinks" id="tab1"><a href="SCM_NoticeList2.aspx">전자기기</a></button>
      <button class="tablinks" id="tab1"><a href="SCM_NoticeList.aspx">의류</a></button>
      <button class="tablinks" id="tab1" ><a href="SCM_NoticeList3.aspx">생활용품</a></button>
      <button class="tablinks" id="tab1"><a href="SCM_NoticeList4.aspx">식품</a></button>
      <button class="tablinks" id="tab1"><a href="SCM_NoticeList5.aspx">건강</a></button>
      <button class="tablinks" id="tab1"><a href="SCM_NoticeList6.aspx">도서</a></button>
</div>-->