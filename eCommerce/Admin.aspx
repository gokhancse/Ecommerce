<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="eCommerce.Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Button1" runat="server" Text="Ürün Ekle" onclick="Button1_Click" />
     <asp:Button ID="Button2" runat="server" Text="Ürün Düzenle" 
            onclick="Button2_Click" />
      <asp:Button ID="Button3" runat="server" Text="Ürün Sil" onclick="Button3_Click" />
    </div>
    </form>
</body>
</html>
