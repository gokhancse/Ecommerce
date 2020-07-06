<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productbrands.aspx.cs" Inherits="eCommerce.productbrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="center_content">

	<div class="center_title_bar">
		<asp:Label ID="Lbltitle" runat="server" Text=""></asp:Label></div>
	  <asp:ListView ID="ListViewBrands"  OnItemCommand="ProductItemCommand" runat="server">
	   <ItemTemplate>
	   <div class="prod_box">

			<div class="center_prod_box">            
				<div class="product_title"><asp:LinkButton ID="LinkButton4" CommandName="ProductDetail" CommandArgument='<%#Eval("PIC_ProdID")%>' runat="server"><%#Eval("PIC_ProdName")%></asp:LinkButton></div> 
				  <div class="product_img"><asp:LinkButton ID="LinkButton3"  CommandName="ProductDetail" CommandArgument='<%#Eval("PIC_ProdID")%>' runat="server">
			   <asp:Image ID="Image1" Width ="120" Height="120" ImageUrl='<%#Eval("PIC_PictureURL")%>' runat="server" BorderStyle="None" /></asp:LinkButton></div>
				 <div class="prod_price"><span class="reduce"><%#Eval("PIC_ProdOldPrice")%></span> <span class="price"><%#Eval("PIC_ProdPrice")%></span></div>                        
			</div>
			
			<div class="prod_details_tab">
			 
				 <asp:LinkButton Text="Sepete Ekle" Font-Size="8pt" CommandName="ProductSale" CommandArgument='<%#Eval("PIC_ProdID")%>' Width="75" Height="24" CssClass="prod_buy" ID="LinkButton1" runat="server">Sepete Ekle</asp:LinkButton>        
			<asp:LinkButton  Font-Size="8pt" CommandName="ProductDetail" CommandArgument='<%#Eval("PIC_ProdID")%>' Width="75" Height="24" CssClass="prod_details" ID="LinkButton2" runat="server">Detay</asp:LinkButton>         
			</div>                     
		</div>
	
	   </ItemTemplate>
	   </asp:ListView>
	
	   <div class="prod_box">

			<div class="center_prod_box">            
									 
			</div>
							  
		</div>
	</div>
</asp:Content>
