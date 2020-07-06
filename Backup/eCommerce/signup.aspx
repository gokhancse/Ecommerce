<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="eCommerce.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/style.css" rel="stylesheet" type="text/css" />
    <a href="signup.aspx">signup.aspx</a>
<script src="js/boxOver.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
	<div class="center_content">

	<div class="center_title_bar"><%=kelime["6"] %></div>
	<div id="div_personalinfo">
		<table >
			<tr>
				<td>
					<asp:Label ID="Label6" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtName" runat="server" Height="24px" Width="196px" 
						ValidationGroup="1" MaxLength="15"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
						ControlToValidate="txtName"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtSurname" runat="server" Height="24px" Width="196px" 
                        MaxLength="15"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
						ControlToValidate="txtSurname"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label14" runat="server"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtEmail" runat="server" Height="22px" Width="196px" 
						ValidationGroup="1"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
						ControlToValidate="txtEmail"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtPassword" runat="server" Height="24px" Width="196px" 
						ValidationGroup="1" TextMode="Password"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
						ControlToValidate="txtPassword"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label4" runat="server"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtPasswordRetype" runat="server" Height="25px" Width="196px" 
						ValidationGroup="1" TextMode="Password"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
						ControlToValidate="txtPasswordRetype"  
						ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>
	 </div>

	<div id="div_addressinfo" >
	 <table>
	 <tr>
		<td>
			<asp:Label ID="Label5" runat="server"></asp:Label>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Label ID="Label7" runat="server"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txtAddress" runat="server" Height="24px" ValidationGroup="1" 
                Width="637px"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
				ControlToValidate="txtAddress"  ValidationGroup="1"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Label ID="Label8" runat="server"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txtTown" runat="server" Height="24px" ValidationGroup="1"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
				ControlToValidate="txtTown"  ValidationGroup="1"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Label ID="Label9" runat="server"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txtCountry" runat="server" Height="24px" ValidationGroup="1"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
				ControlToValidate="txtCountry"  ValidationGroup="1"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Label ID="Label10" runat="server"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txtCity" runat="server" Height="24px" Width="145px" 
				ValidationGroup="1"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
				ControlToValidate="txtCity"  ValidationGroup="1"></asp:RequiredFieldValidator>
		</td>
	</tr>

	</table>
	 </div>

	<div id="div_contactinfo">
		<table>
			<tr>
				<td>
					<asp:Label ID="Label11" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label12" runat="server"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtPhone" runat="server" Height="24px" Width="196px" 
						ValidationGroup="1"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
						ControlToValidate="txtPhone"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label13" runat="server" ></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txtGSM" runat="server" Height="24px" Width="196px" 
						ValidationGroup="1"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
						ControlToValidate="txtGSM"  ValidationGroup="1"></asp:RequiredFieldValidator>
				</td>
			</tr>
		</table>
	 </div>
	<div>
		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
			ValidationGroup="1" />
            <br />
            <br />
            <br />
            <asp:Label ID="Lblregistration" runat="server" Visible="false" Text=""></asp:Label>
	</div> 
        
	
   </div>
		

		
</asp:Content>
