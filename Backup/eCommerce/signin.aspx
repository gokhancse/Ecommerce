<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="eCommerce.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="center_content">

	<div class="center_title_bar"><%=kelime["7"] %></div>
	<div id="wrapper" >
	
	 <div id="div_signin">
	
					 
			   <div >
				 <asp:Label ID="Label1" runat="server"></asp:Label>
				 <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="1"></asp:TextBox>
				   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
					   ControlToValidate="txtPassword" ErrorMessage="Zorunlu" ValidationGroup="1"></asp:RequiredFieldValidator>
			   </div>
			  
			   <div style="margin-left: 35px" >
				<asp:Label ID="Label2" runat="server"></asp:Label>
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
					   ValidationGroup="1"></asp:TextBox>
				   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
					   ControlToValidate="txtPassword" ErrorMessage="Zorunlu" ValidationGroup="1"></asp:RequiredFieldValidator>
			   </div>	
			   <div style="float: right; margin-right: 75px" >
				   <asp:Button ID="Button2" runat="server"  onclick="Button2_Click" 
					   ValidationGroup="1" />
				   <br />
				
					
				
			   </div>
	 </div>
	 
	 <div>
	 
	 </div>
	 <div id="div_newcustomer">
		
				
			<asp:Button ID="Button1" runat="server" onclick="Button1_Click" />
				 
	 </div> 
	</div>
	
   </div>
	
</asp:Content>
