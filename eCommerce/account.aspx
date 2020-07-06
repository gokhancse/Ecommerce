<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="eCommerce.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
	<div class="center_content">

	<div class="center_title_bar"><%=kelime["4"] %></div>
		<asp:Panel ID="PanelUpdate" Visible="false" runat="server">
		<div id="div_update">
		<asp:Label ID="Label1" runat="server" ></asp:Label>
		<br />
		<br />
		<br />
		<br />
		<br />
		<br />
	
	</div>
		</asp:Panel>
	


		<div id="div_mes">
	</div>
		<asp:Panel ID="PnlMember" Visible="false" runat="server">
		 <div   id="div_signin">
	
					
					 <br />
			   <div >
				 <asp:Label ID="Label2" runat="server" ></asp:Label>
				 <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="1"></asp:TextBox>
			   </div>
			  
			   <div style="margin-left: 35px" >
				<asp:Label ID="Label3" runat="server" Text="Şifre :"></asp:Label>
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
                       ValidationGroup="1"></asp:TextBox>
			   </div>	
			   <div style="float: right; margin-right: 75px" >
				   <asp:Button ID="Button2" runat="server"  onclick="Button2_Click" 
                       ValidationGroup="1" />
				   <asp:Button ID="Button1" runat="server" onclick="Button1_Click" />
				   <br />
                    <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Label"></asp:Label>
					 <asp:Label ID="lblLoginMessage" Visible="false" runat="server" Text=""></asp:Label>
			   </div>
	 </div>
		</asp:Panel>
	  
	</div>
  
</asp:Content>
