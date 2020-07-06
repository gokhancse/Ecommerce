<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="eCommerce.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="center_content">

	<div class="center_title_bar"><% =kelime["9"] %> </div>
		<div id="info">
	<table>
	  <tr>
		  <td>
			  <asp:Label ID="Label7" runat="server" ></asp:Label>
		  </td>
		  <td>
			 <asp:Label ID="Label8" runat="server" Text="İSTANBUL KÜLTÜR ÜNİVERSİTESİ"></asp:Label>
		 </td>
	</tr>
	  <tr>
		   <td>
			<asp:Label ID="Label9" runat="server" ></asp:Label>
		   </td>
		   <td>
			 <asp:Label ID="Label10" runat="server" Text="0506 261 27 42 "></asp:Label>
		   </td>
	  </tr>
	</table>
	</div>
	<br />
		<div id="div_contactTable">
		<table>
			<tr>
				<td>
				 <asp:Label ID="Label6" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
				 <asp:Label ID="Label1" runat="server" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
						ControlToValidate="txtName"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				 <asp:Label ID="Label2" runat="server" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
						ControlToValidate="txtSurname" ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				 <asp:Label ID="Label3" runat="server" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
						ControlToValidate="txtMessage" ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				 <asp:Label ID="Label4" runat="server" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
						ControlToValidate="txtPhone" ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
				 <asp:Label ID="Label5" runat="server" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="102px" 
						Width="350px"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
						ControlToValidate="txtMessage" ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Button ID="btnMessage" runat="server" 
						onclick="btnMessage_Click" ValidationGroup="1" />
				</td>
			</tr>
		</table>
		</div>
	 <br />
        </div>
</asp:Content>
