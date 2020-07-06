<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productdetail.aspx.cs" Inherits="eCommerce.productdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
		<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="center_content">

	<div class="center_title_bar"><%=kelime["18"] %></div>
	<asp:Image ID="Image1" Width="120" Height="120" runat="server" />
	<br />
	<asp:Label ID="Label1" runat="server"></asp:Label>
	<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
	<br />
	<asp:Label ID="Label2" runat="server"></asp:Label>
	  <asp:Label ID="LblPrice" runat="server" Text="Label"></asp:Label>
	<br />
	  <asp:Label ID="Label4" runat="server"></asp:Label>
		<asp:Label ID="Lblinfo" runat="server" Text="Label"></asp:Label>
		<br />
		<asp:Label ID="Label5" runat="server"></asp:Label>
		<asp:Label ID="LblStockinfo" runat="server" Text="Label"></asp:Label>
		<br />
		<asp:LinkButton  Font-Size="8pt"  Width="75" Height="24" 
		CssClass="prod_buy" ID="LinkButton1" runat="server" onclick="LinkButton1_Click"><%=kelime["12"] %></asp:LinkButton>
	<br />
	<br />
	<br />
	<asp:Label ID="lblwarning" runat="server" Text=""></asp:Label>
   </div>
   <!-- end of center content -->
</asp:Content>
