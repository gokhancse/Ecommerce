<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="eCommerce.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
	<div class="center_content">
	<div class="center_title_bar"><%=kelime["4"] %></div>
 
	   <asp:ListView ID="ListViewProducts" OnItemCommand="ProductItemCommand" runat="server">
	   <ItemTemplate>
	   <div class="prod_box">
			<div class="center_prod_box">            
			
				<div class="product_title"><asp:LinkButton ID="LinkButton4" CommandName="ProductDetail" CommandArgument='<%#Eval("PIC_ProdID")%>' runat="server"><%#Eval("PIC_ProdName")%></asp:LinkButton></div> 
				<div class="product_img"><asp:LinkButton ID="LinkButton3"  CommandName="ProductDetail" CommandArgument='<%#Eval("PIC_ProdID")%>' runat="server">
					<asp:Image ID="Image1" Width ="120" Height="120"  ImageUrl='<%#Eval("PIC_PictureURL")%>' runat="server" BorderStyle="None" /></asp:LinkButton></div>
						<div class="prod_price"><span class="reduce"><%#Eval("PIC_ProdOldPrice")%></span> <span class="price"><%#Eval("PIC_ProdPrice")%></span></div>                        
			</div>
		   
			<div class="prod_details_tab">
	
			<asp:LinkButton  Font-Size="8pt" CommandName="ProductSale" CommandArgument='<%#Eval("PIC_ProdID")%>' Width="75" Height="24" CssClass="prod_buy" ID="LinkButton1" runat="server"><%=kelime["12"] %></asp:LinkButton>        
			<asp:LinkButton  Font-Size="8pt" CommandName="ProductDetail" CommandArgument='<%#Eval("PIC_ProdID")%>' Width="75" Height="24" CssClass="prod_details" ID="LinkButton2" runat="server"><%=kelime["13"] %>
            </asp:LinkButton>	 
			</div>                     
		</div>
	
	   </ItemTemplate>
	   </asp:ListView>

	 <div id="div_pager">
	   <asp:DataPager ID="DataPager1" runat="server" PageSize="3" PagedControlID="ListViewProducts">
		<Fields>
	
			<asp:NumericPagerField NumericButtonCssClass="pager" />
		</Fields>
		</asp:DataPager>
	 </div>
   </div>
	 
   <!-- end of center content -->

</asp:Content>

